﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Controlador.CuentasContralador;

namespace AgroServicios.Vista.Cuentas
{
    public partial class VistaCuentas : Form
    {
        public VistaCuentas()
        {
            InitializeComponent();
            ControladorCuentas control = new ControladorCuentas(this);
        }

    }
}
