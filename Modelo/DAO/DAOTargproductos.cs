using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Modelo.DAO
{
    public class DAOTargproductos : DTOTargproductos
    {
        readonly SqlCommand Command = new SqlCommand();

        public void RellenarTargetas(FlowLayoutPanel Contenedor, string filtro = "")
        {
            Command.Connection = getConnection();
            StringBuilder transactSql = new StringBuilder("SELECT * FROM Productos");

            // Verificamos si hay un filtro y lo agregamos a la consulta
            if (!string.IsNullOrEmpty(filtro))
            {
                transactSql.Append(" WHERE Nombre LIKE @filtro OR Codigo LIKE @filtro");
            }

            SqlCommand comando = new SqlCommand(transactSql.ToString(), Command.Connection);
            comando.CommandType = CommandType.Text;

            // Agregamos el parámetro del filtro si es necesario
            if (!string.IsNullOrEmpty(filtro))
            {
                comando.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
            }

            SqlDataReader reader = comando.ExecuteReader();

            Contenedor.Controls.Clear(); // Limpiar los controles antes de agregar los nuevos filtrados

            while (reader.Read())
            {
                // Asignación de datos del producto
                Id = Convert.ToInt32(reader["idProducto"]);
                Nameproduct = reader["Nombre"].ToString();
                Descriptionproduct = reader["Descripcion"].ToString();
                Codeproduct = Convert.ToInt32(reader["Codigo"]);
                Precioproduct = Convert.ToDecimal(reader["Precio"]);
                Imagen = (byte[])reader["imgNombre"];

                // Creación del control personalizado
                ProductosTarg targ = new ProductosTarg
                {
                    Id = Id,
                    nameProduct = Nameproduct,
                    Code = Codeproduct.ToString(),
                    Precio = "$" + Precioproduct.ToString("N2"),
                    Descripcion = Descriptionproduct,
                    ImgProducto = Image.FromStream(new MemoryStream(Imagen))
                };

                // Agregar el control al contenedor
                Contenedor.Controls.Add(targ);
            }

            reader.Close();
            getConnection().Close();
            getConnection().Dispose();
        }
    }

}
