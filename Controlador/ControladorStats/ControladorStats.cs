﻿using System;
using AgroServicios.Vista.Clientes;
using AgroServicios.Vista.Estadisticas;

using AgroServicios.Vista.Productos1;


namespace AgroServicios.Controlador.ControladorStats
{
    internal class ControladorStats
    {
        VistaStats ObjStats;

        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="Estadisticas"></param>
        
        public ControladorStats(VistaStats Estadisticas)
        {
            ObjStats = Estadisticas;
            ObjStats.btnProveedores.Click += new EventHandler(OpenProveedores);
            ObjStats.btnSuministros.Click += new EventHandler(OpenSuministros);
            ObjStats.btnHistorial.Click += OpenHistorialVentas;
            ObjStats.btnClientes.Click += OpenClientes;

        }
        private void OpenClientes(object sender, EventArgs e)
        {
            VistaClientes vistaClientes = new VistaClientes();
            vistaClientes.ShowDialog();
        }

        private void OpenSuministros(object sender, EventArgs e)
        {
            VistaProductos vistaProductos = new VistaProductos();
            vistaProductos.ShowDialog();
        }
        public void OpenProveedores(object sender, EventArgs e)
        {
            VistaProveedores vistaProveedores = new VistaProveedores();
            vistaProveedores.ShowDialog();
        }
        private void OpenHistorialVentas(object sender, EventArgs e)
        {
            VistaHistorialVenta vista = new VistaHistorialVenta();
            vista.ShowDialog();
        }
    }
}
