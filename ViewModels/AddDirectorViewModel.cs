using MovLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovLib.ViewModels
{
    internal class AddDirectorViewModel : BaseViewModel
    {
        private Director? _director;

        public AddDirectorViewModel(Director? director = null)
        {
            if (director is not null)
            {
                _director = director;
            }
            else
            {
                _director = new Director();
            }
        }
    }
}
