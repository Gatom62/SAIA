using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DAO
{
    public class DAODCSoporte: DAOCorreoRecuperacion
    {
        public DAODCSoporte()
        {
            remintenteCorreo = "soporte.usuario.saia@gmail.com";
            password = "jrkrvdfhpqgosqtd";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            inicializeSmtpClient();
        }
    }
}
