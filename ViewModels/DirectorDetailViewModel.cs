using MovLib.Data.Models;
using MovLib.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovLib.ViewModels
{
    public class DirectorDetailViewModel : BaseViewModel
    {
        #region Fields and properties

        private Director _directorSource;

        public Director DirectorSource
        {
            get { return _directorSource; }
            set
            {
                if (_directorSource != value)
                {
                    _directorSource = value;
                    OnPropertyChanged(nameof(DirectorSource));
                }
            }
        }

        public string Name
        {
            get { return _directorSource.Name; }
            set
            {
                if (_directorSource.Name != value)
                {
                    _directorSource.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public int Gender
        {
            get { return _directorSource.Gender; }
            set
            {
                if (_directorSource.Gender != value)
                {
                    _directorSource.Gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        public Collection<Movie> Movies
        {
            get { return _directorSource.Movies; }
            set
            {
                if (_directorSource.Movies != value)
                {
                    _directorSource.Movies = value;
                    OnPropertyChanged(nameof(Movies));
                }
            }
        }


        #endregion
        public DirectorDetailViewModel(Director director, NavigationStore navigationStore)
        {
            _directorSource = director;
        }
    }
}
