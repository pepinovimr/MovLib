using MovLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovLib.ViewModels
{
    class MovieViewModel : BaseViewModel
    {
        private readonly Movie _movie;

        public string Title => _movie.title;
        public string Overview => _movie.overview;
        public float VoteAverage => _movie.vote_average;
        public float VoteCount => _movie.vote_count;
        public string OriginalTitle => _movie.original_title;
        public long Budget => _movie.budget;
        public int Popularity => _movie.popularity;
        public DateOnly ReleaseDate => _movie.release_date;
        public long Revenue => _movie.revenue;
        public string? TagLine => _movie.tagline;
        public Director Director => _movie.Director;

        public MovieViewModel(Movie movie)
        {
            _movie = movie;
        }
    }
}
