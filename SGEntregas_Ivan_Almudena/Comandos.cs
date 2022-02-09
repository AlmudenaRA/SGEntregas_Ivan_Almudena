using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGEntregas_Ivan_Almudena
{
    public static class Comandos
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
        (
            "Salir",
            "Salir",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Escape)
            }
        );

        public static readonly RoutedUICommand Anadir = new RoutedUICommand
        (
            "Acción cuando se añade un cliente",
            "Añadir",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Modificar = new RoutedUICommand
        (
            "Acción cuando se modifica un cliente",
            "Modificar",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.M, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Eliminar = new RoutedUICommand
        (
            "Acción cuando se elimina un cliente",
            "Eliminar",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand GuardarBD = new RoutedUICommand
        (
            "Acción cuando se guarda en la bd",
            "Guardar en la BD",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.G, ModifierKeys.Control)
            }
        );
    }
}
