﻿using SGEntregas_Ivan_Almudena.Components;
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

namespace SGEntregas_Ivan_Almudena.Ventanas.Tablet
{
    /// <summary>
    /// Lógica de interacción para PedidosClientTablet.xaml
    /// </summary>
    public partial class PedidosClientTablet : Window
    {
        CollectionViewModel cvm;
        TarjetPedido tp;
        string dni;

        public PedidosClientTablet(string dni)
        {
            InitializeComponent();
            cvm = (CollectionViewModel)this.Resources["ColeccionVM"];
            this.dni = dni;
            cvm.CargarPedidosCliente(this.dni);
            cargarTarjetas();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cargarTarjetas()
        {

            foreach (var item in cvm.ListaPedidos)
            {
                if (item.fecha_entrega == null)
                {
                    tp = new TarjetPedido(this.cvm, item);
                    tp.FechaPedido = item.fecha_pedido;
                    tp.FechaEntrega = item.fecha_entrega;
                    tp.Descripcion = item.descripcion;
                    listaPedidosCli.Children.Add(tp);
                    
                }
            }
        }

    }
}

