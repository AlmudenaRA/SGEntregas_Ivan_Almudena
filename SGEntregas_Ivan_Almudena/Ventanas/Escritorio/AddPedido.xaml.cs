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
    /// Lógica de interacción para AddPedido.xaml
    /// </summary>
    public partial class AddPedido : Window
    {
        CollectionViewModel cvm;
        clientes cliente;
        public AddPedido(CollectionViewModel cvm, clientes cliente)
        {
            InitializeComponent();
            this.cvm = cvm;
            this.cliente = cliente;
            dtpFechaPedido.SelectedDate = DateTime.Now.Date;
            dtpFechaPedido.DisplayDate = DateTime.Now.Date;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string desc = new TextRange(txtDescripcion.Document.ContentStart, txtDescripcion.Document.ContentEnd).Text;
            if (!String.IsNullOrWhiteSpace(desc) && !Utils.comprobarVacios(dtpFechaPedido.SelectedDate.ToString()))
            {                
                pedidos newPedido = (new pedidos()
                {
                    cliente = this.cliente.dni,
                    fecha_pedido = (DateTime)dtpFechaPedido.SelectedDate,
                    descripcion = desc
                });

                cvm.objBD.pedidos.Add(newPedido);
                cvm.ListaPedidos.Add(newPedido);

                System.Windows.MessageBox.Show("Insertado correctamente", "EXITO");
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Debe rellenar los campos");
            }
            
        }

        //private void btnBorrar_Click(object sender, RoutedEventArgs e)
        //{
        //    firmaCanvas.Strokes.Clear();
        //}
    }
}
