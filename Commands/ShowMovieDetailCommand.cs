using MovLib.Data.Models;
using MovLib.Services;
using MovLib.ViewModels;

namespace MovLib.Commands
{
    internal class ShowMovieDetailCommand : CommandBase
    {
        private readonly ParameterNavigationService<Movie, MovieDetailViewModel> _navigationService;
        private readonly Movie _movie;

        public ShowMovieDetailCommand(ParameterNavigationService<Movie, MovieDetailViewModel> navigationService, Movie movie)
        {
            _navigationService = navigationService;
            _movie = movie;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_movie);
        }
    }
}
