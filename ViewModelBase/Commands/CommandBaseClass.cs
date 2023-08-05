using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModelBase.Commands
{
    public abstract class CommandBaseClass : ICommand
    {
        #region Events

        /// <summary>
        /// Event that controlls executing of the method Execute 
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;

            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Controlls wether execute can be executed
        /// </summary>
        /// <param name="parameter">External parametr(can be taken form Frontend)</param>
        /// <returns>True, if Execute should be executed</returns>
        public abstract bool CanExecute(object? parameter);
        /// <summary>
        /// Code that will be executed
        /// </summary>
        /// <param name="parameter">External parametr(can be taken form Frontend)</param>
        public abstract void Execute(object? parameter);
        
        #endregion


    }
}
