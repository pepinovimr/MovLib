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
using System.Windows.Media.Media3D;

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
            services.AddScoped<DirectorService>();
            services.AddScoped<INavigationService, NavigationService<ShowMoviesViewModel>>();
            services.AddScoped<INavigationService, NavigationService<ShowDirectorsViewModel>>();
            services.AddScoped<INavigationService, NavigationService<AddMovieViewModel>>();
            services.AddScoped<INavigationService, NavigationService<AddDirectorViewModel>>();

            services.AddSingleton<MainViewModel>(s => CreateMainViewModel(s));
            services.AddTransient<ShowMoviesViewModel>(s => CreateShowMoviesViewModel(s));
            services.AddTransient<ShowDirectorsViewModel>(s => CreateShowDirectorsViewModel(s));
            services.AddTransient<AddMovieViewModel>(s => CreateAddMovieViewModel(s));
            services.AddTransient<AddDirectorViewModel>(s => CreateAddDirectorViewModel(s));


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
                CreateAddMovieNavigationService(serviceProvider),
                CreateAddDirectorNavigationService(serviceProvider),
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

        private INavigationService CreateAddMovieNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<AddMovieViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<AddMovieViewModel>);
        }

        private INavigationService CreateAddDirectorNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<AddDirectorViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<AddDirectorViewModel>);
        }
        #endregion

        private ShowMoviesViewModel CreateShowMoviesViewModel(IServiceProvider serviceProvider)
        {
            return new ShowMoviesViewModel(
                serviceProvider.GetRequiredService<ApplicationDbContext>(),
                serviceProvider.GetRequiredService<MovieService>(),
                serviceProvider.GetRequiredService<NavigationStore>());
        }

        private ShowDirectorsViewModel CreateShowDirectorsViewModel(IServiceProvider serviceProvider)
        {
            return new ShowDirectorsViewModel(
                serviceProvider.GetRequiredService<ApplicationDbContext>(),
                serviceProvider.GetRequiredService<DirectorService>(),
                serviceProvider.GetRequiredService<NavigationStore>());
        }
        private AddMovieViewModel CreateAddMovieViewModel(IServiceProvider serviceProvider)
        {
            return new AddMovieViewModel(
                serviceProvider.GetRequiredService<MovieService>(),
                serviceProvider.GetRequiredService<ApplicationDbContext>());
        }

        private AddDirectorViewModel CreateAddDirectorViewModel(IServiceProvider serviceProvider)
        {
            return new AddDirectorViewModel(
                serviceProvider.GetRequiredService<DirectorService>(),
                serviceProvider.GetRequiredService<ApplicationDbContext>());
        }
    }
}
