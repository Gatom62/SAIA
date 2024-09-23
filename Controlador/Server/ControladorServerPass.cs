using AgroServicios.Controlador.Helper;
using AgroServicios.Vista.Notificación;
using AgroServicios.Vista.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Controlador.Server
{
    internal class ControladorServerPass
    {
        VerificarContraServer objpass;

        public ControladorServerPass(VerificarContraServer Vista)
        {
            objpass = Vista;
            objpass.btnVerificar.Click += VerificarContra;
            objpass.ptbback.Click += CerrarForm;
        }

        private void CerrarForm(object sender, EventArgs e) 
        {
            objpass.Close();
        }

        void MessageBoxP(Color backcolor, Color color, string title, string text, Image icon)
        {
            AlertExito frm = new AlertExito();
            frm.BackColorAlert = backcolor;
            frm.ColorAlertBox = color;
            frm.TittlAlertBox = title;
            frm.TextAlertBox = text;
            frm.IconeAlertBox = icon;
            frm.ShowDialog();
        }
        private void VerificarContra(object sender, EventArgs e)
        {
            Encryp encryp = new Encryp();

            string pass = encryp.Encriptar(objpass.txtContraseña.Text);

            if(pass == StaticSession.Password)
            {
                MessageBoxP(Color.LightGreen, Color.Black, "Bienvenido", "Los datos son correctos", Properties.Resources.comprobado);
                ViewAdminConnection objcon = new ViewAdminConnection(2);
                objcon.ShowDialog();
                objpass.Close();
            }
            else
            {
                MessageBoxP(Color.Red, Color.DarkRed, "Fallo", "Los datos don incorrectos", Properties.Resources.ErrorIcono);
            }
        }
    }
}
