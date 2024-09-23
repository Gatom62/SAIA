using AgroServicios.Modelo.DAO;
using AgroServicios.Modelo.DTO;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Login
{
    internal class ControladorPreguntasRec
    {
        VistaPreguntas objpre;
        private int accion;
        public ControladorPreguntasRec(VistaPreguntas Vista, string user, int action)
        {
            objpre = Vista;
            this.accion = action;
            objpre.Load += InitialCharge;
            ChargeValues(user);
            objpre.btnGuardar.Click += InsertarRespuestas;
            objpre.btnActualizarP.Click += ActualizarRespuestas;
            objpre.btnClose.Click += CerrarForm;
            verificaraccion();
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
            objpre.Close();
        }
        private void verificaraccion()
        {
            if (accion == 1)
            {
                objpre.btnActualizarP.Enabled = false;
            }
            if (accion == 2)
            {
                objpre.btnGuardar.Enabled = false;
                objpre.btnClose.Visible = true;
            }
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


        public void ChargeValues(string user)
        {
            objpre.txtUsuario.Text = user;

            if (accion == 2)
            {
                try
                {
                    DAOPreguntasRec rec = new DAOPreguntasRec();

                    // Obtener los RespuestaID del usuario
                    DataTable dtRespuestas = rec.ObtenerRespuestaIDs(user);

                    // Verificar que se obtuvieron exactamente dos RespuestaID
                    if (dtRespuestas.Rows.Count == 2)
                    {
                        objpre.txtRespuestaID1.Text = dtRespuestas.Rows[0]["RespuestaID"].ToString();
                        objpre.txtRespuestaID2.Text = dtRespuestas.Rows[1]["RespuestaID"].ToString();
                    }
                    else
                    {
                        MessageBoxP(Color.Yellow, Color.Orange, "Error", "El usuario no tiene exactamente dos respuestas de seguridad asignadas.", Properties.Resources.MensajeWarning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Error al cargar los RespuestaID: " + ex.Message, Properties.Resources.MensajeWarning);
                }
            }

        }

        private void ActualizarRespuestas(object sender, EventArgs e)
        {
            if (ValidarEntradas())
            {
                DAOPreguntasRec dAOact = new DAOPreguntasRec();
                Encryp encriptar = new Encryp();

                dAOact.Usuario = objpre.txtUsuario.Text.Trim();
                dAOact.Pregunta1 = int.Parse(objpre.droprole1.SelectedValue.ToString());
                dAOact.Pregunta2 = int.Parse(objpre.droprole2.SelectedValue.ToString());
                dAOact.Res1 = encriptar.Encriptar(objpre.txtRes1.Text.Trim());
                dAOact.Res2 = encriptar.Encriptar(objpre.txtRes2.Text.Trim());
                dAOact.RespuestaID1 = int.Parse(objpre.txtRespuestaID1.Text.ToString());
                dAOact.RespuestaID2 = int.Parse(objpre.txtRespuestaID2.Text.ToString());

                int resultado = dAOact.ActualizarPreguntasYRespuestas();

                if (resultado > 0)
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso completado", "Las respuestas de seguridad se han actualizado correctamente.", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Proceso completado", "Ocurrió un error al actualizar las respuestas de seguridad.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }
        }

        private void InsertarRespuestas(object sender, EventArgs e)
        {
            if (ValidarEntradas())
            {
                DAOPreguntasRec dAO = new DAOPreguntasRec();

                Encryp encriptar = new Encryp();
                dAO.Usuario = objpre.txtUsuario.Text.Trim();
                dAO.Pregunta1 = int.Parse(objpre.droprole1.SelectedValue.ToString());
                dAO.Pregunta2 = int.Parse(objpre.droprole2.SelectedValue.ToString());
                dAO.Res1 = encriptar.Encriptar(objpre.txtRes1.Text.Trim());
                dAO.Res2 = encriptar.Encriptar(objpre.txtRes2.Text.Trim());

                int resultado = dAO.InsertarRespuestasSeguridad();

                if (resultado > 0)
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso completado", "Las respuestas de seguridad se han guardado correctamente.", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                    objpre.Close();
                }
                else if (resultado == -2)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Proceso interrumpido", "El usuario ya tiene dos preguntas de seguridad asignadas. No se pueden agregar más.", Properties.Resources.MensajeWarning);
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Ocurrió un error al guardar las respuestas de seguridad.", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }
        }
        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(objpre.txtRes1.Text) || string.IsNullOrWhiteSpace(objpre.txtRes2.Text))
            {

                MessageBoxP(Color.Yellow, Color.Orange, "Error de validación", "Por favor complete ambas respuestas de seguridad.", Properties.Resources.MensajeWarning);
                return false;
            }

            if (objpre.droprole1.SelectedValue.ToString() == objpre.droprole2.SelectedValue.ToString())
            {
                MandarValoresAlerta(Color.Red, Color.DarkRed, "Error de validación", "Las preguntas de seguridad no pueden ser iguales.", Properties.Resources.ErrorIcono);
                VistaLogin backForm = new VistaLogin();
                return false;
            }

            return true;
        }

        //private string CifrarRespuesta(string respuesta)
        //{
        //    Encryp encryp = new Encryp();
        //    return encryp.Encriptar(respuesta);
        //}
    }
}