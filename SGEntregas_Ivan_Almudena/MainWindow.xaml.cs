using SGEntregas_Ivan_Almudena.Ventanas.Escritorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGEntregas_Ivan_Almudena
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            abrirVentanaSeleccionarCliente();
        }

        private void abrirVentanaSeleccionarCliente()
        {
            SeleccionarCliente frm = new SeleccionarCliente();
            frm.ShowDialog();
        }
    }
}
