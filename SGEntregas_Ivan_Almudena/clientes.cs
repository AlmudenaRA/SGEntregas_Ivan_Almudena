//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SGEntregas_Ivan_Almudena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class clientes : INotifyPropertyChanged, ICloneable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            this.pedidos = new HashSet<pedidos>();
        }

        private string dni_;

        public string dni
        {
            get { return dni_; }
            set
            {
                dni_ = value;
                notificarPropertyChanged();
            }
        }


        private string nombre_;

        public string nombre
        {
            get { return nombre_; }
            set
            {
                nombre_ = value;
                notificarPropertyChanged();
            }
        }

        private string apellidos_;

        public string apellidos
        {
            get { return apellidos_; }
            set
            {
                apellidos_ = value;
                notificarPropertyChanged();
            }
        }

        private string email_;

        public string email
        {
            get { return email_; }
            set
            {
                email_ = value;
                notificarPropertyChanged();
            }
        }

        private string domicilio_;

        public string domicilio
        {
            get { return domicilio_; }
            set
            {
                domicilio_ = value;
                notificarPropertyChanged();
            }
        }

        private string localidad_;

        public string localidad
        {
            get { return localidad_; }
            set
            {
                localidad_ = value;
                notificarPropertyChanged();
            }
        }

        private int provincia_;

        public int provincia
        {
            get { return provincia_; }
            set
            {
                provincia_ = value;
                notificarPropertyChanged();
            }
        }

        private provincias provincias_;

        public virtual provincias provincias
        {
            get { return provincias_; }
            set
            {
                provincias_ = value;
                notificarPropertyChanged();
            }
        }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<pedidos> pedidos_;

        public virtual ICollection<pedidos> pedidos
        {
            get { return pedidos_; }
            set
            {
                pedidos_ = value;
                notificarPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void notificarPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
