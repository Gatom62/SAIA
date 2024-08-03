using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Modelo
{
    public class dbContext
    {
        public static SqlConnection getConnection()
        {

            try
            {
                string server = "SQL8006.site4now.net";
                string database = "db_aab115_siasbase";
                string userId = "db_aab115_siasbase_admin";
                string Password = "MichI#12@3";
                SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; User Id = {userId}; Password = {Password}");

                //string server = "DESKTOP-QR03KRF";
                //string database = "dbGnosis";
                //SqlConnection conexion = new SqlConnection($"Server = {server}; DataBase = {database}; Integrated Security = true");
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message} Código de error: EC-001 \nNo fue posible conectarse a la base de datos, favor verifique las credenciales o que tenga acceso al sistema.", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            //try
            //{
            //    //string server = "DESKTOP-QR03KRF";
            //    string server = "AYALA\\SQLEXPRESS";
            //    string database = "Tienda_de_Agroservicio";
            //    SqlConnection conexion = new SqlConnection("Server =" + server +
            //                                                     "; DataBase = " + database +
            //                                                     "; Integrated Security = true;");
            //    conexion.Open();
            //    return conexion;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}

        }
    }
}
