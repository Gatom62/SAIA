using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
     class DTOProveedores:dbContext
    {
        //Proveedores
        private int idProveedor;
        private string Nombre;
        private string DUI;
        private string Teléfono;
        private string Correo;
        private int Marca;
        

        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Teléfono1 { get => Teléfono; set => Teléfono = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public int Marca1 { get => Marca; set => Marca = value; }
    }
}
