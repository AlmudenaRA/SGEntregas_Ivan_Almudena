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
    }
}
