using AgroServicios.Modelo.DAO;
using AgroServicios.Modelo.DTO;
using AgroServicios.Vista.Login;
using System;
using System.Collections.Generic;
using System.Data;
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
        private string role1;
        private string role2;

        public ControladorPreguntasRec(VistaPreguntas Vista, string user)
        {
            objpre = Vista;
            objpre.Load += InitialCharge;
            ChargeValues(user);
            objpre.btnGuardar.Click += InsertarRespuestas;
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


        public void ChargeValues(string user)
        {
            objpre.txtUsuario.Text = user;
        }

        private void InsertarRespuestas(object sender, EventArgs e)
        {
       
                DAOPreguntasRec dAO = new DAOPreguntasRec();
                
                 dAO.Usuario = objpre.txtUsuario.Text.Trim();
                 dAO.Pregunta1 = int.Parse(objpre.droprole1.SelectedValue.ToString());
                 dAO.Pregunta2 = int.Parse(objpre.droprole2.SelectedValue.ToString());
                 dAO.Res1 = objpre.txtRes1.Text.Trim();
                 dAO.Res2 = objpre.txtRes2.Text.Trim();
                
                int resultado = dAO.InsertarRespuestasSeguridad();

                if (resultado > 0)
                {
                    MessageBox.Show("Las respuestas de seguridad se han guardado correctamente.",
                                    "Proceso completado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else if (resultado == -2)
                {
                MessageBox.Show("El usuario ya tiene dos preguntas de seguridad asignadas. No se pueden agregar más.",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar las respuestas de seguridad.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            
        }



        //private bool ValidarEntradas()
        //{
        //    if (string.IsNullOrWhiteSpace(objpre.txtRes1.Text) || string.IsNullOrWhiteSpace(objpre.txtRes2.Text))
        //    {
        //        MessageBox.Show("Por favor, complete ambas respuestas de seguridad.",
        //                        "Error de validación",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Error);
        //        return false;
        //    }

        //    if (objpre.droprole1.SelectedValue.ToString() == objpre.droprole2.SelectedValue.ToString())
        //    {
        //        MessageBox.Show("Las preguntas de seguridad no pueden ser iguales.",
        //                        "Error de validación",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Error);
        //        return false;
        //    }

        //    return true;
        //}

        //private string CifrarRespuesta(string respuesta)
        //{
        //    Encryp encryp = new Encryp();
        //    return encryp.Encriptar(respuesta);
        //}
    }
}
