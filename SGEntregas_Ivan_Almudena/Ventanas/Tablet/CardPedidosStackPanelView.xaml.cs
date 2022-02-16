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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGEntregas_Ivan_Almudena.Ventanas.Tablet
{
    /// <summary>
    /// Lógica de interacción para CardPedidosStackPanelView.xaml
    /// </summary>
    public partial class CardPedidosStackPanelView : UserControl
    {
        CollectionViewModel cvm;
        clientes cliente;
        TarjetPedido tp;

        public CardPedidosStackPanelView(clientes cli)
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
            this.cliente = cli;
            this.DataContext = cli.pedidos;
            cargarTarjet();
        }


        private void cargarTarjet()
        {
            var pedi = from pe in cvm.objBD.pedidos
                       select pe;

            foreach (var item in pedi.ToList())
            {
                if(item.fecha_entrega != null)
                {
                    tp = new TarjetPedido();
                    tp.FechaPedido = item.fecha_pedido;
                    tp.FechaEntrega = item.fecha_entrega;
                    tp.Descripcion = item.descripcion;

                    listaPedidosCli.Children.Add(tp);
                }
                    
            }

        }
    }
}
