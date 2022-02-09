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
        public PedidosCliente(CollectionViewModel cvm, string nombre_apellidos)
        {
            InitializeComponent();
            this.cvm = cvm;
            txtNyA.Text = nombre_apellidos;
        }
    }
}
