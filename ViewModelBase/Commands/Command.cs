using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelBase.Commands
{
    public class Command : CommandBaseClass
    {
        #region Fields
        /// <summary>
        /// Delegate that points at the method, 
        /// which controlls the posibility of Execute execution.
        /// If returns ture Execute will be executed.
        /// </summary>
        private Func<object, bool> m_CanExecute;

        /// <summary>
        /// Delegate that points at the method, which will be executed.
        /// </summary>
        private Action<object> m_Execute;

        #endregion

        #region Properties
        /// <summary>
        /// Delegate that points at the method, 
        /// which controlls the posibility of Execute execution.
        /// If returns ture Execute will be executed.
        /// </summary>
        public Func<object, bool> CanExecuteProp { get => m_CanExecute; }

        /// <summary>
        /// Delegate that points at the method, which will be executed.
        /// </summary>
        public Action<object> ExecuteProp { get => m_Execute; }

        #endregion

        #region Ctor
        /// <summary>
        /// Initializes an instance of the Command Class
        /// </summary>
        /// <param name="canExecute">Method that controlls the execution of the Execute</param>
        /// <param name="execute">Method tha will be executed</param>
        /// <exception cref="ArgumentNullException">Will be thrown if execute parametr is null</exception>
        public Command(Func<object, bool> canExecute,
            Action<object> execute)
        {
            m_Execute = execute ?? throw new ArgumentNullException(nameof(execute));

            m_CanExecute = canExecute;
        }

        #endregion

        #region Methods
       
        public override bool CanExecute(object? parameter) => m_CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter) => m_Execute.Invoke(parameter);

        #endregion
    }
}
