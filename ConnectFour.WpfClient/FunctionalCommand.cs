using System;
using System.Windows.Input;

namespace ConnectFour.WpfClient
{
    public class FunctionalCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public FunctionalCommand(Action execute) : this(execute, ReturnTrue) 
        {
            
        }

        public FunctionalCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            if (canExecute == null) throw new ArgumentNullException("canExecute");

            _execute = execute;
            _canExecute = canExecute;
        }

        private static bool ReturnTrue()
        {
            return true;
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}