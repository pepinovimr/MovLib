﻿using MovLib.Commands;
using MovLib.Data.Context;
using MovLib.Data.Models;
using MovLib.Services;
using MovLib.Services.Interfaces;
using MovLib.Stores;
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
    public class ShowDirectorsViewModel : BaseViewModel
    {
        private readonly ApplicationDbContext _context;

        private readonly IDirectorService _directorService;

        private readonly NavigationStore _navigationStore;

        private ParameterNavigationService<Director, DirectorDetailViewModel> _directorDetailNavigationService;
        private ParameterNavigationService<Director, AddDirectorViewModel> _changeDirectorNavigationService;

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

        public ICommand DeleteCommand { get; }
        public ICommand ChangeCommand { get; }
        public ICommand ShowDetailCommand { get; }

        public ShowDirectorsViewModel(ApplicationDbContext context, IDirectorService directorService, NavigationStore navigationStore)
        {
            _context = context;
            _directorService = directorService;
            _navigationStore = navigationStore;
            _directors = _context.Directors.Local.ToObservableCollection();

            SelectedItems = new();

            DirectorsCollectionView = CollectionViewSource.GetDefaultView(_directors);
            DirectorsCollectionView.Filter = FilterDirectors;

            ShowDetailCommand = new RelayCommand(OnShowDirectorDetail);
            DeleteCommand = new RelayCommand(OnDirectorDelete);
            ChangeCommand = new RelayCommand(OnChangeDirector);
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

        private void OnShowDirectorDetail()
        {
            _directorDetailNavigationService = new ParameterNavigationService<Director, DirectorDetailViewModel>(
                _navigationStore,
                (parameter) => new DirectorDetailViewModel(_selectedItems.First(), _navigationStore));

            _directorDetailNavigationService.Navigate(_selectedItems.First());
        }

        private void OnChangeDirector()
        {
            _changeDirectorNavigationService = new ParameterNavigationService<Director, AddDirectorViewModel>(
                _navigationStore,
                (parameter) => new AddDirectorViewModel(_directorService, _context, _selectedItems.First()));

            _changeDirectorNavigationService.Navigate(_selectedItems.First());
        }
    }
}
