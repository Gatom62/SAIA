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
            ObjRecuperacion.btnEmail.Click += new EventHandler(MetodoCorreo);
        }

        private void MetodoCorreo(Object sender, EventArgs e)
        {
            VistaForEmail vistaForEmail = new VistaForEmail();
            vistaForEmail.ShowDialog();
        }

    }
}
