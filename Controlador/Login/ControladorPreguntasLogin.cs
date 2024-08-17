using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Login
{
    internal class ControladorPreguntasLogin
    {
        VistaPreguntasLogin objpre;

        public ControladorPreguntasLogin(VistaPreguntasLogin Vista)
        {
            objpre = Vista;
            objpre.Load += InitialCharge;
            objpre.btnGuardar.Click += VerificarRespuestas;
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
                    MessageBox.Show("La tabla 'PreguntasSeguridad' no se encontró en el DataSet.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void VerificarRespuestas(object sender, EventArgs e)
        {
            DAOPreguntasRec daoPreguntas = new DAOPreguntasRec();

            daoPreguntas.Usuario = objpre.txtUsuario.Text.Trim();
            daoPreguntas.Pregunta1 = int.Parse(objpre.droprole1.SelectedValue.ToString());
            daoPreguntas.Res1 = objpre.txtRes1.Text.Trim();
            daoPreguntas.Pregunta2 = int.Parse(objpre.droprole2.SelectedValue.ToString());
            daoPreguntas.Res2 = objpre.txtRes2.Text.Trim();

            if (daoPreguntas.VerificarRespuestas())
            {
                MessageBox.Show("Respuestas correctas. Puede restablecer su contraseña.",
                                "Verificación completada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                string user = objpre.txtUsuario.Text;
                VistaRestContraPreguntas vista = new VistaRestContraPreguntas(user);
                vista.ShowDialog();
            }
            else
            {
                MessageBox.Show("Las respuestas no son correctas. Inténtelo de nuevo.",
                                "Verificación fallida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
