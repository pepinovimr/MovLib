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

        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public void DeleteMovies(List<Movie> movies)
        {
            _context.Movies.RemoveRange(movies);
            _context.SaveChanges();
        }
    }
}
