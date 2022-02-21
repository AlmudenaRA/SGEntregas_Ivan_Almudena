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
    /// Lógica de interacción para AddClientesPC.xaml
    /// </summary>
    public partial class AddClientesPC : Window
    {
        CollectionViewModel cvm;

        public AddClientesPC(CollectionViewModel cvm)
        {
            InitializeComponent();
            this.cvm = cvm;
            cargarProvincias();
        }

        private void cargarProvincias()
        {
            var provin = from pro in cvm.objBD.provincias
                      select pro.nombre_provincia;

            foreach (var provincia in provin.ToList())
            {
                cbProvin.Items.Add(provincia.ToString());
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {           
            //comprobar formato dni
            if (Utils.validarFormatoDni(txtDniCliente.Text)){
                //Comprueba que no exista ese dni en la bbdd
                var cliente = cvm.objBD.clientes.Find(txtDniCliente.Text.ToUpper());

                if (cliente == null)
                {
                   if (!Utils.comprobarVacios(txtNombreCliente.Text)
                   && !Utils.comprobarVacios(txtApellCliente.Text)
                   && !Utils.comprobarVacios(txtDomicilioCliente.Text)
                   && !Utils.comprobarVacios(txtLocalidadCliente.Text)
                   && !Utils.comprobarVacios(cbProvin.Text))
                    {
                        clientes objCliente = new clientes()
                        {
                            dni = txtDniCliente.Text,
                            nombre = txtNombreCliente.Text,
                            apellidos = txtApellCliente.Text,
                            localidad = txtLocalidadCliente.Text,
                            email = txtEmailCliente.Text,
                            domicilio = txtDomicilioCliente.Text,
                            provincia = cbProvin.SelectedIndex + 1

                        };

                        objCliente.provincia = cbProvin.SelectedIndex + 1;
                        var provin = cvm.objBD.provincias.Find(cbProvin.SelectedIndex + 1);
                        objCliente.provincias = provin;

                        //Lo guarda en la lista de la tabla clientes de la conexion 
                        cvm.objBD.clientes.Add(objCliente);
                        //Lo guarda en la lista observable que tienen el binding
                        cvm.ListaClientes.Add(objCliente);
                        MessageBox.Show("Insertado correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Debe rellenar los campos obligatorios", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario ya registrado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
            else
            {
                MessageBox.Show("El formato del dni no es correcto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
