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
        public event PropertyChangedEventHandler PropertyChanged;
        private ClientesCollection _listaClientes = new ClientesCollection();
        private entregasEntities _objBD = new entregasEntities();

        public entregasEntities objBD
        {
            get { return _objBD; }
            set { _objBD = value; notifyPropertyChanged(); }
        }

        private void notifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       
        public ClientesCollection ListaClientes
        {
            get { return _listaClientes; }
            set { _listaClientes = value;
                notifyPropertyChanged();
            }
        }

        public CollectionViewModel()
        {
           cargarDatosClientes();
        }

        private void cargarDatosClientes()
        {
            ListaClientes.Clear();
            
            var q = from p in objBD.clientes select p;
            foreach (var p in q.ToList())
            {
                ListaClientes.Add(p);
            }            
        }

        public void guardarDatos()
        {
            objBD.SaveChanges();
        }
    }
}
