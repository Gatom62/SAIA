﻿using AgroServicios.Modelo.DAO;
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
            ObjLogin.cmsConecarBase.Click += new EventHandler(AbrirBase);
            ObjLogin.cmsManualTecnico.Click += new EventHandler(AbrirManualTecnico);
            ObjLogin.cmsManualUsuario.Click += new EventHandler(AbrirManualUsuario);
            ObjLogin.ptbback.Click += new EventHandler(CerrarAplicacion);
        }

        private void CerrarAplicacion(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AbrirManualUsuario(object sender, EventArgs e)
        {
            string manualUsuario;

            if (ControladorIdioma.idioma == 1)
            {
                manualUsuario = "Manual de Usuario";
            }
            else
            {
                manualUsuario = "User Manual";
            }

            // Nombre del archivo que quieres extraer de los recursos
            string nombreArchivo = manualUsuario;

            // Ruta temporal donde se guardará el PDF extraído
            string pdfTempPath = Path.Combine(Path.GetTempPath(), nombreArchivo);

            // Escribe el contenido del archivo PDF desde los recursos a la ruta temporal
            File.WriteAllBytes(pdfTempPath, Properties.Resources.Manual_de_Usuario_1_3);

            // Abre el archivo PDF utilizando el visor predeterminado del sistema
            System.Diagnostics.Process.Start(pdfTempPath);
        }

        private void AbrirManualTecnico(object sender, EventArgs e)
        {
            string manualTecnico;

            if (ControladorIdioma.idioma == 1)
            {
                manualTecnico = "Manual Ténico";
            }
            else
            {
                manualTecnico = "Technical Manual";
            }

            // Nombre del archivo que quieres extraer de los recursos
            string nombreArchivo = manualTecnico;

            // Ruta temporal donde se guardará el PDF extraído
            string pdfTempPath = Path.Combine(Path.GetTempPath(), nombreArchivo);

            // Escribe el contenido del archivo PDF desde los recursos a la ruta temporal
            File.WriteAllBytes(pdfTempPath, Properties.Resources.Manual_Técnico_de_SAIA_1_5);

            // Abre el archivo PDF utilizando el visor predeterminado del sistema
            System.Diagnostics.Process.Start(pdfTempPath);
        }

        private void AbrirBase(object sender, EventArgs e) 
        {
            VistaValidacionBase vistaValidacionBase = new VistaValidacionBase();
            vistaValidacionBase.Show();
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

        private void TestConnection(object sender, EventArgs e)
        {
            //Verificar la propiedad idioma para cambiar el idioma
            if (ControladorIdioma.idioma == 1)
            {
                if (dbContext.getConnection() == null)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Connection failed", "It was not possible to connect to the server and/or database.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();

                }
                else
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Conexión exitosa", "La conexión al servidor y la base de datos se ha ejecutado correctamente.", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                }

            }
            else
            {
                if (dbContext.getConnection() == null)
                {
                    if (ControladorIdioma.idioma == 1)
                    {
                        MandarValoresAlerta(Color.Red, Color.DarkRed, "Connection failed", "The connection to the server and/or database could not be established.", Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                    }
                    else
                    {
                        MandarValoresAlerta(Color.Red, Color.DarkRed, "Conexión fallida", "No fue posible realizar la conexión al servidor y/o la base de datos.", Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                    }
                }
                else
                {
                    if (ControladorIdioma.idioma == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.Black, "Connection successful", "The connection to the server and database has been executed successfully.", Properties.Resources.comprobado);
                    }
                    else
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.Black, "Conexión exitosa", "La conexión al servidor y la base de datos se ha ejecutado correctamente.", Properties.Resources.comprobado);
                    }
                    VistaLogin backForm = new VistaLogin();
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
            string mensajeCampos, tituloCampos, mensajeError, tituloError, configuracionRequerida, debeConfigurarPreguntas, UsuarioContraError, errorAutentication;

            if (ControladorIdioma.idioma == 1)
            {
                mensajeCampos = "You must fill in all the fields.";
                tituloCampos = "Validation error";
                mensajeError = "Incorrect data";
                tituloError = "Login error";
                configuracionRequerida = "Required configuration";
                debeConfigurarPreguntas = "You must set up your security questions to continue.";
                UsuarioContraError = "Incorrect username or password.";
                errorAutentication = "Authentication error.";
            }
            else
            {
                mensajeCampos = "Debe rellenar todos los campos.";
                tituloCampos = "Error de validación";
                mensajeError = "Datos incorrectos";
                tituloError = "Error al iniciar sesión";
                configuracionRequerida = "Configuración requerida";
                debeConfigurarPreguntas = "Debe de configurar sus preguntas de seguridad antes de continuar.";
                UsuarioContraError = "Error de Autenticación.";
                errorAutentication = "Usuario o contraseña incorrectos.";
            }

            if (string.IsNullOrWhiteSpace(ObjLogin.txtUsername.Text) || string.IsNullOrWhiteSpace(ObjLogin.txtPassword.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, tituloCampos, mensajeCampos, Properties.Resources.MensajeWarning);
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

            switch (answer)
            {
                case 0:
                    // Login exitoso y preguntas de seguridad configuradas
                    ObjLogin.Hide();
                    Bienvenida bienvenida = new Bienvenida();
                    bienvenida.ShowDialog();
                    VistaMenuPrincipal vistaMenuPrincipal = new VistaMenuPrincipal();
                    vistaMenuPrincipal.Show();
                    ObjLogin.Hide();
                    break;

                case -2:
                    // Login exitoso pero faltan configurar preguntas de seguridad
                    ObjLogin.Hide();
                    VistaPreguntas formPreguntas = new VistaPreguntas(DAOData.Username, 1);
                    if (formPreguntas.ShowDialog() == DialogResult.OK)
                    {
                        // Si el usuario configuró sus preguntas exitosamente, proceder al menú principal
                        Bienvenida bienvenidaDespuesPreguntas = new Bienvenida();
                        bienvenidaDespuesPreguntas.ShowDialog();
                        VistaMenuPrincipal vistaMenuDespuesPreguntas = new VistaMenuPrincipal();
                        vistaMenuDespuesPreguntas.Show();
                    }
                    else
                    {
                        // Si el usuario cancela la configuración de preguntas, volver al login
                        MandarValoresAlerta(Color.Red, Color.DarkRed, configuracionRequerida, debeConfigurarPreguntas, Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                        ObjLogin.Show();
                    }
                    break;

                case 1:
                    // Usuario o contraseña incorrectos
                    MessageBoxP(Color.Yellow, Color.Orange, UsuarioContraError, errorAutentication, Properties.Resources.MensajeWarning);
                    break;

                default:
                    // Error durante el proceso de login
                    MessageBoxP(Color.Yellow, Color.Orange, tituloError, mensajeError, Properties.Resources.MensajeWarning);
                    break;
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
