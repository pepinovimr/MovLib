using MovLib.Data.Context;
using MovLib.Data.Models;
using MovLib.Services.Interfaces;
using System.Collections.Generic;

namespace MovLib.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly ApplicationDbContext _context;
        public DirectorService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public void DeleteDirector(Director director)
        {
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }

        public void DeleteDirectors(IEnumerable<Director> directors)
        {
            _context.Directors.RemoveRange(directors);
            _context.SaveChanges();
        }
    }
}
