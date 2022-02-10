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
    /// Lógica de interacción para PedidosCliente.xaml
    /// </summary>
    public partial class PedidosCliente : Window
    {
        CollectionViewModel cvm;
        clientes cliente;
        //public PedidosCliente(string nombre_apellidos, string dni)
        //{
        //    InitializeComponent();
        //    cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
        //    txtNyA.Text = nombre_apellidos;
        //    this.cvm.CargarPedidosCliente(dni);
        //}

        public PedidosCliente(CollectionViewModel cvm, clientes cli)
        {
            InitializeComponent();
            this.cvm = cvm;
            this.cliente = cli;
            this.DataContext = cliente;
            this.cvm.CargarPedidosCliente(this.cliente.dni);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPedido frm = new AddPedido();
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            ModificarPedido frm = new ModificarPedido();
            frm.ShowDialog();
        }
    }
}
