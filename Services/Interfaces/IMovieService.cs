﻿using MovLib.Data.Models;
using System.Collections.Generic;

namespace MovLib.Services.Interfaces
{
    public interface IMovieService
    {
        public void DeleteMovie(Movie movie);
        public void DeleteMovies(List<Movie> movies);
    }
}
