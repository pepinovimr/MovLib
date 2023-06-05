using Microsoft.EntityFrameworkCore;
using MovLib.Commands;
using MovLib.Data.Context;
using MovLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    internal class ShowDirectorsViewModel : BaseViewModel
    {
        private readonly MoviesDbContext _context = new();

        private readonly ObservableCollection<Director> _directors;

        public IEnumerable<Director> Directors => _directors;

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

        public ShowDirectorsViewModel()
        {
            _context.Directors.Load();
            _directors = _context.Directors.Local.ToObservableCollection();
            DeleteCommand = new DeleteMovieCommand();
        }
    }
}
