using AgroServicios.Modelo;
using AgroServicios.Modelo.DTO;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using AgroServicios.Vista.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AgroServicios.Controlador.Server
{
    internal class ControllerAdminConnection
    {
        ViewAdminConnection ObjView;
        int Origen;
        Form currentForm = null;

        public ControllerAdminConnection(ViewAdminConnection View, int origen)
        {
            ObjView = View;
            verificarOrigen(origen);
            this.Origen = origen;
            ///tabcontrol 2
            View.rdDeshabilitarWindows.CheckedChanged += new EventHandler(rdFalseMarked);
            View.rdHabilitarWindows.CheckedChanged += new EventHandler(rdTrueMarked);
            View.btnGuardar.Click += new EventHandler(GuardarRegistro);
            View.ptbback.Click += CerrarForm;
            //ObjView.CerrarPrograma += new FormClosingEventHandler(cerrarPrograma);
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
        private void CerrarForm(object sender, EventArgs e)
        {
            if(Origen == 1)
            {
                Application.Exit();
            }
            else if (Origen == 2)
            {
                ObjView.Close();
            }
        }
        public void verificarOrigen(int origen)
        {
            if (origen == 2)
            {
                //Cambiar configuración
                ObjView.txtServer.Text = DTOdbContext.Server;
                ObjView.txtDatabase.Text = DTOdbContext.Database;
                ObjView.txtSqlAuth.Text = DTOdbContext.User;
                ObjView.txtSqlPass.Text = DTOdbContext.Password;
            }
        }

        #region Configuración del servidor
        void rdFalseMarked(object sender, EventArgs e)
        {
            if (ObjView.rdDeshabilitarWindows.Checked == true)
            {
                ObjView.panelAuth.Enabled = true;
            }
        }
        void rdTrueMarked(object sender, EventArgs e)
        {
            if (ObjView.rdHabilitarWindows.Checked == true)
            {
                ObjView.panelAuth.Enabled = false;
                ObjView.txtSqlAuth.Clear();
                ObjView.txtSqlPass.Clear();
            }
        }
        void GuardarRegistro(object sender, EventArgs e)
        {
            // Validar si el servidor contiene doble pleca
            if (ObjView.txtServer.Text.Contains("\\\\"))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "The server name cannot contain two characters. Please correct it.", Properties.Resources.MensajeWarning);
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "El nombre del servidor no puede contener dos plecas. Por favor corríjalo.", Properties.Resources.MensajeWarning);
                }
                return; // Detener la ejecución si hay doble pleca
            }

            GuardarConfiguracionXML();
        }
        public void GuardarConfiguracionXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                //Crear declaración XML
                XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(decl);

                //Crear elemento raíz
                XmlElement root = doc.CreateElement("Conn");
                doc.AppendChild(root);

                //Crear los elementos hijos y agregarlos al elemento raíz
                XmlElement servidor = doc.CreateElement("Server");
                string servidorCode = CodificarBase64String(ObjView.txtServer.Text.Trim());

                servidor.InnerText = servidorCode;
                root.AppendChild(servidor);

                XmlElement Database = doc.CreateElement("Database");
                string DatabaseCode = CodificarBase64String(ObjView.txtDatabase.Text.Trim());
                Database.InnerText = DatabaseCode;
                root.AppendChild(Database);

                if (ObjView.rdDeshabilitarWindows.Checked == true)
                {
                    XmlElement SqlAuth = doc.CreateElement("SqlAuth");
                    string sqlAuthCode = CodificarBase64String(ObjView.txtSqlAuth.Text.Trim());
                    SqlAuth.InnerText = sqlAuthCode;
                    root.AppendChild(SqlAuth);

                    XmlElement SqlPass = doc.CreateElement("SqlPass");
                    string SqlPassCode = CodificarBase64String(ObjView.txtSqlPass.Text.Trim());
                    SqlPass.InnerText = SqlPassCode;
                    root.AppendChild(SqlPass);
                }
                else
                {
                    XmlElement SqlAuth = doc.CreateElement("SqlAuth");
                    SqlAuth.InnerText = string.Empty;
                    root.AppendChild(SqlAuth);

                    XmlElement SqlPass = doc.CreateElement("SqlPass");
                    SqlPass.InnerText = string.Empty;
                    root.AppendChild(SqlPass);
                }
                SqlConnection con = dbContext.testConnection(ObjView.txtServer.Text.Trim(), ObjView.txtDatabase.Text.Trim(), ObjView.txtSqlAuth.Text.Trim(), ObjView.txtSqlPass.Text.Trim());
                if (con != null)
                {
                    doc.Save("config_server.xml");
                    DTOdbContext.Server = ObjView.txtServer.Text.Trim();
                    DTOdbContext.Database = ObjView.txtDatabase.Text.Trim();
                    DTOdbContext.User = ObjView.txtSqlAuth.Text.Trim();
                    DTOdbContext.Password = ObjView.txtSqlPass.Text.Trim();
                    //Mensaje de afirmacion si se pudo realizar la inserccion
                    if (ControladorIdioma.idioma == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.Black, $"The file was created successfully.", "Configuration file", Properties.Resources.comprobado);
                        VistaLogin backForm = new VistaLogin();
                    }
                    else
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.Black, $"El archivo fue creado exitosamente.", "Archivo de configuración", Properties.Resources.comprobado);
                        VistaLogin backForm = new VistaLogin();
                    }
                    ObjView.Dispose();
                }

            }
            catch (XmlException ex)
            {
                //Mensaje de error si se no se pudo realizar la inserccion
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", $"Failed to create configuration file", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", $"No se pudo crear el archivo de configuración", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }

        }
        #endregion
        public string CodificarBase64String(string textoacifrar)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoacifrar);
                //Codificación base 64 string
                string base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
