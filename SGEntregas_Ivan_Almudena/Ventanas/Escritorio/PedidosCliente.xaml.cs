using SGEntregas_Ivan_Almudena.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGEntregas_Ivan_Almudena.Ventanas.Escritorio
{
    /// <summary>
    /// Lógica de interacción para PedidosCliente.xaml
    /// </summary>
    public partial class PedidosCliente : Window
    {
        CollectionViewModel cvm;
        clientes cliente;
        pedidos pedido;
        public PedidosCliente(clientes cli)
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
            this.cliente = cli;
            this.DataContext = cliente;
            this.cvm.CargarPedidosCliente(cliente.dni);
        }

        //public PedidosCliente(CollectionViewModel cvm, clientes cli)
        //{
        //    InitializeComponent();
        //    this.cvm = cvm;
        //    this.cliente = cli;
        //    this.DataContext = cliente;
        //    this.cvm.CargarPedidosCliente(this.cliente.dni);
        //}

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPedido frm = new AddPedido(cvm, cliente);
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if(dgPedidos.SelectedIndex != -1)
            {
                int pos = dgPedidos.SelectedIndex;
                ModificarPedido frm = new ModificarPedido(cvm, cvm.ListaPedidos[pos]);
                frm.ShowDialog();
                dgPedidos.Items.Refresh();
            }
            else
            {
                System.Windows.MessageBox.Show("Seleccione un pedido");
            }
            
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("¿Desea guardar los cambios?", "Guardar", MessageBoxButton.YesNo);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                cvm.GuardarDatos();
                System.Windows.MessageBox.Show("Cambios guardados");
            }
        }

        private void btnElimnar_Click(object sender, RoutedEventArgs e)
        {
            if (dgPedidos.SelectedIndex != -1)
            {

                DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("Estas seguro que desea eliminar el pedido", "Eliminar", MessageBoxButton.YesNo);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    int id_pedido = cvm.ListaPedidos[dgPedidos.SelectedIndex].id_pedido;
                    pedido = cvm.objBD.pedidos.Find(id_pedido);
                    cvm.eliminarPedido(pedido);
                    cvm.ListaPedidos.RemoveAt(dgPedidos.SelectedIndex);
                    System.Windows.MessageBox.Show("Pedido eliminado");
                }
            }
        }
    }
}
