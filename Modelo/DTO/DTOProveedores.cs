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
        private string Empresa;

        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Teléfono1 { get => Teléfono; set => Teléfono = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string Empresa1 { get => Empresa; set => Empresa = value; }
    }
}
