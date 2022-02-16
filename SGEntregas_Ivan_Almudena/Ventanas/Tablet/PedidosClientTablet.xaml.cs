using SGEntregas_Ivan_Almudena.Components;
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
    /// Lógica de interacción para PedidosClientTablet.xaml
    /// </summary>
    public partial class PedidosClientTablet : Window
    {
        //CollectionViewModel cvm;        
        //clientes cliente;
        //pedidos ped;
        //TarjetPedido tp;
        //string cli;
        //public PedidosClientTablet(clientes cli)
        //{
        //    InitializeComponent();
        //    cvm = cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
        //    this.cliente = cli;
        //    this.DataContext = cliente.pedidos;
        //    cargarTarjet();
        //}

        public PedidosClientTablet()
        {
            InitializeComponent();
            //cvm = cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
            //this.cliente = cli;
            //this.DataContext = ped;
            //cargarTarjet();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void cargarTarjet()
        //{
        //    var pedi = from pe in cvm.objBD.pedidos
        //               select pe;

        //    foreach (var item in pedi.ToList())
        //    {
        //        if (item.fecha_entrega != null)
        //        {
        //            tp = new TarjetPedido();
        //            tp.FechaPedido = item.fecha_pedido;
        //            tp.FechaEntrega = item.fecha_entrega;
        //            tp.Descripcion = item.descripcion;

        //            listaPedidosCli.Children.Add(tp);
        //        }

        //    }

        //}

    }
}

