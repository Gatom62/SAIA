using AgroServicios.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DAO
{
    // Clase DAORecuperarPass que maneja la recuperación de contraseñas
    public class DAORecuperarPass
    {
        // Método público para recuperar la contraseña
        // Toma como parámetro el usuario o correo que está solicitando la recuperación
        public string recoverPassword(string userRequesting)
        {
            // Llama al método recoverPassword de la clase DAOCorreoRecuperacion
            // y le pasa el usuario o correo solicitado, luego devuelve el resultado
            return new DAOCorreoRecuperacion().recoverPassword(userRequesting);
        }
    }
}

