using Microsoft.EntityFrameworkCore;
using MovLib.Commands;
using MovLib.Data.Context;
using MovLib.Services.Interfaces;
using MovLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ApplicationDbContext _context;
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand ShowMoviesCommand { get; }
        public ICommand ShowDirectorsCommand { get; }
        public ICommand AddMovieCommand { get; }
        public ICommand AddDirectorCommand { get; }

        public MainViewModel
            (NavigationStore navigationStore, 
            INavigationService showMoviesNavigationService, 
            INavigationService showDirectorsNavigationService,
            INavigationService addMovieNavigationService,
            INavigationService addDirectorNavigationService,
            ApplicationDbContext context)
        {
            //Probably better to load on startup and wait, then having lags in app bcs of loading
            _context = context;
            _context.Movies.LoadAsync().Wait();
            _context.Directors.LoadAsync().Wait();

            _navigationStore = navigationStore;

            ShowMoviesCommand = new NavigateCommand(showMoviesNavigationService);
            ShowDirectorsCommand = new NavigateCommand(showDirectorsNavigationService);
            AddMovieCommand = new NavigateCommand(addMovieNavigationService);
            AddDirectorCommand = new NavigateCommand(addDirectorNavigationService);

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
