using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Modelo.DAO;
using AgroServicios.Modelo.DTO;
using AgroServicios.Vista.Cuentas;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.Notificación;
using AgroServicios.Vista.Productos1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgroServicios.Controlador.Productos1
{
    class ControladorVistaProductos1
    {
        VistaProductos ObjProductos;

        public ControladorVistaProductos1(VistaProductos objProductos)
        {
            ObjProductos = objProductos;
            ObjProductos.Load += new EventHandler(LoadData);
            //Evento click de botones
            ObjProductos.ptbback.Click += new EventHandler(VolverForm);
            ObjProductos.btnAgregarProducto.Click += new EventHandler(NuevoProducto);
            ObjProductos.btnAgregarMarca.Click += new EventHandler(NuevaMarca);
            ObjProductos.cmsElimarProducto.Click += new EventHandler(EliminarProducto);
            ObjProductos.cmsEditarProducto.Click += new EventHandler(EditarProducto);
            ObjProductos.cmsInformacion.Click += new EventHandler(InformacionProducto);
            objProductos.txtBuscarP.KeyPress += new KeyPressEventHandler(Search);
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
        private void Search(object sender, KeyPressEventArgs e)
        {
            // Verifica que la tecla presionada sea Enter antes de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarPro();
                e.Handled = true;
            }
        }
        private void VolverForm(object sender, EventArgs e)
        {
            // Cierra la vista actual
            ObjProductos.Close();
        }
        void BuscarPro()
        {
           DAOProductos1 dao = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = dao.BuscarProducto(ObjProductos.txtBuscarP.Text.Trim());
            //Llenar DataGridView
            ObjProductos.GriewViewProductos.DataSource = ds.Tables["Productos"];
        }
        public void LoadData(object sender, EventArgs e)
        {
            RefrescarData();
        }
        public void RefrescarData()
        {
            //Objeto de la clase DAOAdminUsuarios
            DAOProductos1 dAOProductos1 = new DAOProductos1();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerProductos
            DataSet ds = dAOProductos1.ObtenerProductos();
            ////Llenar DataGridView
            ObjProductos.GriewViewProductos.DataSource = ds.Tables["Productos"];

            //Para ocultar columnas que no creo que sehan nesesarias de ver
            //ObjProductos.GriewViewProductos.Columns["ID del producto"].Visible = false;
            ObjProductos.GriewViewProductos.Columns["imgNombre"].Visible = false;
            ObjProductos.GriewViewProductos.Columns["Descripcion"].Visible = false;
            // Traducir encabezados de las columnas
            TraducirEncabezados(ObjProductos.GriewViewProductos);
        }
        private void TraducirEncabezados(DataGridView dgv)
        {
            if (ControladorIdioma.idioma == 1)
            {
                dgv.Columns["idProducto"].HeaderText = "Product Identification";
                dgv.Columns["Nombre"].HeaderText = "Product name";
                dgv.Columns["idMarca"].HeaderText = "Product brand";
                dgv.Columns["Precio"].HeaderText = "Product price";
                dgv.Columns["Stock"].HeaderText = "Quantity of product in the system";
                dgv.Columns["Descripcion"].HeaderText = "Product Description";
                dgv.Columns["Codigo"].HeaderText = "Product code";
                dgv.Columns["imgNombre"].HeaderText = "Product image";
            }
            else
            {
                dgv.Columns["idProducto"].HeaderText = "ID del producto";
                dgv.Columns["Nombre"].HeaderText = "Nombre del producto";
                dgv.Columns["idMarca"].HeaderText = "Marca del producto";
                dgv.Columns["Precio"].HeaderText = "Precio del producto";
                dgv.Columns["Stock"].HeaderText = "Cantidad del producto en el sistema";
                dgv.Columns["Descripcion"].HeaderText = "Descripción del producto";
                dgv.Columns["Codigo"].HeaderText = "Codigo del producto";
                dgv.Columns["imgNombre"].HeaderText = "Imagen del producto";
            }
        }
        private void NuevoProducto(object sender, EventArgs e)
        {
            VistaCreateProducto nuevoProducto = new VistaCreateProducto(1);
            nuevoProducto.ShowDialog();
            RefrescarData();
        }

        private void NuevaMarca(object sender, EventArgs e)
        {
            VistaCreateMarca nuevaMarca = new VistaCreateMarca(1);
            nuevaMarca.ShowDialog();
            RefrescarData();
        }

        private void InformacionProducto(object sender, EventArgs e)
        {
            if (ObjProductos.GriewViewProductos.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "You have not selected any product", Properties.Resources.MensajeWarning);
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "No a seleccionado ningun producto", Properties.Resources.MensajeWarning);
                }
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjProductos.GriewViewProductos.CurrentRow.Index;
            int id, idMarc;
            string Name, code, stock, price, description, marc;
            byte[] imagen;

            id = int.Parse(ObjProductos.GriewViewProductos[0, pos].Value.ToString());
            idMarc = int.Parse(ObjProductos.GriewViewProductos[2, pos].Value.ToString());
            Name = ObjProductos.GriewViewProductos[1, pos].Value.ToString();
            code = ObjProductos.GriewViewProductos[6, pos].Value.ToString();
            stock = ObjProductos.GriewViewProductos[4, pos].Value.ToString();
            price = ObjProductos.GriewViewProductos[3, pos].Value.ToString();
            description = ObjProductos.GriewViewProductos[5, pos].Value.ToString();
            imagen = (byte[])ObjProductos.GriewViewProductos[7, pos].Value;
            marc = ObjProductos.GriewViewProductos[2, pos].Value.ToString();

            VistaUbdateProducto vistaUpdate = new VistaUbdateProducto(2, id, idMarc, Name, stock, price, description, marc, code, imagen);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }
        private void EditarProducto(object sender, EventArgs e)
        {
            if (ObjProductos.GriewViewProductos.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "You have not selected any product", Properties.Resources.MensajeWarning);
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "No a seleccionado ningun producto", Properties.Resources.MensajeWarning);
                }
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjProductos.GriewViewProductos.CurrentRow.Index;
            int id, idMarc;
            string Name, code, stock, price, description, marc;
            byte[] imagen;

            id = int.Parse(ObjProductos.GriewViewProductos[0, pos].Value.ToString());
            idMarc = int.Parse(ObjProductos.GriewViewProductos[2, pos].Value.ToString());
            Name = ObjProductos.GriewViewProductos[1, pos].Value.ToString();
            code = ObjProductos.GriewViewProductos[6, pos].Value.ToString();
            stock = ObjProductos.GriewViewProductos[4, pos].Value.ToString();
            price = ObjProductos.GriewViewProductos[3, pos].Value.ToString();
            description = ObjProductos.GriewViewProductos[5, pos].Value.ToString();
            imagen = (byte[])ObjProductos.GriewViewProductos[7, pos].Value;
            marc = ObjProductos.GriewViewProductos[2, pos].Value.ToString();

            VistaUbdateProducto vistaUpdate = new VistaUbdateProducto(1, id, idMarc, Name, stock, price, description, marc, code, imagen);
            vistaUpdate.ShowDialog();
            RefrescarData();
        }

        private void EliminarProducto(object sender, EventArgs e)
        {
            if (ObjProductos.GriewViewProductos.CurrentRow == null)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "You have not selected any product", Properties.Resources.MensajeWarning);
                }
                else
                {
                    MessageBoxP(Color.Yellow, Color.Orange, "Error", "No a seleccionado ningun producto", Properties.Resources.MensajeWarning);
                }
                return; // Salir del método si no hay ninguna fila seleccionada
            }

            int pos = ObjProductos.GriewViewProductos.CurrentRow.Index;

            if (ControladorIdioma.idioma == 1)
            {
                if (MessageBox.Show($"¿Surely you want to delete: \n {ObjProductos.GriewViewProductos[1, pos].Value.ToString()}\nThe deletion will be permanent.", "Confirm action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOProductos1 daodelete = new DAOProductos1();
                    daodelete.IdProducto = int.Parse(ObjProductos.GriewViewProductos[0, pos].Value.ToString());
                    daodelete.IdMarca = int.Parse(ObjProductos.GriewViewProductos[2, pos].Value.ToString());
                    int valorretornado = daodelete.DeleteProducto();
                    if (valorretornado == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Process carried out", "The product was removed successfully", Properties.Resources.comprobado);
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
                if (MessageBox.Show($"¿Seguro que deseas eliminar a: \n {ObjProductos.GriewViewProductos[1, pos].Value.ToString()}\nLa eliminación sera permanente.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAOProductos1 daodelete = new DAOProductos1();
                    daodelete.IdProducto = int.Parse(ObjProductos.GriewViewProductos[0, pos].Value.ToString());
                    daodelete.IdMarca = int.Parse(ObjProductos.GriewViewProductos[2, pos].Value.ToString());
                    int valorretornado = daodelete.DeleteProducto();
                    if (valorretornado == 1)
                    {
                        MandarValoresAlerta(Color.LightGreen, Color.SeaGreen, "Proceso realizado", "El producto se elimino correctamente", Properties.Resources.comprobado);
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
