using AgroServicios.Controlador.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Vista.MenuPrincipal
{
    public partial class VistaCarrito : Form
    {
        // Campo estático privado para mantener una sola instancia de VistaCarrito
        private static VistaCarrito _instance;

        // Propiedad estática para acceder a la instancia de VistaCarrito
        public static VistaCarrito Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VistaCarrito();
                }
                return _instance;
            }
        }

        public ControladorCarrito ControladorCarrito { get; private set; }
        // Constructor privado para evitar la creación de nuevas instancias fuera de esta clase
        private VistaCarrito()
        {
            InitializeComponent();
            ControladorCarrito = new ControladorCarrito(this);
        }

    }
}



