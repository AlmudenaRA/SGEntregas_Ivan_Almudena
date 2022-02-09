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
using System.Windows.Shapes;

namespace SGEntregas_Ivan_Almudena
{
    /// <summary>
    /// Lógica de interacción para MenuPC.xaml
    /// </summary>
    public partial class MenuPC : Window
    {
        public MenuPC()
        {
            InitializeComponent();
        }

        private void btnGestCliente_Click(object sender, RoutedEventArgs e)
        {
            GestionClientesPC gestCliPC = new GestionClientesPC();
            gestCliPC.ShowDialog();
        }

        private void btnGestPedido_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarCliente frm = new SeleccionarCliente();
            frm.ShowDialog();
        }
    }
}
