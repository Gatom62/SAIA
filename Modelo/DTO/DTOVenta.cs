using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
    class DTOVenta : dbContext
    {
        public int IdVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public int CantidadVendida { get; set; }
    }
}
