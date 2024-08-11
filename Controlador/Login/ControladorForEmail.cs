using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Controlador.Login
{
    // Clase interna ControladorForEmail que maneja la lógica de la vista de recuperación de contraseñas por correo
    internal class ControladorForEmail
    {
        // Campo privado de solo lectura para almacenar una referencia a la vista
        private readonly VistaForEmail _vistaForEmail;

        /// <summary>
        /// Constructor de la clase ControladorForEmail que inicia los eventos de la vista
        /// </summary>
        /// <param name="vistaForEmail">Vista que será controlada por esta clase</param>
        public ControladorForEmail(VistaForEmail vistaForEmail)
        {
            _vistaForEmail = vistaForEmail;

            // Asigna el método EnviarCorreo al evento Click del botón Enviar
            _vistaForEmail.btnEnviar.Click += EnviarCorreo;

            // Asigna el método VolverForm al evento Click de la imagen que vuelve al formulario anterior
            _vistaForEmail.ptbback.Click += VolverForm;
        }

        // Método privado que se ejecuta cuando se hace clic en el botón de enviar correo
        private void EnviarCorreo(object sender, EventArgs e)
        {
            // Crea una instancia del DAO que maneja la recuperación de contraseñas
            var user = new DAORecuperarPass();

            // Llama al método recoverPassword pasando el texto ingresado por el usuario
            var result = user.recoverPassword(_vistaForEmail.txtUser.Text);

            // Muestra el resultado en la etiqueta lblResult de la vista
            _vistaForEmail.lblResult.Text = result;
        }

        // Método privado que se ejecuta cuando se hace clic en la imagen para volver al formulario anterior
        private void VolverForm(object sender, EventArgs e)
        {
            // Cierra la vista actual
            _vistaForEmail.Close();
        }
    }
}


