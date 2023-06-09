using Microsoft.EntityFrameworkCore;
using MovLib.Commands;
using MovLib.Data.Context;
using MovLib.Data.Models;
using MovLib.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    public class ShowMoviesViewModel : BaseViewModel
    {
		private readonly ApplicationDbContext _context;

		private readonly IMovieService _movieService;

		private ObservableCollection<Movie> _movies;

		public ObservableCollection<Movie> Movies
		{
			get { return _movies; }
			set 
			{
				_movies = value; 
				OnPropertyChanged(nameof(Movies));
			}
		}

		/// <summary>
		/// Handles View of collection - Can filter group etc, without changes to main collection
		/// </summary>
		public ICollectionView MoviesCollectionView { get; }

        private string _filterText = string.Empty;
		public string FilterText
		{
			get
			{
				return _filterText;
			}
			set
			{
				_filterText = value;
				OnPropertyChanged(nameof(FilterText));
				MoviesCollectionView.Refresh();
			}
		}

        private ObservableCollection<Movie> _selectedItems = new();

        public ObservableCollection<Movie> SelectedItems {
            get { return _selectedItems; }
			set
            {
				_selectedItems = value;
				OnPropertyChanged(nameof(SelectedItems));
            }
		}

        public ICommand DeleteCommand { get; }
        public ICommand ChangeCommand { get; }
		public ICommand ShowDetailCommand { get; }



		public ShowMoviesViewModel(ApplicationDbContext context, IMovieService movieService)
        {
			_context = context;
			_movieService = movieService;

			//_context.Movies.LoadAsync();
			_movies = _context.Movies.Local.ToObservableCollection();

			SelectedItems = new ObservableCollection<Movie>();

			MoviesCollectionView = CollectionViewSource.GetDefaultView(_movies);
			MoviesCollectionView.Filter = FilterMovies;

			DeleteCommand = new RelayCommand(OnMoviesDelete);
        }

        private void OnMoviesDelete()
        {
            if(_selectedItems.Count < 1)
			{
				MessageBox.Show("Nejdříve vyberte záznam ke smazání", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			_movieService.DeleteMovies(_selectedItems.ToList());
        }

        private bool FilterMovies(object obj)
		{
			if (obj is Movie movie)
			{
				return movie.Title.Contains(FilterText, StringComparison.InvariantCultureIgnoreCase) || 
					(movie.Tagline != null && movie.Tagline.Contains(FilterText, StringComparison.InvariantCultureIgnoreCase));

            }

			return false;
		}
    }
}
