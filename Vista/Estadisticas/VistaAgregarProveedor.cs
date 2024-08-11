using AgroServicios.Controlador;
using AgroServicios.Controlador.ControladorStats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.Estadisticas
{
    public partial class VistaAgregarProveedor : Form
    {
        public VistaAgregarProveedor()
        {
            InitializeComponent();
            ControladorCrearProveedor control = new ControladorCrearProveedor(this);
        }

        private void VistaAgregarProveedor_Load(object sender, EventArgs e)
        {
            if (ControladorIdioma.idioma == 1)
            {
                AñaP.Text = Ingles.txtAñaP;
                txtNewFirstName.PlaceholderText = Ingles.txtFN;
                txtNewID.PlaceholderText = Ingles.txtDUI;
                txtNewPhone.PlaceholderText = Ingles.txtTe;
                txtNewCorreo.PlaceholderText = Ingles.txtCR;
                txtNewCompany.PlaceholderText = Ingles.txtEM;
                btnAgregarProv.Text = Ingles.btnAP;
                   
            }
        }
    }
}
