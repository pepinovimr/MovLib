using Microsoft.EntityFrameworkCore;
using MovLib.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovLib.Views
{
    /// <summary>
    /// Interaction logic for ShowMoviesView.xaml
    /// </summary>
    public partial class ShowMoviesView : UserControl
    {
        private readonly MoviesDbContext _context = new();
        private CollectionViewSource movieViewSource;
        public ShowMoviesView()
        {
            InitializeComponent();
            movieViewSource = (CollectionViewSource)FindResource(nameof(movieViewSource));
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Movies.Load();
            movieViewSource.Source = _context.Movies.Local.ToObservableCollection();
        }
    }
}
