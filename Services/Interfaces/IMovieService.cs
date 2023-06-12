using MovLib.Data.Models;
using System.Collections.Generic;

namespace MovLib.Services.Interfaces
{
    public interface IMovieService
    {
        public void DeleteMovies(List<Movie> movies);

        public void AddMovie(Movie movie);
    }
}
