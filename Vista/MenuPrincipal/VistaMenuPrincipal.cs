using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Controlador.MenuPrincipal;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaMenuPrincipal : Form
    {
        public VistaMenuPrincipal()
        {
            InitializeComponent();
            ControladorMenuPrincipal control = new ControladorMenuPrincipal(this);
        }

    }
}
