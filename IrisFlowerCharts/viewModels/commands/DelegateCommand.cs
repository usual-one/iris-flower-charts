using System;
using System.Windows.Input;

namespace IrisFlowerCharts.ViewModels.Commands
{
    /// <summary>Common command class.</summary>
    /// <inheritdoc cref="ICommand"/>
    class DelegateCommand : ICommand
    {
        /// <summary>Method to be called when the command is invoked.</summary>
        private readonly Action<object> execute;

        /// <summary>Method that determines that the command can execute in its current state.</summary>
        private readonly Func<object, bool> canExecute;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="execute">Method to be called when the command is invoked.</param>
        public DelegateCommand(Action<object> execute)
            : this(execute, o => true)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="execute">Method to be called when the command is invoked.</param>
        /// <param name="canExecute">Method that determines that the command can execute in its current state.</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
