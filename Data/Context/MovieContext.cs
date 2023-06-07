using Microsoft.EntityFrameworkCore;
using MovLib.Data.Models;
using System;
using System.IO;

namespace MovLib.Data.Context
{
    /// <summary>
    /// Context of SQLite Movies database
    /// </summary>
    public class MoviesDbContext : DbContext
    {
        /// <summary>
        /// Represents a movies table
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
        /// <summary>
        /// Represents a Directors table
        /// </summary>
        public DbSet<Director> Directors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? baseDirPath = (Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName) 
                ?? throw new FileNotFoundException("Couldn't find path of this program");

            string databasePath = Path.Combine(baseDirPath, "Data","Database","Movies.sqlite");

            optionsBuilder.UseSqlite(@"Data Source="+ databasePath);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
