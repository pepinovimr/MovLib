using MovLib.Services.Interfaces;
using MovLib.Stores;
using MovLib.ViewModels;
using System;

namespace MovLib.Services
{
    public class ParameterNavigationService<TParameter, TViewModel> : IParameterNavigationService<TParameter>
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TParameter, TViewModel> _createViewModel;

        public ParameterNavigationService(NavigationStore navigationStore, Func<TParameter, TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParameter parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}
