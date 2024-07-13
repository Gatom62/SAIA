using System;

namespace AgroServicios.Modelo.DTO
{
    class DTOAdminUsers : dbContext
    {
        private int IdEmpleado;
        private string Usuario;
        private string Password;
        private string Nombre;
        private string Apellido;
        private DateTime fechaNacimiento;
        private string Direction;
        private string Phone;
        private string Correo;
        private string dui;
        private int salario;

        public int IdEmpleado1 { get => IdEmpleado; set => IdEmpleado = value; }
        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direction1 { get => Direction; set => Direction = value; }
        public string Phone1 { get => Phone; set => Phone = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string Dui { get => dui; set => dui = value; }
        public int Salario { get => salario; set => salario = value; }
    }
}
