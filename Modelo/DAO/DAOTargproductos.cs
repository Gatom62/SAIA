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
    public class DAOTargproductos: DTOTargproductos
    {
        readonly SqlCommand Command = new SqlCommand();
        public void RellenarTargetas(FlowLayoutPanel Contenedor)
        {
            Command.Connection = getConnection();
            string transactSql = "SELECT * FROM Productos";
            SqlCommand comando = new SqlCommand(transactSql, Command.Connection);
            comando.CommandType = CommandType.Text;
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Id = Convert.ToInt32(reader[0]);
                Nameproduct = reader[1].ToString();
                Descriptionproduct = reader[5].ToString();
                Codeproduct = Convert.ToInt32(reader[6]);
                Precioproduct = Convert.ToDecimal(reader[3]);
                Imagen = ((byte[])reader[7]);

                ProductosTarg targ = new ProductosTarg();
                targ.Id = Id;
                targ.nameProduct = Nameproduct;
                targ.Code = Codeproduct.ToString();
                targ.Precio = "$" + Precioproduct.ToString("N2");
                targ.Descripcion = Descriptionproduct;
                MemoryStream ms = new MemoryStream(Imagen);
                targ.ImgProducto = Image.FromStream(ms);
                Contenedor.Controls.Add(targ);
            }
            getConnection().Close();
            getConnection().Dispose();
        }

    }
}
