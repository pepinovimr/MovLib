using MovLib.Data.Context;
using MovLib.Data.Models;
using MovLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    internal class ShowDirectorsViewModel : BaseViewModel
    {
        private readonly ApplicationDbContext _context;

        private readonly IDirectorService _directorService;

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

        private ObservableCollection<Director> _selectedItems = new();

        public ObservableCollection<Director> SelectedItems
        {
            get { return _selectedItems; }
            set
            {
                _selectedItems = value;
                OnPropertyChanged(nameof(SelectedItems));
            }
        }

        //TODO: Figure out what to do with movies of deleted Directors
        public ICommand DeleteCommand { get; }
        public ICommand ChangeCommand { get; }

        public ShowDirectorsViewModel(ApplicationDbContext context, IDirectorService directorService)
        {
            _context = context;

            _directorService = directorService;

            _directors = _context.Directors.Local.ToObservableCollection();

            SelectedItems = new();

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

        private void OnDirectorDelete()
        {
            if (_selectedItems.Count < 1)
            {
                MessageBox.Show("Nejdříve vyberte záznam ke smazání", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _directorService.DeleteDirectors(_selectedItems.ToList());
        }
    }
}
