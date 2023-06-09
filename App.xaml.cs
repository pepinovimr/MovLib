using Microsoft.Extensions.DependencyInjection;
using MovLib.Data.Context;
using MovLib.Services;
using MovLib.Services.Interfaces;
using MovLib.Stores;
using MovLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MovLib
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>();

            services.AddSingleton<NavigationStore>();

            services.AddScoped<MovieService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<INavigationService, NavigationService<ShowMoviesViewModel>>();
            services.AddScoped<INavigationService, NavigationService<ShowDirectorsViewModel>>();

            services.AddSingleton<MainViewModel>(s => CreateMainViewModel(s));
            services.AddTransient<ShowMoviesViewModel>(s => CreateShowMoviesViewModel(s));
            services.AddTransient<ShowDirectorsViewModel>();
            services.AddTransient<MovieDetailViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            MainWindow.Show();

            //CreateShowMoviesNavigationService(_serviceProvider).Navigate();

            base.OnStartup(e);
        }

        #region MainViewModel
        private MainViewModel CreateMainViewModel(IServiceProvider serviceProvider)
        {
            return new MainViewModel(
                serviceProvider.GetRequiredService<NavigationStore>(),
                CreateShowMoviesNavigationService(serviceProvider),
                CreateShowDirectorsNavigationService(serviceProvider),
                serviceProvider.GetRequiredService<ApplicationDbContext>());
        }

        private INavigationService CreateShowMoviesNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ShowMoviesViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<ShowMoviesViewModel>);
        }

        private INavigationService CreateShowDirectorsNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ShowDirectorsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<ShowDirectorsViewModel>);
        }
        #endregion
        #region ShowMoviesViewModel

        private ShowMoviesViewModel CreateShowMoviesViewModel(IServiceProvider serviceProvider)
        {
            return new ShowMoviesViewModel(
                serviceProvider.GetRequiredService<ApplicationDbContext>(),
                serviceProvider.GetRequiredService<MovieService>(),
                CreateMovieDetailNavigationService(serviceProvider));
        }

        private INavigationService CreateMovieDetailNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<MovieDetailViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<MovieDetailViewModel>);
        }

        #endregion
    }
}
