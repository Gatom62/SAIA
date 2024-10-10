using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using AgroServicios.Vista.Productos1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroServicios.Controlador.Productos1
{
    class ControladorCreateMarca1
    {
        VistaCreateMarca ObjCreateMarca;
        private int accion;
        private string role;

        /// <summary>
        /// Constructor para inserción de datos
        /// </summary>
        /// <param name="Vista"></param>
        /// <param name="accion"> INSERCIÓN </param>
        public ControladorCreateMarca1(VistaCreateMarca Vista, int accion)
        {
            ObjCreateMarca = Vista;
            this.accion = accion;
            ObjCreateMarca.Load += new EventHandler(LoadData);
            //Evento click de botones
            ObjCreateMarca.btnIngresarMarca.Click += new EventHandler(NuevoRegistro);
            ObjCreateMarca.cmsElimarProducto.Click += new EventHandler(EliminarMarca);
            ObjCreateMarca.cmsEditarMarca.Click += new EventHandler(UpdateMarca);
        }
        void MessageBoxP(Color backcolor, Color color, string title, string text, Image icon)
        {
            AlertExito frm = new AlertExito();

            frm.BackColorAlert = backcolor;

            frm.ColorAlertBox = color;

            frm.TittlAlertBox = title;

            frm.TextAlertBox = text;

            frm.IconeAlertBox = icon;

            frm.ShowDialog();
        }
        void MandarValoresAlerta(Color backcolor, Color color, string title, string text, Image icon)
        {
            MessagePersonal message = new MessagePersonal();
            message.BackColorAlert = backcolor;
            message.ColorAlertBox = color;
            message.TittlAlertBox = title;
            message.TextAlertBox = text;
            message.IconeAlertBox = icon;
            message.ShowDialog();
        }
        private void UpdateMarca(object sender, EventArgs e)
        {
            int pos = ObjCreateMarca.GriewViewMarcas.CurrentRow.Index;
            int id;
            string Name;

            id = int.Parse(ObjCreateMarca.GriewViewMarcas[0, pos].Value.ToString());
            Name = ObjCreateMarca.GriewViewMarcas[1, pos].Value.ToString();

            VistaUbdateMarca vistaUpdate = new VistaUbdateMarca(1, id, Name);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }

        public void NuevoRegistro(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (ObjCreateMarca.txtNombreMarca.Text == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "There are empty fields", Properties.Resources.MensajeWarning);
                }
                else 
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay campos vacios", Properties.Resources.MensajeWarning);
                }
                return;
            }

            // Validar que el nombre de la marca no exceda 15 caracteres
            if (!ValidarNombre(ObjCreateMarca.txtNombreMarca.Text))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "There are more than 15 characters in the brand name", Properties.Resources.MensajeWarning);
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "Hay mas de 15 carácteres en el nombre de la marca", Properties.Resources.MensajeWarning);
                }

                return;
            }

            //Realizamos el proceso de inserccion y de optencion de respuesta departe de la base de datos
            DAOProductos1 DaoInsert = new DAOProductos1();
            // Asignar los valores a las propiedades de DaoInsert
            DaoInsert.NombreMarca1 = ObjCreateMarca.txtNombreMarca.Text.Trim();
            //Pedimos una contestación por parte de la base de datos, si nos manda un uno es que si se logro realizar correctamente la insercción
            int valorRetornado = DaoInsert.RegistrarMarca();
            if (valorRetornado == 1)
            {
                //Mensaje de afirmacion si se pudo realizar la inserccion
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Process carried out", "The trademark was registered", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                }
                else
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "La marca fue registrada", Properties.Resources.comprobado);
                    VistaLogin backForm = new VistaLogin();
                }
            }
            else
            {
                //Mensaje de error si se no se pudo realizar la inserccion
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Check that the brand is not being duplicated", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique que la marca no se este duplicando", Properties.Resources.ErrorIcono);
                    VistaLogin backForm = new VistaLogin();
                }
            }

            // Método para validar que el nombre de la marca no exceda los 15 caracteres
            bool ValidarNombre(string nombre)
            {
                return nombre.Length <= 15;
            }
        }
        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }
        public void RefrescarData()
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOProductos1 dAOProductos1 = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerMarcas
            DataSet ds = dAOProductos1.ObtenerMarcas();
            ////Llenar DataGridView
            ObjCreateMarca.GriewViewMarcas.DataSource = ds.Tables["ViewMarcas"];

            //Para ocultar columnas que no creo que sehan nesesarias de ver
            ObjCreateMarca.GriewViewMarcas.Columns["Codigo de la Marca"].Visible = false;
            // Traducir encabezados de las columnas
            TraducirEncabezados(ObjCreateMarca.GriewViewMarcas);
        }
        private void TraducirEncabezados(DataGridView dgv)
        {
            if (ControladorIdioma.idioma == 1)
            {
                dgv.Columns["Nombre de la Marca"].HeaderText = "Brand Name";
            }
            else
            {
                dgv.Columns["Nombre de la Marca"].HeaderText = "Nombre de la Marca";
            }
        }
        private void EliminarMarca(object sender, EventArgs e)
        {
            int pos = ObjCreateMarca.GriewViewMarcas.CurrentRow.Index;
            if (ControladorIdioma.idioma == 1)
            {
                if (MessageBox.Show($"¿Surely you want to delete: \n {ObjCreateMarca.GriewViewMarcas[1, pos].Value.ToString()}\nThe deletion will be permanent.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOProductos1 daodelete = new DAOProductos1();
                    daodelete.IdMarca = int.Parse(ObjCreateMarca.GriewViewMarcas[0, pos].Value.ToString());
                    int valorretornado = daodelete.DeleteMarca();
                    if (valorretornado == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Process carried out", "The mark was successfully removed", Properties.Resources.comprobado);
                        VistaLogin backForm = new VistaLogin();
                        RefrescarData();
                    }
                    else
                    {
                        MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Check if the trademark is associated with other registrations", Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                    }
                }
            }
            else
            {
                if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjCreateMarca.GriewViewMarcas[1, pos].Value.ToString()}\nLa eliminación sera permanente.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOProductos1 daodelete = new DAOProductos1();
                    daodelete.IdMarca = int.Parse(ObjCreateMarca.GriewViewMarcas[0, pos].Value.ToString());
                    int valorretornado = daodelete.DeleteMarca();
                    if (valorretornado == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Proceso realizado", "La marca se elimino correctamente", Properties.Resources.comprobado);
                        VistaLogin backForm = new VistaLogin();
                        RefrescarData();
                    }
                    else
                    {
                        MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Verifique si la marca esta asociada a otros registros", Properties.Resources.ErrorIcono);
                        VistaLogin backForm = new VistaLogin();
                    }
                }
            }
        }
    }
}
