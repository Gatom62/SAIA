using AgroServicios.Modelo.DAO;
using System;
using System.Windows.Forms;
using AgroServicios.Vista.Login;
using AgroServicios.Modelo.DTO;
using AgroServicios.Modelo;
using AgroServicios.Vista.MenuPrincipal;
using System.Diagnostics.Eventing.Reader;

namespace AgroServicios.Controlador.Login
{
    internal class ControladorLogin
    {
       
        VistaLogin ObjLogin;

        /// <summary>
        /// </summary>
        /// <param name="Vista"></param>
        /// 

        public ControladorLogin(VistaLogin Vista)
        {
            ObjLogin = Vista;
            ObjLogin.BtnStart.Click += new EventHandler(DataAccess);
            ObjLogin.menuTest.Click += new EventHandler(TestConnection);
            ObjLogin.PasswordVisible.Click += new EventHandler(ShowPassword);
            ObjLogin.PasswordHide.Click += new EventHandler(HidePassword);
            ObjLogin.lblRecuperar.Click += new EventHandler(RecuperarPass);
        }

        private void TestConnection(object sender, EventArgs e)
        {
            //Verificar la propiedad idioma para cambiar el idioma
            if (ControladorIdioma.idioma == 1)
            {
                if (dbContext.getConnection() == null)
                {
                    MessageBox.Show("It was not possible to connect to the server and/or database.", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("The connection to the server and database was successful.", "Connection successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                if (dbContext.getConnection() == null)
                {
                    MessageBox.Show("No fue posible realizar la conexión al servidor y/o la base de datos.", "Conexión fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("La conexión al servidor y la base de datos se ha ejecutado correctamente.", "Conexión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DataAccess(object sender, EventArgs e)
        {
            string mensajeCampos, tituloCampos, mensajeError, tituloError;

            if (ControladorIdioma.idioma == 1)
            {
                mensajeCampos = "You must fill in all the fields.";
                tituloCampos = "Validation error";
                mensajeError = "Incorrect data";
                tituloError = "Login error";
            }
            else
            {
                mensajeCampos = "Debe rellenar todos los campos.";
                tituloCampos = "Error de validación";
                mensajeError = "Datos incorrectos";
                tituloError = "Error al iniciar sesión";
            }

            if (string.IsNullOrWhiteSpace(ObjLogin.txtUsername.Text) || string.IsNullOrWhiteSpace(ObjLogin.txtPassword.Text))
            {
                MessageBox.Show(mensajeCampos, tituloCampos, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Creando objeto de la Clase DAOLogin
            DAOLogin DAOData = new DAOLogin();
            // Utilizando el objeto DAO para invocar a los métodos getter y setter del DTO
            Encryp ObjEncriptar = new Encryp();
            DAOData.Username = ObjLogin.txtUsername.Text;
            DAOData.Password = ObjEncriptar.Encriptar(ObjLogin.txtPassword.Text);
            // Invocando al método Login contenido en el DAO
            int answer = DAOData.Login();

            if (answer == 0)
            {
                ObjLogin.Hide();
                Bienvenida bienvenida = new Bienvenida();
                bienvenida.ShowDialog();
                VistaMenuPrincipal vistaMenuPrincipal = new VistaMenuPrincipal();
                vistaMenuPrincipal.Show();
                ObjLogin.Hide();
            }
            else
            {
                MessageBox.Show(mensajeError, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ShowPassword(object sender, EventArgs e)
        {
            ObjLogin.txtPassword.UseSystemPasswordChar = false;
            ObjLogin.PasswordVisible.Visible = false;
            ObjLogin.PasswordHide.Visible = true;
            // Forzar la actualización del TextBox
            string tempText = ObjLogin.txtPassword.Text;
            ObjLogin.txtPassword.Text = string.Empty;
            ObjLogin.txtPassword.Text = tempText;

            ObjLogin.ResumeLayout();  // Reanudar el redibujado
        }

        private void HidePassword(object sender, EventArgs e)
        {
            ObjLogin.txtPassword.UseSystemPasswordChar = true;
            ObjLogin.PasswordVisible.Visible = true;
            ObjLogin.PasswordHide.Visible = false;
            // Forzar la actualización del TextBox
            string tempText = ObjLogin.txtPassword.Text;
            ObjLogin.txtPassword.Text = string.Empty;
            ObjLogin.txtPassword.Text = tempText;

            ObjLogin.ResumeLayout();  // Reanudar el redibujado
        }

        private void RecuperarPass(Object sender, EventArgs e)
        {
            ObjLogin.Hide();
            VistaMetodosDeRecuperacion recuperacion = new VistaMetodosDeRecuperacion();
            recuperacion.Show();
        }

    }
}
