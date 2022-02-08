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

        private ClientesCollection _listaclientes;

        public ClientesCollection ListaClientes
        {
            get { return _listaclientes; }
            set { _listaclientes = value; }
        }


        public CollectionViewModel()
        {
           cargarDatosClientes();
        }

        private void cargarDatosClientes()
        {
            using (entregasEntities objbd = new entregasEntities())
            {
                var q = from p in objBD.clientes select p;
                foreach (var p in q.ToList())
                {
                    ListaClientes.Add(p);
                }
            }
        }
    }
}
