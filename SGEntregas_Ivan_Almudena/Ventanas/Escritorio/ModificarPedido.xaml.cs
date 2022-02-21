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

namespace SGEntregas_Ivan_Almudena.Ventanas.Escritorio
{
    /// <summary>
    /// Lógica de interacción para ModificarPedido.xaml
    /// </summary>
    public partial class ModificarPedido : Window
    {
        CollectionViewModel cvm;
        pedidos pedido;
        pedidos copiaPedido;

        public ModificarPedido(CollectionViewModel cvm, pedidos ped)
        {
            InitializeComponent();
            this.cvm = cvm;
            this.pedido = ped;
            copiaPedido = pedidos.ShallowCopyEntity(pedido);
            this.DataContext = copiaPedido;
            if (this.pedido.fecha_entrega != null)
            {
                dtpFechaPedido.IsEnabled = false;
                txtDescripcion.IsEnabled= false;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (!Utils.comprobarVacios(txtDescripcion.Text) && !Utils.comprobarVacios(dtpFechaPedido.SelectedDate.ToString()))
            {
                actualizarProperties(copiaPedido, pedido);

                MessageBox.Show("Modificado correctamente");
                this.Close();
            }
        }

        private void actualizarProperties(pedidos pedidoOrigen, pedidos pedidoDestino)
        {
            pedidoDestino.fecha_pedido = pedidoOrigen.fecha_pedido;
            pedidoDestino.descripcion = pedidoOrigen.descripcion;            


        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
