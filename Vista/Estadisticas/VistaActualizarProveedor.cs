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
    public partial class VistaActualizarProveedor : Form
    {
        
            public VistaActualizarProveedor(int accion, int id, string Name, string Dui, string phone, string email, string company)
            {
                InitializeComponent();
                ControladorActualizarProveedor control = new ControladorActualizarProveedor(this, accion, id, Name, Dui, phone, email, company);
            }


        private void PickerBirthUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
