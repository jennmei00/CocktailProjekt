using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class UserCommand : ICommand
    {
        private readonly Action<object> action;  // ist nur im Kostruktor veränderbar
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null) action(parameter);
            else
            {
                parameter = new object();
                action(parameter);
            }
        }

        public event EventHandler CanExecuteChanged;
        public UserCommand(Action<object> action)
        {
            this.action = action;
        }
    }
}
