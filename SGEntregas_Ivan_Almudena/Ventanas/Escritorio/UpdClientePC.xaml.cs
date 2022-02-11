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
    /// Lógica de interacción para UpdClientePC.xaml
    /// </summary>
    public partial class UpdClientePC : Window
    {
        CollectionViewModel cvm;
        private clientes cli;
        private clientes copiaCli;

        public UpdClientePC(clientes cli, CollectionViewModel cvm)
        {
            InitializeComponent();
            this.cli = cli;
            MessageBox.Show(cli.provincias.nombre_provincia);
            this.cvm = cvm;
            cargarProvincias();            
            copiaCli = (clientes)cli.Clone();
            //MessageBox.Show(copiaCli.provincias.nombre_provincia);
            this.DataContext = copiaCli;
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            if (txtDniCliente.Text.Length == 10 && !Utils.comprobarVacios(txtNombreCliente.Text)
                && !Utils.comprobarVacios(txtApellCliente.Text)
                && !Utils.comprobarVacios(txtDomicilioCliente.Text)
                && !Utils.comprobarVacios(txtLocalidadCliente.Text)
                && !Utils.comprobarVacios(txtEmailCliente.Text)
                && !Utils.comprobarVacios(cbProvin.Text))
            {
                cli.provincia = cbProvin.SelectedIndex + 1;
                var provin = cvm.objBD.provincias.Find(cbProvin.SelectedIndex + 1);
                cli.provincias = provin;
           

                actualizarProperties(copiaCli, cli);

                MessageBox.Show("Modificado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe rellenar los campos");
            }
        }

        private void cargarProvincias()
        {
            var pro = from pr in cvm.objBD.provincias
                      select pr.nombre_provincia;

            foreach(var provincia in pro.ToList())
            {
                cbProvin.Items.Add(provincia.ToString());
            }
            
        }

        private void actualizarProperties(clientes clienteOrigen, clientes clienteDestino)
        {            
            clienteDestino.dni = clienteOrigen.dni;
            clienteDestino.nombre = clienteOrigen.nombre;
            clienteDestino.apellidos = clienteOrigen.apellidos;
            clienteDestino.email = clienteOrigen.email;
            clienteDestino.domicilio = clienteOrigen.domicilio;
            clienteDestino.localidad = clienteOrigen.localidad;
            clienteDestino.provincia = clienteOrigen.provincia;            

        }
    }
}
