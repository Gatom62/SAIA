﻿using AgroServicios.Controlador.CuentasContralador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Cuentas
{
    public partial class VistaCuentasAdminUser : Form
    {
        public VistaCuentasAdminUser()
        {
            InitializeComponent();
            ControladorCuentasAdminUser controladorCuentas = new ControladorCuentasAdminUser(this);
        }

        private void GriewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
