using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Controlador.Login
{
    internal class ControladorForEmail
    {
        VistaForEmail Objforemail;

        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="EmailRec"></param>
        /// 
        
        public ControladorForEmail(VistaForEmail EmailRec)
        {
            Objforemail = EmailRec;
            Objforemail.btnEnviar.Click += new EventHandler(EnviarCorreo); 
        }

        private void EnviarCorreo(object sender, EventArgs e)
        {
            Objforemail = new VistaForEmail();
            var user = new DAORecuperarPass();
            var result = user.recoverPassword(Objforemail.txtUser.Text);
            Objforemail.lblResult.Text = result;
        }
    }
}
