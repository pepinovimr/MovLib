using System;
using MovLib.Data.Models;
using MovLib.Stores;

namespace MovLib.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel
    {
        #region Fields & Properties
        private Movie _movieSource;

        public Movie MovieSource
        {
            get { return _movieSource; }
            set
            {
                if (_movieSource != value)
                {
                    _movieSource = value;
                    OnPropertyChanged(nameof(MovieSource));
                }
            }
        }

        public string Title
        {
            get { return _movieSource.Title; }
            set
            {
                if(_movieSource.Title != value)
                {
                    _movieSource.Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public long Budget
        {
            get { return _movieSource.Budget; }
            set
            {
                if(_movieSource.Budget != value)
                {
                    _movieSource.Budget = value;
                    OnPropertyChanged(nameof(Budget));
                }
            }
        }

        public int Popularity
        {
            get { return _movieSource.Popularity; }
            set
            {
                if(_movieSource.Popularity != value)
                {
                    _movieSource.Popularity = value;
                    OnPropertyChanged(nameof(Popularity));
                }
            }
        }

        public DateOnly ReleaseDate
        {
            get { return _movieSource.ReleaseDate; }
            set {
                if(_movieSource.ReleaseDate != value)
                {
                    _movieSource.ReleaseDate = value; 
                    OnPropertyChanged(nameof(ReleaseDate));
                }
            }
        }

        public long Revenue 
        { 
            get { return _movieSource.Revenue; }
            set
            {
                if(_movieSource.Revenue != value)
                {
                    _movieSource.Revenue = value;
                    OnPropertyChanged(nameof(Revenue));
                }
            }
        }

        public float VoteAverage
        {
            get { return _movieSource.VoteAverage; }
            set
            {
                if(_movieSource.VoteAverage != value)
                {
                    _movieSource.VoteAverage = value;
                    OnPropertyChanged(nameof(VoteAverage));
                }
            }
        }

        public int VoteCount
        {
            get { return _movieSource.VoteCount; }
            set
            {
                if (_movieSource.VoteCount != value)
                {
                    _movieSource.VoteCount = value;
                    OnPropertyChanged(nameof(VoteCount));
                }
            }
        }

        public string? Overview
        {
            get { return _movieSource.Overview; }
            set
            {
                if (_movieSource.Overview != value && value != null)
                {
                    _movieSource.Overview = value;
                    OnPropertyChanged(nameof(Overview));
                }
            }
        }

        public string? Tagline
        {
            get { return _movieSource.Overview; }
            set
            {
                if (_movieSource.Tagline != value && value != null)
                {
                    _movieSource.Tagline = value;
                    OnPropertyChanged(nameof(Tagline));
                }
            }
        }

        public Director Director
        {
            get { return _movieSource.Director; }
            set
            {
                if(_movieSource.Director != value)
                {
                    _movieSource.Director = value;
                    OnPropertyChanged(nameof(Director));
                }
            }
        }
        #endregion
        

        public MovieDetailViewModel(Movie movie, NavigationStore navigationStore)
        {
            _movieSource = movie;
        }
    }
}
