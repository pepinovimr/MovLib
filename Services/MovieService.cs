using MovLib.Data.Context;
using MovLib.Data.Models;
using MovLib.Services.Interfaces;
using System.Collections.Generic;

namespace MovLib.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        public MovieService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void DeleteMovies(List<Movie> movies)
        {
            _context.Movies.RemoveRange(movies);
            _context.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}
