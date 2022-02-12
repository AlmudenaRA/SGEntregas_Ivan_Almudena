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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGEntregas_Ivan_Almudena.Ventanas.Escritorio
{
    /// <summary>
    /// Lógica de interacción para GestionClientesPC.xaml
    /// </summary>
    public partial class GestionClientesPC : Window
    {
        CollectionViewModel cvm;

        public GestionClientesPC()
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
        }

        private void CompruebaAnadir(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EjecutaAnadir(object sender, ExecutedRoutedEventArgs e)
        {
            AddClientesPC addClien = new AddClientesPC(cvm);
            addClien.ShowDialog();
            
            //listaClien.Items.Refresh();
        }

        private void CompruebaModificar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaClien.SelectedIndex != -1)
            {
                e.CanExecute = true;
            }
        }

        private void EjecutaModificar(object sender, ExecutedRoutedEventArgs e)
        {
            int pos = listaClien.SelectedIndex;
            UpdClientePC updCliente = new UpdClientePC(cvm.ListaClientes[pos], cvm);
            updCliente.ShowDialog();
        }

        private void CompruebaEliminar(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaClien.SelectedIndex != -1)
            {
                e.CanExecute = true;
                btnEliminar.IsEnabled = true;
            }
        }

        private void EjecutaEliminar(object sender, ExecutedRoutedEventArgs e)
        {
            clientes objCliente = new clientes();
            string dniCliente = cvm.ListaClientes[listaClien.SelectedIndex].dni;
            objCliente = cvm.objBD.clientes.Find(dniCliente);

            //Antes de eliminar comprueba que no tenga pedidos
            if (objCliente.pedidos.Count > 0)
            {
                DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("¿Desea eliminar el cliente y sus pedidos?", "Eliminar",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    while (objCliente.pedidos.Count > 0)
                    {
                        var pedido = (pedidos)objCliente.pedidos.First();
                        cvm.objBD.pedidos.Remove(pedido);
                    }

                    cvm.objBD.clientes.Remove(objCliente);
                    cvm.ListaClientes.RemoveAt(listaClien.SelectedIndex);
                    System.Windows.MessageBox.Show("Cliente eliminado");
                }
            }
            else
            {
                DialogResult dr = (DialogResult)System.Windows.MessageBox.Show("¿Desea eliminar el cliente?", "Eliminar",
                    MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    cvm.objBD.clientes.Remove(objCliente);
                    cvm.ListaClientes.RemoveAt(listaClien.SelectedIndex);
                    System.Windows.MessageBox.Show("Cliente eliminado");
                }
            }
        }

        private void CompruebaGuardarBD(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EjecutaGuardarBD(object sender, ExecutedRoutedEventArgs e)
        {
            cvm.guardarDatos();
            System.Windows.MessageBox.Show("Guardado en BD");
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
