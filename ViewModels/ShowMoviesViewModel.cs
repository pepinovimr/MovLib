using Microsoft.EntityFrameworkCore;
using MovLib.Data.Context;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    internal class ShowMoviesViewModel : BaseViewModel
    {
        private readonly MoviesDbContext _context = new();

        private readonly ObservableCollection<MovieViewModel> _movies;

        public IEnumerable<MovieViewModel> Movies => _movies;

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
			_movies = new();
        }
    }
}
