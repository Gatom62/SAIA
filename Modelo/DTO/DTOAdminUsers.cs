using System;

namespace AgroServicios.Modelo.DTO
{
    class DTOAdminUsers : dbContext
    {
        //Empleados
        private int idEmpleado;
        private string Nombre;
        private string Apellidos;
        private DateTime FechaDeNacimiento;
        private string Telefono;
        private string Correo;
        private string DUI;
        private string Direccion;
        //Usuarios
        private string Usuario;
        private string Contraseña;
        private int IntentosUsuario;
        private int idCategoria;
        private byte[] img;

        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellidos1 { get => Apellidos; set => Apellidos = value; }
        public DateTime FechaDeNacimiento1 { get => FechaDeNacimiento; set => FechaDeNacimiento = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }
        public int IntentosUsuario1 { get => IntentosUsuario; set => IntentosUsuario = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public byte[] Img { get => img; set => img = value; }
    }
}
