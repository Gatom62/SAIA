﻿using AgroServicios.Controlador.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Login
{
    public partial class VistaMetodoRecuperacionAdminUser : Form
    {
        public VistaMetodoRecuperacionAdminUser()
        {
            InitializeComponent();
            ControladorAdministracionUser controladorAdministracionUser = new ControladorAdministracionUser(this);
        }
    }
}
