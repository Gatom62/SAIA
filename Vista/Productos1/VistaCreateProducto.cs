﻿using AgroServicios.Controlador;
using AgroServicios.Controlador.Productos1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Productos1
{
    public partial class VistaCreateProducto : Form
    {
        public VistaCreateProducto(int accion)
        {
            InitializeComponent();
            ControladorCreateProducto1 ObjCreateProducto1 = new ControladorCreateProducto1(this, accion);
        }

        private void VistaCreateProducto_Load(object sender, EventArgs e)
        {
            if (ControladorTema.IsDarkMode == true)
            {
                bunifuGradientPanel2.GradientBottomLeft = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientTopRight = Color.FromArgb(118, 88, 152);
                bunifuGradientPanel2.GradientBottomRight = Color.FromArgb(34, 36, 49);
                bunifuGradientPanel2.GradientTopLeft = Color.FromArgb(34, 36, 49);
            }

            if (ControladorIdioma.idioma == 1)
            {
                bunifuLabel1.Text = Ingles.btnañadir;
                txtNombreProducto.PlaceholderText = Ingles.NombreProducto;
                txtCodigo.PlaceholderText = Ingles.Codigo;
                txtCantidad.PlaceholderText = Ingles.CantidadProducto;
                btnImagenProducto.Text = Ingles.AgregarImagen;
                btnCrearProducto.Text = Ingles.Agregar;
                bunifuLabel3.Text = Ingles.Marca;
                bunifuLabel2.Text = Ingles.Descripcion;
            }

        }
    }
}
