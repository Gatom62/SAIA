using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Modelo.DAO
{
    class DAOCierreCaja : DTOCierreCaja
    {
        readonly SqlCommand command = new SqlCommand();

        public List<string> ObtenerCorreosManagers()
        {
            List<string> correos = new List<string>();

            string query = "SELECT Correo FROM VistaEmpleadosConRol WHERE Rol = 'Manager'";

            using (SqlConnection connection = getConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        correos.Add(reader["Correo"].ToString());
                    }
                }
            }

            return correos;
        }
        public DataSet FIltrarVentasHoy()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = getConnection()) // Obtén la conexión abierta desde dbContext
                {
                    string query = "EXEC VentasHoy";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {

                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            adp.Fill(ds); // Llena el DataSet con los resultados
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al filtrar las ventas: " + ex.Message);
                // Considera registrar el error o manejarlo de otra manera según sea necesario
            }

            return ds;
        }
        public int RegistrarCierreCaja(string empleado, decimal totalDia, DateTime fechaCierre)
        {
            int filasAfectadas = 0;
            string query = "INSERT INTO CierresCaja (FechaCierre, MontoTotal, EmpleadoCierre) VALUES (@Fecha, @Total, @Empleado)";

            using (SqlConnection connection = getConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Definir los parámetros de la consulta
                    command.Parameters.AddWithValue("@Empleado", empleado);
                    command.Parameters.AddWithValue("@Total", totalDia);
                    command.Parameters.AddWithValue("@Fecha", fechaCierre);

                    try
                    {

                        filasAfectadas = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al registrar el cierre de caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return filasAfectadas;
        }
    }
}
