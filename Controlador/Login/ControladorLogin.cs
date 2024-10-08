using AgroServicios.Modelo.DAO;
using System;
using System.Windows.Forms;
using AgroServicios.Vista.Login;
using AgroServicios.Modelo.DTO;
using AgroServicios.Modelo;
using AgroServicios.Vista.MenuPrincipal;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Drawing;
using AgroServicios.Vista.Notificación;
using AgroServicios.Vista.Server;
using System.IO;

namespace AgroServicios.Controlador.Login
{
    internal class ControladorLogin
    {
        VistaLogin ObjLogin;

        public ControladorLogin(VistaLogin Vista)
        {
            ObjLogin = Vista;
            ObjLogin.BtnStart.Click += new EventHandler(DataAccess);
            ObjLogin.menuTest.Click += new EventHandler(TestConnection);
            ObjLogin.PasswordVisible.Click += new EventHandler(ShowPassword);
            ObjLogin.PasswordHide.Click += new EventHandler(HidePassword);
            ObjLogin.lblRecuperar.Click += new EventHandler(RecuperarPass);
            ObjLogin.cmsConecarBase.Click += new EventHandler(AbrirBase);
            ObjLogin.cmsManualTecnico.Click += new EventHandler(AbrirManualTecnico);
            ObjLogin.cmsManualUsuario.Click += new EventHandler(AbrirManualUsuario);
            ObjLogin.FormClosing += new FormClosingEventHandler(cerrarPrograma);
        }
        void MandarValoresAlerta(Color backcolor, Color color, string title, string text, Image icon)
        {
            MessagePersonal message = new MessagePersonal();
            message.BackColorAlert = backcolor;
            message.ColorAlertBox = color;
            message.TittlAlertBox = title;
            message.TextAlertBox = text;
            message.IconeAlertBox = icon;
            message.ShowDialog();
        }

        private void AbrirManualUsuario(object sender, EventArgs e)
        {
            string nombreArchivo = "Manual de Usuario";
            string pdfTempPath = Path.Combine(Path.GetTempPath(), nombreArchivo);
            File.WriteAllBytes(pdfTempPath, Properties.Resources.Manual_de_Usuario_1_3);
            System.Diagnostics.Process.Start(pdfTempPath);
        }

