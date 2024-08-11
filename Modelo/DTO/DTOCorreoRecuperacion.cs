using AgroServicios.Controlador;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AgroServicios.Modelo.DTO
{
    public class DTOCorreoRecuperacion : dbContext
    {
        SqlCommand Command = new SqlCommand();


        protected string remintenteCorreo { get; set; }
        protected string password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }
        
    }
}