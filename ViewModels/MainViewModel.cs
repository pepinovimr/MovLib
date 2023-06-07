using MovLib.Commands;
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
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public ICommand ShowMoviesCommand { get; }
        public ICommand ShowDirectorsCommand { get; }

        public MainViewModel(NavigationStore navigationStore, INavigationService showMoviesNavigationService, INavigationService showDirectorsNavigationService)
        {
            _navigationStore = navigationStore;

            ShowMoviesCommand = new NavigateCommand(showMoviesNavigationService);
            ShowDirectorsCommand = new NavigateCommand(showDirectorsNavigationService);

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
