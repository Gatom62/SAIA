using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
    internal class DTODevoluciones: dbContext
    {
        private int idventa;
        private int nombreproducto;
        private int nombrecliente;
        private DateTime fechadeladevolucion;
        private int cantidadProducto;
        private decimal montodevolucion;
        private string motivodevolucion;

        private int idVenta;
        private decimal montoTotal;
        private int cantidadVendida;

        public int Idventa { get => idventa; set => idventa = value; }
        public int Nombreproducto { get => nombreproducto; set => nombreproducto = value; }
        public int Nombrecliente { get => nombrecliente; set => nombrecliente = value; }
        public DateTime Fechadeladevolucion { get => fechadeladevolucion; set => fechadeladevolucion = value; }
        public int CantidadProducto { get => cantidadProducto; set => cantidadProducto = value; }
        public decimal Montodevolucion { get => montodevolucion; set => montodevolucion = value; }
        public string Motivodevolucion { get => motivodevolucion; set => motivodevolucion = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
        public decimal MontoTotal { get => montoTotal; set => montoTotal = value; }
        public int CantidadVendida { get => cantidadVendida; set => cantidadVendida = value; }
    }
}
