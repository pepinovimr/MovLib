using MovLib.Data.Models;
using System.Collections.Generic;

namespace MovLib.Services.Interfaces
{
    public interface IDirectorService
    {
        public void DeleteDirectors(IEnumerable<Director> directors);

        public void AddDirector(Director director);

        public void UpdateDirector(Director director);
    }
}
