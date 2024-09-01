using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
    internal class DTOCarrito: dbContext
    {
        private int idcliente;
        private int idempleado;
        private DateTime fechaventa;
        private decimal montototal;

        public int Idcliente { get => idcliente; set => idcliente = value; }
        public int Idempleado { get => idempleado; set => idempleado = value; }
        public DateTime Fechaventa { get => fechaventa; set => fechaventa = value; }
        public decimal Montototal { get => montototal; set => montototal = value; }
    }
}
