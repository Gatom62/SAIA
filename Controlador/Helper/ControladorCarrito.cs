using AgroServicios.Modelo.DAO;
using AgroServicios.Vista.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Windows.Forms;
using AgroServicios.Modelo.DTO;
using Bunifu.UI.WinForms.Helpers.Transitions;
using System.Linq;

namespace AgroServicios.Controlador.Helper
{
    public class ControladorCarrito
    {
        private VistaCarrito objCarrito;
        private string clienteEmail;

        public ControladorCarrito(VistaCarrito vistaCarrito)
        {
            objCarrito = vistaCarrito;
            objCarrito.btneliminar.Click += Borrarcompra;
            objCarrito.Load += ChargeValue;
            objCarrito.btnComprar.Click += RealizarCompra;
            objCarrito.cmbCliente.SelectedIndexChanged += CmbCliente_SelectedIndexChanged;
            objCarrito.cmsEliminarP.Click += eliminarp;

            objCarrito.txtBuscarClientes.KeyPress += new KeyPressEventHandler(Search);
        }
        private void eliminarp(object sender, EventArgs e)
        {
            if (objCarrito.dgvCarrito.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningún producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si no hay ninguna fila seleccionada
            }
            else
            {
                if (objCarrito.dgvCarrito.SelectedRows.Count > 0)
                {

                    // Muestra un mensaje de confirmación
                    DialogResult result = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este producto?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Si el usuario confirma la eliminación
                    if (result == DialogResult.Yes)
                    {
                        // Obtén el índice de la primera fila seleccionada
                        int rowIndex = objCarrito.dgvCarrito.SelectedRows[0].Index;

                        // Elimina la fila en el índice especificado
                        objCarrito.dgvCarrito.Rows.RemoveAt(rowIndex);
                        // Actualizar el total después de eliminar la fila
                        ActualizarTotal();

                    }
                }

            }
        }
        private void Search(object sender, KeyPressEventArgs e)
        {
            // Verifica que la tecla presionada sea Enter antes de buscar
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarEmpleado();
                e.Handled = true;
            }
        }
        private void BuscarEmpleado()
        {
            DAOCarrito dao = new DAOCarrito();
            //Declarando nuevo DataSet para que obtenga los datos del metodo ObtenerPersonas
            DataSet ds = dao.BuscarCliente(objCarrito.txtBuscarClientes.Text.Trim());
            //Llenar DataGridView
            objCarrito.cmbCliente.DataSource = ds.Tables["Clientes"];
            objCarrito.cmbCliente.ValueMember = "idCliente";
            objCarrito.cmbCliente.DisplayMember = "Nombre";
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (objCarrito.cmbCliente.SelectedValue is int idClienteSeleccionado)
                {
                    var dt = objCarrito.cmbCliente.DataSource as DataTable;
                    if (dt?.Select($"idCliente = {idClienteSeleccionado}").FirstOrDefault() is DataRow row)
                    {
                        clienteEmail = row["Correo"].ToString();
                    }
                    else
                    {
                        clienteEmail = "NoValid";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el cliente seleccionado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RealizarCompra(object sender, EventArgs e)
        {
            DAOCarrito daoinsert = new DAOCarrito();

            if (objCarrito.cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (objCarrito.dgvTotal.Rows.Count == 0 ||
            objCarrito.dgvTotal.Rows[0].Cells[0].Value == null ||
            string.IsNullOrWhiteSpace(objCarrito.dgvTotal.Rows[0].Cells[0].Value.ToString()) ||
            !decimal.TryParse(objCarrito.dgvTotal.Rows[0].Cells[0].Value.ToString().Replace("$", "").Trim(), out decimal total) ||
            total <= 0)
            {
                MessageBox.Show("El carrito está vacío o el total es 0. No se puede realizar la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            daoinsert.Idcliente = (int)objCarrito.cmbCliente.SelectedValue;
            daoinsert.Idempleado = StaticSession.Id;
            daoinsert.Fechaventa = DateTime.Now;
            decimal montoTotal = 0;

            foreach (DataGridViewRow row in objCarrito.dgvCarrito.Rows)
            {
                if (row.Cells["PrecioTotal"].Value != null &&
                    !string.IsNullOrWhiteSpace(row.Cells["PrecioTotal"].Value.ToString()))
                {
                    if (decimal.TryParse(row.Cells["PrecioTotal"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal precioTotal))
                    {
                        montoTotal += precioTotal;
                    }
                    else
                    {
                        MessageBox.Show("Uno de los valores en 'Precio Total' no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            daoinsert.Montototal = montoTotal;
            int resp = daoinsert.RegistrarVenta();

            if (resp > 0)
            {
                MessageBox.Show("Se ha hecho la compra", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string pdfFilePath;
                Imprimir(out pdfFilePath);

                // Verifica si el cliente tiene un correo electrónico antes de intentar enviar el PDF
                if (!string.IsNullOrWhiteSpace(clienteEmail))
                {
                    try
                    {
                        var mailService = new DAODCSoporte();
                        mailService.sendMailWithAttachment(
                            subject: "Factura de Compra",
                            body: $"Hola, {objCarrito.cmbCliente.Text}\nGracias por su compra. Adjuntamos la factura de su compra.",
                            destinatarioCorreo: new List<string> { clienteEmail },
                            attachmentPath: pdfFilePath
                        );
                    }
                    catch (Exception ex)
                    {
                        // Mostrar el mensaje de error si el envío falla, pero no interrumpir el flujo
                        MessageBox.Show($"No se pudo enviar el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha podido realizar la compra", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Imprimir(out string pdfFilePath)
        {
            // Genera una ruta de archivo temporal
            pdfFilePath = Path.Combine(Path.GetTempPath(), DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf");

            string paginahtml_texto = Properties.Resources.Factura_Plantilla.ToString();

            string cliente = objCarrito.cmbCliente.Text;
            string total = objCarrito.dgvTotal.Rows.Count > 0 && objCarrito.dgvTotal.Rows[0].Cells[0].Value != null
                           ? objCarrito.dgvTotal.Rows[0].Cells[0].Value.ToString()
                           : "0.00";
            string vendedor = StaticSession.Username;

            paginahtml_texto = paginahtml_texto.Replace("@Cliente", cliente);
            paginahtml_texto = paginahtml_texto.Replace("@total", total);
            paginahtml_texto = paginahtml_texto.Replace("@vendedor", vendedor);

            string filas = string.Empty;
            foreach (DataGridViewRow row in objCarrito.dgvCarrito.Rows)
            {
                if (row.IsNewRow) continue;

                filas += "<tr>";

                string producto = row.Cells["Producto"].Value?.ToString() ?? "N/A";
                string cantidad = row.Cells["Cantidad"].Value?.ToString() ?? "0";
                string precioUnitario = row.Cells["PrecioUnitario"].Value?.ToString() ?? "0.00";
                string precioTotal = row.Cells["PrecioTotal"].Value?.ToString() ?? "0.00";

                filas += $"<td>{producto}</td>";
                filas += $"<td>{cantidad}</td>";
                filas += $"<td>{precioUnitario}</td>";
                filas += $"<td>{precioTotal}</td>";
                filas += "</tr>";
            }

            paginahtml_texto = paginahtml_texto.Replace("@filas", filas);

            using (FileStream stream = new FileStream(pdfFilePath, FileMode.Create))
            {
                Document pdfdoc = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(pdfdoc, stream);

                pdfdoc.Open();
                pdfdoc.Add(new Phrase(""));

                using (StringReader sr = new StringReader(paginahtml_texto))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfdoc, sr);
                }

                pdfdoc.Close();
                stream.Close();
            }
        }

        private void ChargeValue(object sender, EventArgs e)
        {
            LlenarTextBox();
        }

        public void AgregarProductoAlCarrito(string producto, int cantidad, decimal precioUnitario, decimal precioTotal)
        {
            // Verifica si el producto ya existe en el carrito
            foreach (DataGridViewRow row in objCarrito.dgvCarrito.Rows)
            {
                if (row.Cells["Producto"].Value != null &&
                    row.Cells["Producto"].Value.ToString() == producto)
                {
                    // Producto ya existe, actualiza la cantidad y el precio total
                    int cantidadExistente = int.Parse(row.Cells["Cantidad"].Value.ToString());
                    decimal precioTotalExistente = decimal.Parse(row.Cells["PrecioTotal"].Value.ToString(), System.Globalization.NumberStyles.Currency);

                    int nuevaCantidad = cantidadExistente + cantidad;
                    decimal nuevoPrecioTotal = precioTotalExistente + precioTotal;

                    row.Cells["Cantidad"].Value = nuevaCantidad;
                    row.Cells["PrecioTotal"].Value = nuevoPrecioTotal.ToString("C");

                    // Actualiza el total general
                    ActualizarTotal();
                    return;
                }
            }

            // Si el producto no existe, agrega una nueva fila
            objCarrito.dgvCarrito.Rows.Add(producto, cantidad, precioUnitario.ToString("C"), precioTotal.ToString("C"));

            // Actualiza el total general
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = 0m;

            // Suma el precio total de todos los productos en el carrito
            foreach (DataGridViewRow row in objCarrito.dgvCarrito.Rows)
            {
                if (row.Cells["PrecioTotal"].Value != null &&
                    !string.IsNullOrWhiteSpace(row.Cells["PrecioTotal"].Value.ToString()))
                {
                    total += decimal.Parse(row.Cells["PrecioTotal"].Value.ToString(), System.Globalization.NumberStyles.Currency);
                }
            }

            // Muestra el total en el dgvTotal
            objCarrito.dgvTotal.Rows[0].Cells[0].Value = total.ToString("C");
        }

        private void Borrarcompra(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea eliminar esta compra?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objCarrito.dgvCarrito.Rows.Clear();
                objCarrito.dgvTotal.Rows.Clear();
                // Agrega una nueva fila vacía
                int rowIndex = objCarrito.dgvTotal.Rows.Add();
                // Establece el valor predeterminado en la primera celda de la fila recién agregada
                objCarrito.dgvTotal.Rows[rowIndex].Cells[0].Value = "$0.00";
            }
        }

        void LlenarTextBox()
        {
            DAOCarrito dao = new DAOCarrito();

            DataSet ds = dao.LlenarCombo();

            objCarrito.cmbCliente.DataSource = ds.Tables["Clientes"];
            objCarrito.cmbCliente.ValueMember = "idCliente";
            objCarrito.cmbCliente.DisplayMember = "Nombre";
        }
    }
}

