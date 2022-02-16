﻿using System;
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

namespace SGEntregas_Ivan_Almudena.Components
{
    /// <summary>
    /// Lógica de interacción para TarjetPedido.xaml
    /// </summary>
    public partial class TarjetPedido : UserControl
    {
        public DateTime FechaPedido
        {
            get { return (DateTime)GetValue(FechaPedidoProperty); }
            set { SetValue(FechaPedidoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FechaPedido.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FechaPedidoProperty =
            DependencyProperty.Register("FechaPedido", typeof(DateTime), typeof(TarjetPedido), new PropertyMetadata(DateTime.Now));

        public DateTime? FechaEntrega
        {
            get { return (DateTime?)GetValue(FechaEntregaProperty); }
            set { SetValue(FechaEntregaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FechaEntregaProperty =
            DependencyProperty.Register("FechaEntrega", typeof(DateTime?), typeof(TarjetPedido), new PropertyMetadata());


        public string Descripcion
        {
            get { return (string)GetValue(DescripcionProperty); }
            set { SetValue(DescripcionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescripcionProperty =
            DependencyProperty.Register("Descripcion", typeof(string), typeof(TarjetPedido), new PropertyMetadata(string.Empty));

        public TarjetPedido()
        {
            InitializeComponent();
        }
    }
}