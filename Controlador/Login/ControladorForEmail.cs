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
        private readonly VistaForEmail _vistaForEmail;

        /// <summary>
        /// Constructor de la clase ControladorForEmail que inicia los eventos de la vista
        /// </summary>
        /// <param name="vistaForEmail"></param>
        public ControladorForEmail(VistaForEmail vistaForEmail)
        {
            _vistaForEmail = vistaForEmail;
            _vistaForEmail.btnEnviar.Click += EnviarCorreo;
        }

        private void EnviarCorreo(object sender, EventArgs e)
        {
            var user = new DAORecuperarPass();
            var result = user.recoverPassword(_vistaForEmail.txtUser.Text);
            _vistaForEmail.lblResult.Text = result;
        }
    }
}

