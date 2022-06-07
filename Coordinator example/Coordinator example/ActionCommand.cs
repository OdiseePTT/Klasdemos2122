using System;
using System.Windows.Input;

namespace Coordinator_example
{
    public class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action action;

        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return action != null;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
