using MovLib.Commands;
using MovLib.Data.Context;
using MovLib.Data.Models;
using MovLib.Helpers;
using MovLib.Services;
using MovLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MovLib.ViewModels
{
    internal class AddDirectorViewModel : BaseViewModel
    {
        IDirectorService _directorService;
        private Director _director;
        private readonly bool _isDirectorNew;
        private ApplicationDbContext _context;
        public ICommand AddDirectorCommand { get; }
        public List<int> Genders { get; set; }

        #region Mapping

        public string Name
        {
            get { return _director.Name; }
            set
            {
                if (_director.Name != value && value is not null)
                {
                    _director.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public int Gender
        {
            get { return _director.Gender; }
            set
            {
                if (_director.Gender != value)
                {
                    _director.Gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        public int Uid
        {
            get { return _director.Uid; }
            set
            {
                if (_director.Uid != value)
                {
                    _director.Uid = value;
                    OnPropertyChanged(nameof(Uid));
                }
            }
        }

        public string Department
        {
            get { return _director.Department; }
            set
            {
                if (_director.Department != value && value is not null)
                {
                    _director.Department = value;
                    OnPropertyChanged(nameof(Department));
                }
            }
        }

        #endregion

        public AddDirectorViewModel(IDirectorService directorService, ApplicationDbContext context, Director? director = null)
        {
            _directorService = directorService;
            _context = context;
            AddDirectorCommand = new RelayCommand(OnDirectorAdd);

            if (director is not null)
            {
                _director = director;
                _isDirectorNew = false;
            }
            else
            {
                _director = new Director();
                _director.Department = "Directing";
                _isDirectorNew = true;
            }

            Init();
        }
        private void OnDirectorAdd()
        {
            if (ValueValidationHelper.IsAnyValueNull(
                Name, Gender, Uid, Department))
            {
                MessageBox.Show("Jedna nebo více povinných hodnot není vyplněna!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_isDirectorNew)
            {
                _directorService.AddDirector(_director);
                MessageBox.Show("Režisér přidán", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _directorService.UpdateDirector(_director);
                MessageBox.Show("Režisér upraven", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Init()
        {
            Genders = new()
            {
                0,
                1,
                2
            };
        }
    }
}
