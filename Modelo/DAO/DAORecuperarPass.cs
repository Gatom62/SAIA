using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DAO
{
    public class DAORecuperarPass
    {
        public string recoverPassword(string userRequesting)
        {
            return new DTOCorreoRecuperacion().recoverPassword(userRequesting);
        }
    }
}
