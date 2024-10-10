using AgroServicios.Modelo.DAO;
using AgroServicios.Modelo.DTO;
using AgroServicios.Vista.Estadisticas.Devoluciones;
using AgroServicios.Vista.Login;
using AgroServicios.Vista.MenuPrincipal;
using AgroServicios.Vista.Notificación;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AgroServicios.Modelo.DAO.DAODevoluciones;

namespace AgroServicios.Controlador.ControladorStats
{
    class ControladorDevoluciones
    {
        VistaDevoluciones objdev;
        public ControladorDevoluciones(VistaDevoluciones Vista)
        {
            objdev = Vista;

            objdev.Load += EventosIniciales;
            objdev.btnCrearDevoluciones.Click += CrearDevoluciones;
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
        private void CrearDevoluciones(object sender, EventArgs e)
        {
            // Validación para la fecha de la devolución: debe ser hoy
            DateTime fechaDev = objdev.pickerFechaDev.Value.Date;
            if (fechaDev != DateTime.Now.Date)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "The return date must be today", Properties.Resources.ErrorIcono);
                    return;
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "La fecha de devolución debe ser hoy", Properties.Resources.ErrorIcono);
                    return;
                }
            }

            // Validación para que la cantidad de producto sea mayor a cero
            if (objdev.nudMonto.Value <= 0)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Product quantity must be greater than zero", Properties.Resources.ErrorIcono);
                    return;
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "La cantidad del producto debe ser mayor a cero", Properties.Resources.ErrorIcono);
                    return;
                }
            }

            // Validación para que el monto de devolución no quede vacío y solo acepte números
            decimal montoDevolucion;
            if (string.IsNullOrWhiteSpace(objdev.txtMonto.Text.Trim()) || !decimal.TryParse(objdev.txtMonto.Text.Trim(), out montoDevolucion))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Return amount is invalid or empty", Properties.Resources.ErrorIcono);
                    return;
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "El monto de devolución es inválido o está vacío", Properties.Resources.ErrorIcono);
                    return;
                }
            }
            // Validación para que el monto de devolución no sea negativo
            if (montoDevolucion < 0)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "The return amount cannot be negative", Properties.Resources.ErrorIcono);
                    return;
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "El monto de devolución no puede ser negativo", Properties.Resources.ErrorIcono);
                    return;
                }
            }


            // Validación para que el motivo de la devolución no quede vacío
            if (string.IsNullOrWhiteSpace(objdev.rchMotivo.Text.Trim()))
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "The reason for return cannot be empty", Properties.Resources.ErrorIcono);
                    return;
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "El motivo de la devolución no puede estar vacío", Properties.Resources.ErrorIcono);
                    return;
                }
            }

            DAODevoluciones dao = new DAODevoluciones();

            dao.Idventa = int.Parse(objdev.dropVenta.SelectedValue.ToString());
            dao.Nombreproducto = int.Parse(objdev.dropProducto.SelectedValue.ToString());
            dao.Nombrecliente = int.Parse(objdev.dropCliente.SelectedValue.ToString());
            dao.Fechadeladevolucion = objdev.pickerFechaDev.Value.Date;
            dao.CantidadProducto = (int)objdev.nudMonto.Value;
            dao.Montodevolucion = decimal.Parse(objdev.txtMonto.Text.Trim());
            dao.Motivodevolucion = objdev.rchMotivo.Text.Trim();

            int resp = dao.RegistrarDevolucion();

            if (resp > 0)
            {
                //Mensaje de afirmacion si se pudo realizar la inserccion
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Process performed", "The return was successfully completede", Properties.Resources.comprobado);
                    objdev.Close();
                }
                else
                {
                    MandarValoresAlerta(Color.LightGreen, Color.Black, "Proceso realizado", "Se logro hacer la devolución correctamente", Properties.Resources.comprobado);
                    objdev.Close();
                }
            }
            else if (resp == -2)
            {
                // Mensaje de advertencia si el monto de la devolución es mayor que el total de la venta
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Orange, Color.DarkOrange, "Warning", "The amount of the refund cannot exceed the total amount of the sale.", Properties.Resources.ErrorIcono);
                }
                else
                {
                    MandarValoresAlerta(Color.Orange, Color.DarkOrange, "Advertencia", "El monto de la devolución no puede ser mayor al total de la venta", Properties.Resources.ErrorIcono);
                }
            }
            else
            {
                //Mensaje de error si se no se pudo realizar la inserccion
                if (ControladorIdioma.idioma == 1)
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "Failed to make the return", Properties.Resources.ErrorIcono);
                }
                else
                {
                    MandarValoresAlerta(Color.Red, Color.DarkRed, "Error", "No se logro hacer la devolución", Properties.Resources.ErrorIcono);
                }
            }
        }
        private void EventosIniciales(object sender, EventArgs e)
        {
            LlenarCombos();
        }
        void LlenarCombos()
        {
            llenarProductos();
            LlenarVentas();
            LlenarClientes();
        }
        void llenarProductos()
        {
            DAODevoluciones dAO = new DAODevoluciones();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = dAO.LlenarComboProducto();
            //Llenar combobox tbRole
            objdev.dropProducto.DataSource = ds.Tables["Productos"];
            objdev.dropProducto.ValueMember = "idProducto";
            objdev.dropProducto.DisplayMember = "Nombre";
        }
        void LlenarVentas()
        {
            DAODevoluciones dAO2 = new DAODevoluciones();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = dAO2.LlenarComboVenta();
            //Llenar combobox tbRole
            objdev.dropVenta.DataSource = ds.Tables["Ventas"];
            objdev.dropVenta.ValueMember = "idVenta";
            objdev.dropVenta.DisplayMember = "idVenta";
        }
        void LlenarClientes()
        {
            DAODevoluciones dAO3 = new DAODevoluciones();
            //Declarando nuevo DataSet para que obtenga los datos del metodo LlenarCombo
            DataSet ds = dAO3.LlenarComboClientes();
            //Llenar combobox tbRole
            objdev.dropCliente.DataSource = ds.Tables["Clientes"];
            objdev.dropCliente.ValueMember = "idCliente";
            objdev.dropCliente.DisplayMember = "Nombre";
        }
    }
}

