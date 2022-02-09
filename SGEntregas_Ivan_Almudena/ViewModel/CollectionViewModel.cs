using SGEntregas_Ivan_Almudena.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SGEntregas_Ivan_Almudena.ViewModel
{
    public class CollectionViewModel : INotifyPropertyChanged
    {

        public CollectionViewModel()
        {
           cargarDatosClientes();
        }

        private entregasEntities _objBD = new entregasEntities();
        public entregasEntities objBD
        {
            get { return _objBD; }
            set { _objBD = value; notifyPropertyChanged(); }
        }

        private PedidosCollection _listaPedidos = new PedidosCollection();

        public PedidosCollection ListaPedidos
        {
            get { return _listaPedidos; }
            set
            {
                _listaPedidos = value;
                notifyPropertyChanged();
            }
        }

        private ClientesCollection _listaClientes = new ClientesCollection();
        public ClientesCollection ListaClientes
        {
            get { return _listaClientes; }
            set { _listaClientes = value;
                notifyPropertyChanged();
            }
        }


        private void cargarDatosClientes()
        {
            ListaClientes.Clear();
            
            var q = from p in objBD.clientes orderby p.apellidos ascending select p;
            foreach (var p in q.ToList())
            {
                ListaClientes.Add(p);
            }            
        }

        public void CargarPedidosCliente(string dni)
        {
            var q = from p in objBD.pedidos where p.cliente == dni select p;
            foreach (var p in q.ToList())
            {
                ListaPedidos.Add(p);
            }
        }

        public void guardarDatos()
        {
            objBD.SaveChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void notifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
