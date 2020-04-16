using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace npcGenerator.Model
{
    public class RelayCommand : ICommand // Интерфейс, обеспечивающий поведение команд
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        private Page viewModel;

        public event EventHandler CanExecuteChanged // Вызывается при изменении условий
        {
            add { CommandManager.RequerySuggested += value; } // Методы, обработчики событий
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) // Action<object> - Делегат
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) // Может ли команда выполниться?
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter) // Выполняет логику команды
        {
            execute(parameter);
        }
    }
}
