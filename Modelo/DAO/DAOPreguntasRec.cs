﻿using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DAO
{
    internal class DAOPreguntasRec: DTOPreguntasRec
    {
        readonly SqlCommand Command = new SqlCommand();

        public DataSet LlenarCombo()
        {
            try
            {
                //Se crea una conexión para garantizar que efectivamente haya conexión a la base.
                Command.Connection = getConnection();
                //**
                //Se crea el query que indica la acción que el sistema desea realizar con la base de datos
                //En caso sea una consulta parametrizada se deberá respetar la sintaxis sobre como colocar parametros en la instrucción sql (REVISAR LOS DEMÁS MANTENIMIENTOS PARA VER COMO SE CREAN PARAMETROS Y SE LES DA VALORES).
                string query = "SELECT * FROM PreguntasSeguridad";
                //Se crea un comando de tipo sql al cual se le pasa el query y la conexión, esto para que el sistema sepa que hacer y donde hacerlo.
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                //ExecuteNonQuery indicará cuantos filas fueron afectadas, es decir, cuantas filas de datos se ingresaron o encontraron, por lo general cuando es una consulta su valor puede ser 1 o mayor a 1.
                cmd.ExecuteNonQuery();
                //Se crea un objeto SqlDataAdapter para poder llenar el DataSet que posteriormente utilizaremos, además recibe el comando sql
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //Se crea un DataSet que será el objeto de retorno del método
                DataSet ds = new DataSet();
                //Rellenamos el DataSet con los datos encontrados con el SqlDataAdapter, además, indicamos de donde provienen los datos
                adp.Fill(ds, "PreguntasSeguridad");
                //Retornamos el objeto DataSet
                return ds;
            }
            catch (Exception)
            {
                //Se retorna null si durate la ejecución del try ocurrió algún error
                return null;
            }
            finally
            {
                //Independientemente se haga o no el proceso cerramos la conexión
                getConnection().Close();
            }
        }

        public int InsertarRespuestasSeguridad()
        {
            try
            {
                // Conectar a la base de datos
                Command.Connection = getConnection();

                // Query para insertar la primera pregunta y respuesta
                string query1 = "INSERT INTO RespuestasSeguridad (Usuario, PreguntaID, RespuestaCifrada) " +
                                "VALUES (@Usuario, @Pregunta1, @Res1)";
                SqlCommand cmd1 = new SqlCommand(query1, Command.Connection);
                cmd1.Parameters.AddWithValue("Usuario", Usuario);
                cmd1.Parameters.AddWithValue("Pregunta1", Pregunta1);
                cmd1.Parameters.AddWithValue("Res1", Res1);

                // Ejecutar el primer comando
                int respuesta1 = cmd1.ExecuteNonQuery();

                // Query para insertar la segunda pregunta y respuesta
                string query2 = "INSERT INTO RespuestasSeguridad (Usuario, PreguntaID, RespuestaCifrada) " +
                                "VALUES (@Usuario, @Pregunta2, @Res2)";
                SqlCommand cmd2 = new SqlCommand(query2, Command.Connection);
                cmd2.Parameters.AddWithValue("Usuario", Usuario);
                cmd2.Parameters.AddWithValue("Pregunta2", Pregunta2);
                cmd2.Parameters.AddWithValue("Res2", Res2);

                // Ejecutar el segundo comando
                int respuesta2 = cmd2.ExecuteNonQuery();

                // Verificar si ambas inserciones fueron exitosas
                if (respuesta1 == 1 && respuesta2 == 1)
                {
                    return 1; // Éxito
                }
                else
                {
                    return 0; // Fallo en una de las inserciones
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al insertar las respuestas de seguridad: " + ex.Message);
                return -1; // Indica error
            }
            finally
            {
                // Cerrar la conexión
                getConnection().Close();
            }
        }

        public bool VerificarRespuestas()
        {
            try
            {
                Command.Connection = getConnection();

                // Consulta para verificar la primera respuesta
                string query1 = "SELECT COUNT(*) FROM RespuestasSeguridad WHERE Usuario = @Usuario " +
                                "AND PreguntaID = @Pregunta1 AND RespuestaCifrada = @Respuesta1";

                SqlCommand cmd1 = new SqlCommand(query1, Command.Connection);
                cmd1.Parameters.AddWithValue("Usuario", Usuario);
                cmd1.Parameters.AddWithValue("Pregunta1", Pregunta1);
                cmd1.Parameters.AddWithValue("Respuesta1", Res1);

                int count1 = (int)cmd1.ExecuteScalar();

                // Consulta para verificar la segunda respuesta
                string query2 = "SELECT COUNT(*) FROM RespuestasSeguridad WHERE Usuario = @Usuario " +
                                "AND PreguntaID = @Pregunta2 AND RespuestaCifrada = @Respuesta2";

                SqlCommand cmd2 = new SqlCommand(query2, Command.Connection);
                cmd2.Parameters.AddWithValue("Usuario", Usuario);
                cmd2.Parameters.AddWithValue("Pregunta2", Pregunta2);
                cmd2.Parameters.AddWithValue("Respuesta2", Res2);

                int count2 = (int)cmd2.ExecuteScalar();

                // Ambas respuestas deben ser correctas
                return count1 > 0 && count2 > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar las respuestas de seguridad: " + ex.Message);
                return false;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
