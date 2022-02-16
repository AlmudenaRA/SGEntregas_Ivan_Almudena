using SGEntregas_Ivan_Almudena.ViewModel;
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

namespace SGEntregas_Ivan_Almudena.Ventanas.Tablet
{
    /// <summary>
    /// Lógica de interacción para ClientesTablet.xaml
    /// </summary>
    public partial class ClientesTablet : Window
    {
        CollectionViewModel cvm;

        public ClientesTablet()
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            if(listaClien.SelectedIndex != -1)
            {
                //var provin = cvm.objBD.provincias.Find(cbProvin.SelectedIndex + 1);
                string dni = cvm.ListaClientes[listaClien.SelectedIndex].dni;
                //CardPedidosStackPanelView cpv = CardPedidosStackPanelView(cvm.ListaClientes[listaClien.SelectedIndex]);
                PedidosClientTablet pedidosTab = new PedidosClientTablet(dni);
                pedidosTab.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente");
            }
        }
    }
}
