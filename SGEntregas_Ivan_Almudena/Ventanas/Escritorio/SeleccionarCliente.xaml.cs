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
        ArrayList id_clientes = new ArrayList();
        public SeleccionarCliente()
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
            CargarComboClientes();
        }

        private void CargarComboClientes()
        {
            using (entregasEntities objBD = new entregasEntities())
            {
                var q = from e in objBD.clientes
                        select e;

                foreach (var e in q.ToList())
                {
                    cmbUsuarios.Items.Add(e.nombre + " " + e.apellidos);
                    id_clientes.Add(e.dni);
                }
            }
        }

        private void cmbUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
