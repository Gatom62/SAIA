using AgroServicios.Vista.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Controlador.Login
{
    internal class ControlerBasicMetodosRecuperar
    {
        VistaMetodosDeRecuperacion ObjRecuperacion;

        /// <summary>
        /// Constructor de la clase ControllerLogin que inicia los eventos de la vista
        /// </summary>
        /// <param name="MetodosRecuperar"></param>
        /// 

        public ControlerBasicMetodosRecuperar(VistaMetodosDeRecuperacion MetodosRecuperar)
        {
            ObjRecuperacion = MetodosRecuperar;
            ObjRecuperacion.btnEmail.Click += MetodoCorreo;
            ObjRecuperacion.ptbback.Click += VolverForm;
            ObjRecuperacion.btnPreguntas.Click += PreguntasSec;
            ObjRecuperacion.btnRecuperacionAdmin.Click += RecuperacionAdmin;
        }

        private void MetodoCorreo(Object sender, EventArgs e)
        {
            VistaForEmail vistaForEmail = new VistaForEmail();
            vistaForEmail.ShowDialog();
        }
        private void VolverForm(object sender, EventArgs e)
        {
           ObjRecuperacion.Close();
           VistaLogin vistaLogin = new VistaLogin();
           vistaLogin.Show();
        }
        private void PreguntasSec(object sender, EventArgs e)
        {
            VistaPreguntasLogin vistaPreguntasLogin = new VistaPreguntasLogin();
            vistaPreguntasLogin.ShowDialog();
        }
        private void RecuperacionAdmin(object sender, EventArgs e) 
        {
            VistaMetodoRecuperacionAdminUser vistaAdministracionUser = new VistaMetodoRecuperacionAdminUser();
            vistaAdministracionUser.ShowDialog();
        }

    }
}
