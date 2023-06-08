using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovLib.Commands
{
    /// <summary>
    /// A basic command that runs a action
    /// </summary>
    internal class RelayCommand : ICommand
    {
        #region Fields
        /// <summary>
        /// The action to run
        /// </summary>
        Action action;

        #endregion

        #region public events
        /// <summary>
        /// The event that is fired when the <see cref="CanExecute(object?)"/> value has changed
        /// </summary>
        public event EventHandler? CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            this.action = action;
        }

        #endregion

        #region Command Methods
        /// <summary>
        /// A relay command can allways execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter) => true;


        /// <summary>
        /// Executes the commands action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            action();
        }

        #endregion
    }
}
