using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DAO
{
    internal class DAOFiltroVentas: DTOFiltroVentas
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet FiltrarVenta()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = getConnection()) // Obtén la conexión abierta desde dbContext
                {
                    string query = "EXEC ObtenerVentasPorRangoFechas @FechaInicio, @FechaFin";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FechaInicio", Fechadeinicio);
                        cmd.Parameters.AddWithValue("@FechaFin", Fechafinal);

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
    }
}
