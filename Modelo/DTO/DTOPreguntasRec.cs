using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
    internal class DTOPreguntasRec: dbContext
    {
        private string usuario;
        private int pregunta1;
        private int pregunta2;
        private string res1;
        private string res2;

        public string Usuario { get => usuario; set => usuario = value; }
        public int Pregunta1 { get => pregunta1; set => pregunta1 = value; }
        public int Pregunta2 { get => pregunta2; set => pregunta2 = value; }
        public string Res1 { get => res1; set => res1 = value; }
        public string Res2 { get => res2; set => res2 = value; }
    }
}
