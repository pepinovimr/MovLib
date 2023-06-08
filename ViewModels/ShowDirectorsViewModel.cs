using Microsoft.EntityFrameworkCore;
using MovLib.Commands;
using MovLib.Data.Context;
using MovLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    internal class ShowDirectorsViewModel : BaseViewModel
    {
        private readonly MoviesDbContext _context;

        private readonly ObservableCollection<Director> _directors;

        public ICollectionView DirectorsCollectionView { get; }

        public IEnumerable<Director> Directors => _directors;

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
                DirectorsCollectionView.Refresh();
            }
        }

        public ICommand DeleteCommand { get; }
        public ICommand ChangeCommand { get; }

        public ShowDirectorsViewModel(MoviesDbContext context)
        {
            _context = context;
            //_context.Directors.LoadAsync();
            _directors = _context.Directors.Local.ToObservableCollection();

            DirectorsCollectionView = CollectionViewSource.GetDefaultView(_directors);
            DirectorsCollectionView.Filter = FilterDirectors;
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
