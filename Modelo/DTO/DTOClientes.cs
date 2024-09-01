using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
    class DTOClientes : dbContext
    {
        private int idCliente;
        private string Nombre;
        private string Telefono;
        private string Correo;
        private string Dirreccion;
        private string DUI;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string Dirreccion1 { get => Dirreccion; set => Dirreccion = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
    }
}
