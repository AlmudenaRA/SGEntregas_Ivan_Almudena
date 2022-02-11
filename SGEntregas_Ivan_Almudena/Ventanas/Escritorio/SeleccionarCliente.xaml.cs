using SGEntregas_Ivan_Almudena.ViewModel;
using System;
using System.Collections;
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
    /// Lógica de interacción para SeleccionarCliente.xaml
    /// </summary>
    public partial class SeleccionarCliente : Window
    {
        CollectionViewModel cvm;

        public SeleccionarCliente()
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
            CargarComboClientes();
        }

        private void CargarComboClientes()
        {
            var q = from e in cvm.objBD.clientes
                    orderby e.apellidos, e.nombre
                    select e;

            foreach (var e in q.ToList())
            {
                cmbUsuarios.Items.Add(e.apellidos + ", " + e.nombre);                
            }
            
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVerPedidos_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsuarios.SelectedIndex != -1)
            {
                PedidosCliente frm = new PedidosCliente(cvm.ListaClientes[cmbUsuarios.SelectedIndex]);
                //PedidosCliente frm = new PedidosCliente(cvm, cvm.ListaClientes[cmbUsuarios.SelectedIndex]);
                frm.ShowDialog();
            }
        }
    }
}
