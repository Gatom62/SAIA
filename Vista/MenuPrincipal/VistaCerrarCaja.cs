﻿using AgroServicios.Controlador.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaCerrarCaja : Form
    {
        public VistaCerrarCaja()
        {
            InitializeComponent();
            ControladorCerrarCaja control = new ControladorCerrarCaja(this);
        }
    }
}
