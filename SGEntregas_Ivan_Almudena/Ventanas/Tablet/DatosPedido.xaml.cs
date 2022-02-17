using SGEntregas_Ivan_Almudena.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para DatosPedido.xaml
    /// </summary>
    public partial class DatosPedido : Window
    {
        CollectionViewModel cvm;
        pedidos pedido;
        pedidos copiaPedido;
        byte[] dibujoCanvas;

        public DatosPedido(CollectionViewModel cvm, pedidos ped)
        {
            InitializeComponent();
            this.cvm = cvm;
            this.pedido = ped;
            copiaPedido = pedidos.ShallowCopyEntity(pedido);
            this.DataContext = copiaPedido;
        }

        private void actualizarProperties(pedidos pedidoOrigen, pedidos pedidoDestino)
        {
            pedidoDestino.fecha_pedido = pedidoOrigen.fecha_pedido;
            pedidoDestino.descripcion = pedidoOrigen.descripcion;
            pedidoDestino.fecha_entrega = DateTime.Now;
            pedidoDestino.firma = pedidoOrigen.firma;
            this.cvm.objBD.SaveChanges();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            firmaCanvas.Strokes.Clear();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            dibujoCanvas = InkCanvasToByte(firmaCanvas);
            if (!Utils.comprobarVacios(txtDescripcion.Text) && !Utils.comprobarVacios(dtpFechaPedido.SelectedDate.ToString()) && dibujoCanvas != null)
            {
                actualizarProperties(copiaPedido, pedido);
                MessageBox.Show("Modificado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Rellene todo los datos necesarios");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private byte[] InkCanvasToByte(InkCanvas canvas)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (canvas.Strokes.Count > 0)
                {
                    canvas.Strokes.Save(ms, true);
                    byte[] unencryptedSignature = ms.ToArray();
                    return unencryptedSignature;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