        private void cerrarPrograma(Object sender, FormClosingEventArgs e)
        {
            string mensajeCerrar, tituloCerrar;

            if (ControladorIdioma.idioma == 1)
            {
                mensajeCerrar = "Do you want to close the program? If you close it, all sessions will be closed.";
                tituloCerrar = "Decide";
            }
            else
            {
                mensajeCerrar = "¿Desea cerrar el programa? Si lo cierra, se estará cerrando en todos los planos.";
                tituloCerrar = "Decida";
            }

            if (MessageBox.Show(mensajeCerrar, tituloCerrar, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void AbrirManualTecnico(object sender, EventArgs e)
        {
            string nombreArchivo = "Manual Técnico";
            string pdfTempPath = Path.Combine(Path.GetTempPath(), nombreArchivo);
            File.WriteAllBytes(pdfTempPath, Properties.Resources.Manual_Técnico_de_SAIA_1_5);
            System.Diagnostics.Process.Start(pdfTempPath);
        }

        private void AbrirBase(object sender, EventArgs e)
        {
            VistaValidacionBase vistaValidacionBase = new VistaValidacionBase();
            vistaValidacionBase.Show();
        }

        private void TestConnection(object sender, EventArgs e)
        {
            string mensajeConexionExitosa, tituloConexionExitosa, mensajeConexionFallida, tituloConexionFallida;

            if (ControladorIdioma.idioma == 1)
            {
                mensajeConexionExitosa = "The connection to the server and database has been successfully executed.";
                tituloConexionExitosa = "Successful connection";
                mensajeConexionFallida = "It was not possible to connect to the server and/or database.";
                tituloConexionFallida = "Connection failed";
            }
            else
            {
                mensajeConexionExitosa = "La conexión al servidor y la base de datos se ha ejecutado correctamente.";
                tituloConexionExitosa = "Conexión exitosa";
                mensajeConexionFallida = "No fue posible realizar la conexión al servidor y/o la base de datos.";
                tituloConexionFallida = "Conexión fallida";
            }

            if (dbContext.getConnection() == null)
            {
                MandarValoresAlerta(Color.Red, Color.DarkRed, tituloConexionFallida, mensajeConexionFallida, Properties.Resources.ErrorIcono);
            }
            else
            {
                MandarValoresAlerta(Color.LightGreen, Color.Black, tituloConexionExitosa, mensajeConexionExitosa, Properties.Resources.comprobado);
            }
        }

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

            DAOLogin DAOData = new DAOLogin();
            Encryp ObjEncriptar = new Encryp();
            DAOData.Username = ObjLogin.txtUsername.Text;
            DAOData.Password = ObjEncriptar.Encriptar(ObjLogin.txtPassword.Text);
            int answer = DAOData.Login();

            switch (answer)
            {
                case 0:
                    ObjLogin.Hide();
                    Bienvenida bienvenida = new Bienvenida();
                    bienvenida.ShowDialog();
                    VistaMenuPrincipal vistaMenuPrincipal = new VistaMenuPrincipal();
                    vistaMenuPrincipal.Show();
                    ObjLogin.Hide();
                    break;

                case -2:
                    ObjLogin.Hide();
                    VistaPreguntas formPreguntas = new VistaPreguntas(DAOData.Username, 1);
                    if (formPreguntas.ShowDialog() == DialogResult.OK)
                    {
                        Bienvenida bienvenidaDespuesPreguntas = new Bienvenida();
                        bienvenidaDespuesPreguntas.ShowDialog();
                        VistaMenuPrincipal vistaMenuDespuesPreguntas = new VistaMenuPrincipal();
                        vistaMenuDespuesPreguntas.Show();
                    }
                    else
                    {
                        string mensajeConfigurarPreguntas = ControladorIdioma.idioma == 1 ?
                            "You must configure your security questions to continue." :
                            "Debe configurar sus preguntas de seguridad para continuar.";
                        string tituloConfigurarPreguntas = ControladorIdioma.idioma == 1 ?
                            "Configuration required" :
                            "Configuración requerida";

                        MessageBox.Show(mensajeConfigurarPreguntas, tituloConfigurarPreguntas, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ObjLogin.Show();
                    }
                    break;

                case 1:
                    string mensajeAutenticacion = ControladorIdioma.idioma == 1 ?
                        "Incorrect username or password." :
                        "Usuario o contraseña incorrectos.";
                    string tituloAutenticacion = ControladorIdioma.idioma == 1 ?
                        "Authentication error" :
                        "Error de autenticación";

                    MessageBox.Show(mensajeAutenticacion, tituloAutenticacion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                default:
                    MessageBox.Show(mensajeError, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ShowPassword(object sender, EventArgs e)
        {
            ObjLogin.txtPassword.UseSystemPasswordChar = false;
            ObjLogin.PasswordVisible.Visible = false;
            ObjLogin.PasswordHide.Visible = true;
            string tempText = ObjLogin.txtPassword.Text;
            ObjLogin.txtPassword.Text = string.Empty;
            ObjLogin.txtPassword.Text = tempText;
            ObjLogin.ResumeLayout();
        }

        private void HidePassword(object sender, EventArgs e)
        {
            ObjLogin.txtPassword.UseSystemPasswordChar = true;
            ObjLogin.PasswordVisible.Visible = true;
            ObjLogin.PasswordHide.Visible = false;
            string tempText = ObjLogin.txtPassword.Text;
            ObjLogin.txtPassword.Text = string.Empty;
            ObjLogin.txtPassword.Text = tempText;
            ObjLogin.ResumeLayout();
        }

        private void RecuperarPass(Object sender, EventArgs e)
        {
            ObjLogin.Hide();
            VistaMetodosDeRecuperacion recuperacion = new VistaMetodosDeRecuperacion();
            recuperacion.Show();
        }
    }
}

