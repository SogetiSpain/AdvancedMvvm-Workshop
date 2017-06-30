/*
 * Cuando se utiliza MVVM, los comandos tienden a utilizar una implementación
 * única y reutilizable que nos permite manejar acciones con métodos estándar
 * directamente en el modelo de vista. Esto nos permite usar comandos sin tener
 * que crear una clase separada para cada uno. Hay un número de variaciones de
 * este comando, pero su forma más simple se muestra aquí:
 * 
 * https://msdn.microsoft.com/en-us/magazine/dd419663.aspx
 *
 * El crédito completo para este comando personalizado se debe a Josh Smith,
 * ya que fue la primera implementación.
 * 
 */
namespace SogetiSpain.AdvancedMvvmWorkshop
{
    using System;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> action) : this(action, null)
        {
        }

        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            /*
             * El evento CommandManager.RequerySuggested se elevará cuando el
             * CommandManager detecta un cambio en la interfaz de usuario que
             * podría reflejar si un comando podría ejecutarse o no. Por ejemplo,
             * esto podría deberse a una interacción del usuario, como la selección
             * de un elemento en una colección o algún otro cambio de enfoque.
             * 
             */
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}