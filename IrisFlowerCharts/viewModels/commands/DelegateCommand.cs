using System;
using System.Windows.Input;

namespace IrisFlowerCharts.ViewModels.Commands
{
    /// <summary>
    /// Общий класс для WPF-команд в проекте.
    /// </summary>
    class DelegateCommand : ICommand
    {
        private readonly Action<object> execute;

        private readonly Func<object, bool> canExecute;

        public DelegateCommand(Action<object> execute)
            : this(execute, o => true)
        {
        }

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
