using Microsoft.EntityFrameworkCore;
using MovLib.Commands;
using MovLib.Data.Context;
using MovLib.Data.Models;
using MovLib.Helpers;
using MovLib.Services;
using MovLib.Services.Interfaces;
using MovLib.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    public class AddMovieViewModel : BaseViewModel
    {
        private IMovieService _movieService;

        private Movie _movie;
        private readonly bool _isMovieNew;

        public ICommand AddMovieCommand { get; }

        #region Mapping

        public string Title
        {
            get { return _movie.Title; }
            set
            {
                if (_movie.Title != value)
                {
                    _movie.Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public long Budget
        {
            get { return _movie.Budget; }
            set
            {
                if (_movie.Budget != value)
                {
                    _movie.Budget = value;
                    OnPropertyChanged(nameof(Budget));
                }
            }
        }

        public int Popularity
        {
            get { return _movie.Popularity; }
            set
            {
                if (_movie.Popularity != value)
                {
                    _movie.Popularity = value;
                    OnPropertyChanged(nameof(Popularity));
                }
            }
        }

        public DateTime ReleaseDate
        {
            get { return _movie.ReleaseDate.ToDateTime(new TimeOnly()); }
            set
            {
                if (_movie.ReleaseDate != new DateOnly(value.Year, value.Month, value.Day))
                {
                    _movie.ReleaseDate = new DateOnly(value.Year, value.Month, value.Day);
                    OnPropertyChanged(nameof(ReleaseDate));
                }
            }
        }

        public long Revenue
        {
            get { return _movie.Revenue; }
            set
            {
                if (_movie.Revenue != value)
                {
                    _movie.Revenue = value;
                    OnPropertyChanged(nameof(Revenue));
                }
            }
        }

        public float VoteAverage
        {
            get { return _movie.VoteAverage; }
            set
            {
                if (_movie.VoteAverage != value)
                {
                    _movie.VoteAverage = value;
                    OnPropertyChanged(nameof(VoteAverage));
                }
            }
        }

        public int VoteCount
        {
            get { return _movie.VoteCount; }
            set
            {
                if (_movie.VoteCount != value)
                {
                    _movie.VoteCount = value;
                    OnPropertyChanged(nameof(VoteCount));
                }
            }
        }

        public string? Overview
        {
            get { return _movie.Overview; }
            set
            {
                if (_movie.Overview != value)
                {
                    _movie.Overview = value;
                    OnPropertyChanged(nameof(Overview));
                }
            }
        }

        public string? Tagline
        {
            get { return _movie.Tagline; }
            set
            {
                if (_movie.Tagline != value)
                {
                    _movie.Tagline = value;
                    OnPropertyChanged(nameof(Tagline));
                }
            }
        }

        public int Uid
        {
            get { return _movie.Uid; }
            set
            {
                if (_movie.Uid != value)
                {
                    _movie.Uid = value;
                    OnPropertyChanged(nameof(Uid));
                }
            }
        }

        public Director Director
        {
            get { return _movie.Director; }
            set
            {
                if (_movie.Director != value)
                {
                    _movie.Director = value;
                    OnPropertyChanged(nameof(Director));
                }
            }
        }

        public ICollectionView DirectorsCollectionView { get; }

        private readonly ObservableCollection<Director> _directors;
        public IEnumerable<Director> Directors => _directors;

        private string _filterText = string.Empty;
        private ApplicationDbContext _context;

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
                DirectorsCollectionView.Refresh();
            }
        }
        #endregion


        public AddMovieViewModel(IMovieService movieService, ApplicationDbContext context, Movie? movie = null)
        {
            _movieService = movieService;
            _context = context;
            AddMovieCommand = new RelayCommand(OnMovieAdd);

            if (movie is not null)
            {
                _movie = movie;
                _isMovieNew = false;
            }
            else
            {
                _movie = new Movie();
                _isMovieNew = true;
            }


            _directors = _context.Directors.Local.ToObservableCollection();

            DirectorsCollectionView = CollectionViewSource.GetDefaultView(_directors);
            DirectorsCollectionView.Filter = FilterDirectors;
        }

        private void OnMovieAdd()
        {
            if (ValueValidationHelper.IsAnyValueNull(
                Title, Budget, Popularity, ReleaseDate, Revenue, VoteAverage, VoteCount, Uid, Director))
            {
                MessageBox.Show("Jedna nebo více povinných hodnot není vyplněna!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(_isMovieNew)
            {
                _movieService.AddMovie(_movie);
                MessageBox.Show("Film přidán", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _movieService.UpdateMovie(_movie);
                MessageBox.Show("Film upraven", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool FilterDirectors(object obj)
        {
            if (obj is Director director)
            {
                return director.Name.Contains(FilterText, StringComparison.InvariantCultureIgnoreCase);
                //|| director.Movies.Any(x => x.Title.Contains(FilterText, StringComparison.InvariantCultureIgnoreCase)); -> filtering also by their movies.

            }

            return false;
        }
    }
}
