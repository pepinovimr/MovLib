using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovLib.Services.Interfaces
{
    public interface IParameterNavigationService<TParameter>
    {
        public void Navigate(TParameter parameter);
    }
}
