using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.MenuPrincipal;
using System.Data;
using System.Windows.Forms;
using System;
using AgroServicios.Vista.Notificación;
using System.Drawing;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace AgroServicios.Controlador.Login
{
    internal class ControladorPreguntasLogin
    {
        VistaPreguntasLogin objpre;

        public ControladorPreguntasLogin(VistaPreguntasLogin Vista)
        {
            objpre = Vista;
            objpre.Load += InitialCharge;
            objpre.ptbback.Click += new EventHandler(VolverForm); 
            objpre.btnGuardar.Click += VerificarRespuestas;
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
        public void VolverForm(object sender, EventArgs e) 
        {
            objpre.Close();
        }
        public void InitialCharge(object sender, EventArgs e)
        {
            try
            {
                DAOPreguntasRec rec = new DAOPreguntasRec();
                DataSet ds = rec.LlenarCombo();

                // Verificar que el DataSet contiene la tabla esperada
                if (ds.Tables.Contains("PreguntasSeguridad"))
                {
                    // Clonar la tabla para que los ComboBox tengan fuentes de datos independientes
                    DataTable dt1 = ds.Tables["PreguntasSeguridad"].Copy();
                    DataTable dt2 = ds.Tables["PreguntasSeguridad"].Copy();

                    // Asignar el DataSource al primer ComboBox
                    objpre.droprole1.DataSource = dt1;
                    objpre.droprole1.ValueMember = "PreguntaID";
                    objpre.droprole1.DisplayMember = "Pregunta";

                    // Asignar el DataSource al segundo ComboBox
                    objpre.droprole2.DataSource = dt2;
                    objpre.droprole2.ValueMember = "PreguntaID";
                    objpre.droprole2.DisplayMember = "Pregunta";
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "La tabla 'PreguntasSeguridad' no se encontró en el DataSet.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }
            catch (Exception ex)
            {
                MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Error al cargar los datos: " + ex.Message, Properties.Resources.ErrorIcono);
                VistaLogin backForm = new VistaLogin();
            }
        }
        private void VerificarRespuestas(object sender, EventArgs e)
        {
            if (ValidarEntradas())
            {
                DAOPreguntasRec daoPreguntas = new DAOPreguntasRec();
                Encryp Desencriptar = new Encryp();

                daoPreguntas.Usuario = objpre.txtUsuario.Text.Trim();
                daoPreguntas.Pregunta1 = int.Parse(objpre.droprole1.SelectedValue.ToString());
                daoPreguntas.Res1 = Desencriptar.Encriptar(objpre.txtRes1.Text.Trim());
                daoPreguntas.Pregunta2 = int.Parse(objpre.droprole2.SelectedValue.ToString());
                daoPreguntas.Res2 = Desencriptar.Encriptar(objpre.txtRes2.Text.Trim());

                if (daoPreguntas.VerificarRespuestas())
                {
                    string user = objpre.txtUsuario.Text;
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Verificación completada", "Respuestas correctas. Puede restablecer su contraseña.", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();

                    objpre.Close();
                    VistaRestContraPreguntas vista = new VistaRestContraPreguntas(user);
                    vista.ShowDialog();
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Verificación fallida", "Las respuestas no son correctas. Inténtelo de nuevo.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }
        }
        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(objpre.txtRes1.Text) || string.IsNullOrWhiteSpace(objpre.txtRes2.Text))
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error de validación", "Por favor, complete ambas respuestas de seguridad.", Properties.Resources.MensajeWarning);
                return false;
            }

            if (objpre.droprole1.SelectedValue.ToString() == objpre.droprole2.SelectedValue.ToString())
            {
                MessageBoxP(Color.Yellow, Color.Orange, "Error de validación", "Las preguntas de seguridad no pueden ser iguales.", Properties.Resources.MensajeWarning);
                return false;
            }

            return true;
        }
    }
}