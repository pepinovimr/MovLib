using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    class MainViewModel : BaseViewModel
    {
		public ICommand ShowMoviesCommand { get; }
        public ICommand ShowDirectorsCommand { get; }

        public MainViewModel()
        {
            
        }
    }
}
