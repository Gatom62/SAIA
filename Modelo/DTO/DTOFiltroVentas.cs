using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
    internal class DTOFiltroVentas: dbContext
    {
        private DateTime fechadeinicio;
        private DateTime fechafinal;

        public DateTime Fechadeinicio { get => fechadeinicio; set => fechadeinicio = value; }
        public DateTime Fechafinal { get => fechafinal; set => fechafinal = value; }
    }
}
