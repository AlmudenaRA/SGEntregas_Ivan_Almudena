using SGEntregas_Ivan_Almudena.Ventanas.Escritorio;
using SGEntregas_Ivan_Almudena.Ventanas.Tablet;
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

namespace SGEntregas_Ivan_Almudena
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void btnTablet_Click(object sender, RoutedEventArgs e)
        {
            ClientesTablet clieTablet = new ClientesTablet();
            this.Close();
            clieTablet.Show();
        }

        private void btnPc_Click(object sender, RoutedEventArgs e)
        {
            MenuPC menu_pc = new MenuPC();
            this.Close();
            menu_pc.Show();
        }

        private void CompruebaExit(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EjecutaExit(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
