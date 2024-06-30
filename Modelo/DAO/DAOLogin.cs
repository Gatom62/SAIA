using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using AgroServicios.Modelo.DTO;

namespace AgroServicios.Modelo.DAO
{
    internal class DAOLogin: DTOLogin
    {
        SqlCommand Command = new SqlCommand();
        public int Login()
        {
            try
            {
                Command.Connection = getConnection();
                Command.CommandText = "SELECT Usuario FROM Empleados WHERE Usuario = @username AND Contraseña = @password";
                Command.Parameters.AddWithValue("@username", Username);
                Command.Parameters.AddWithValue("@password", Password);
                object result = Command.ExecuteScalar();

                if (result != null && string.Equals(result.ToString(), Username, StringComparison.Ordinal))
                {
                    return 0; // Usuario correcto
                }
                else
                {
                    return 1; // Usuario o contraseña incorrecta
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
