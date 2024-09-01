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
        // Campo estático privado que almacena la única instancia de la clase VistaCarrito
        // Este campo es privado para evitar que otras clases creen una nueva instancia
        private static VistaCarrito _instance;

        // Propiedad estática pública para acceder a la instancia de VistaCarrito
        // Esta propiedad controla el acceso a la única instancia (Singleton) de la clase
        public static VistaCarrito Instance
        {
            get
            {
                // Si la instancia aún no ha sido creada, se crea aquí
                if (_instance == null)
                {
                    _instance = new VistaCarrito();
                }

                // Se devuelve la instancia única de la clase
                return _instance;
            }
        }

        // Propiedad para acceder al controlador asociado con VistaCarrito
        // Esta propiedad es de solo lectura fuera de esta clase
        public ControladorCarrito ControladorCarrito { get; private set; }

        // Constructor privado para evitar la creación de instancias fuera de esta clase
        // Esto asegura que solo se pueda crear una instancia a través de la propiedad estática Instance
        private VistaCarrito()
        {
            InitializeComponent();

            // Inicializa el controlador del carrito pasando la referencia de esta instancia
            ControladorCarrito = new ControladorCarrito(this);
        }

        // Método estático público para restablecer (limpiar) la instancia actual de VistaCarrito
        // Este método es necesario para manejar la limpieza del formulario y liberar recursos
        public static void ResetInstance()
        {
            if (_instance != null)
            {
                // Llama a Dispose para liberar todos los recursos utilizados por la instancia
                _instance.Dispose();

                // Establece la instancia en null para permitir que el recolector de basura (GC) la limpie
                _instance = null;
            }
        }
    }
}




