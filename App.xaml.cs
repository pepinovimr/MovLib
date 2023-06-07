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

            services.AddSingleton<NavigationStore>();

            services.AddDbContext<MoviesDbContext>();
            //services.AddSingleton<INavigationService>(s => CreateMainNavigationService(s));

            services.AddSingleton<MainViewModel>(s => CreateMainViewModel(s));
            services.AddTransient<ShowMoviesViewModel>();
            services.AddTransient<ShowDirectorsViewModel>();

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

        private MainViewModel CreateMainViewModel(IServiceProvider serviceProvider)
        {
            return new MainViewModel(
                serviceProvider.GetRequiredService<NavigationStore>(),
                CreateShowMoviesNavigationService(serviceProvider),
                CreateShowDirectorsNavigationService(serviceProvider));
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
    }
}
