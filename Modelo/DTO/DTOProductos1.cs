using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
    class DTOProductos1 : dbContext
    {
        private int idProducto;
        private string Nombre;
        private string Precio;
        private string Stock;
        private byte[] img;
        private string Descripcion;
        private string Codigo;
        private string CodigoBarrav2;
        //Marcas
        private int idMarca;
        private string NombreMarca;
        //Estantes
        private int idEstante;

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Precio1 { get => Precio; set => Precio = value; }
        public string Stock1 { get => Stock; set => Stock = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string NombreMarca1 { get => NombreMarca; set => NombreMarca = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Codigo1 { get => Codigo; set => Codigo = value; }
        public byte[] Img { get => img; set => img = value; }
        public int IdEstante { get => idEstante; set => idEstante = value; }
        public string CodigoBarrav21 { get => CodigoBarrav2; set => CodigoBarrav2 = value; }
    }
}
