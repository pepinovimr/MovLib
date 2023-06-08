using MovLib.Data.Models;
using System.Collections.Generic;

namespace MovLib.Services.Interfaces
{
    internal interface IDirectorService
    {
        public void DeleteDirector(Director director);
        public void DeleteDirectors(IEnumerable<Director> directors);
    }
}
