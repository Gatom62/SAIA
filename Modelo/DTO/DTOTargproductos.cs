using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroServicios.Modelo.DTO
{
    public class DTOTargproductos: dbContext
    {
        private int id;
        private string nameproduct;
        private string descriptionproduct;
        private string codeproduct;
        private string precioproduct;
        private byte[] image;

        public int Id { get => id; set => id = value; }
        public string Nameproduct { get => nameproduct; set => nameproduct = value; }
        public string Descriptionproduct { get => descriptionproduct; set => descriptionproduct = value; }
        public string Codeproduct { get => codeproduct; set => codeproduct = value; }
        public string Precioproduct { get => precioproduct; set => precioproduct = value; }
        public byte[] Imagen { get => image; set => image = value; }
    }
}
