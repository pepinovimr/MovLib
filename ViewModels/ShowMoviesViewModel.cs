using Microsoft.EntityFrameworkCore;
using MovLib.Commands;
using MovLib.Data.Context;
using MovLib.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    public class ShowMoviesViewModel : BaseViewModel
    {
        private readonly MoviesDbContext _context = new();

        private readonly ObservableCollection<Movie> _movies;

        public IEnumerable<Movie> Movies => _movies;

		/// <summary>
		/// Handles View of collection - Can filter group etc, without changes to main collection
		/// </summary>
		public ICollectionView MoviesCollectionView { get; }

        private string _filterText;
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
			}
		}

		public ICommand DeleteCommand { get; }
        public ICommand ChangeCommand { get; }

        public ShowMoviesViewModel()
        {
			_context.Movies.Load();
			_movies = _context.Movies.Local.ToObservableCollection();
			MoviesCollectionView = CollectionViewSource.GetDefaultView(_movies);
			
			DeleteCommand = new DeleteMovieCommand();
        }
    }
}
