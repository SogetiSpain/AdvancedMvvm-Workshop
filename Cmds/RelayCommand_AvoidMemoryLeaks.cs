/*
 * Una de las causas más comunes de pérdidas de memoria que aparecen en una aplicación
 * es la no eliminación de los manejadores de eventos una vez que los objetos ya no
 * son necesarios. Cuando suscribimos un manejador de eventos al evento de un objeto de
 * la forma habitual, estamos pasando efectivamente a ese objeto una referencia al
 * manejador y creando una referencia fuerte a él.
 * 
 * Cuando el objeto ya no es necesario y podría eliminarse, la referencia en el objeto
 * que dispara el evento evitará que se produzca. Esto se debe a que el recolector de
 * elementos no puede recopilar un objeto al que se pueda acceder desde cualquier parte
 * del código de la aplicación. En el peor de los casos, el objeto que se mantiene vivo
 * puede contener muchos otros objetos y así por inadvertencia mantenerlos vivos también.
 * 
 * El problema con esto es que mantener los objetos vivos después de que ya no se necesitan
 * aumentará innecesariamente la huella de la memoria de la aplicación, en algunos casos,
 * con consecuencias dramáticas e irreversibles, dando lugar a una excepción OutOfMemory
 * que se está lanzando. Por lo tanto, es esencial que quitemos antes nuestros manejadores
 * de eventos de los eventos a los que están suscritos en los objetos que no tenemos más en
 * uso para tratar de liberarlos.
 * 
 * Sin embargo, existe un método alternativo que podemos utilizar para evitar esta situación.
 * En .NET Framework, hay una clase WeakReference y se puede utilizar para quitar las
 * referencias fuertes causadas por suscribir manejadores de eventos a eventos que utilizan
 * el método tradicional.
 * 
 * La idea básica es que la clase que dispara el evento debe mantener una colección de
 * instancias WeakReference y agregarlas a dicha colección cada vez que otra clase suscriba
 * un manejador de eventos al evento.
 */
namespace SogetiSpain.AdvancedMvvmWorkshop
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<object> canExecute;
        private List<WeakReference> eventHandlers = new List<WeakReference>();

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
            add
            {
                eventHandlers.Add(new WeakReference(value));
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                if (eventHandlers == null)
                {
                    return;
                }

                for (int i = eventHandlers.Count - 1; i >= 0; i--)
                {
                    WeakReference weakReference = eventHandlers[i];
                    EventHandler handler = weakReference.Target as EventHandler;
                    if (handler == null || handler == value)
                    {
                        eventHandlers.RemoveAt(i);
                    }
                }

                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            eventHandlers.ForEach(r =>
                (r.Target as EventHandler)?.Invoke(this, new EventArgs()));
        }
    }
}