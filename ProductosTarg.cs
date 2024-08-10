using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios
{
    public partial class ProductosTarg : UserControl
    {
        private int id = 0;
        public ProductosTarg()
        {
            InitializeComponent();
        }
        public int Id {  get { return id; } set {  id = value; } }
        public string Descripcion { 
            get {  return lbldesc.Text; } 
            set {  lbldesc.Text = value; } 
        }
        public Image ImgProducto {
            get { return ptbimg.Image; } 
            set { ptbimg.Image = value; } 
        }
        public string nameProduct
        {
            get { return lblname.Text; }
            set { lblname.Text = value; }
        }
        public string Precio
        {
            get { return lblPrecio.Text; }
            set { lblPrecio.Text = value; }
        }
        public string Code
        {
            get { return lblcodigo.Text; }
            set { lblcodigo.Text = value; }
        }
    }
}
