using AgroServicios.Controlador.Helper;
using AgroServicios.Modelo.DTO;
using AgroServicios.Vista.MenuPrincipal;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgroServicios.Modelo.DAO;
using System.Data;
using System.Drawing;
using AgroServicios.Vista.Notificación;

namespace AgroServicios.Controlador.MenuPrincipal
{
    class ControladorCerrarCaja
    {
        private VistaCerrarCaja objcaja;
        private string empleadoInforme;

        public ControladorCerrarCaja(VistaCerrarCaja vista)
        {
            objcaja = vista;
            objcaja.Load += CargaInicial;
            objcaja.btnCerrarCaja.Click += CerrarCaja;
        }
        private void CargaInicial(object sender, EventArgs e)
        {
            // Crear una instancia del DAO y establecer las fechas
            DAOCierreCaja dao = new DAOCierreCaja();

            // Obtener el DataSet desde el DAO
            DataSet ds = dao.FIltrarVentasHoy();

            // Limpiar el DataSource antes de asignar uno nuevo
            objcaja.dgvCierre.DataSource = null;

            // Asignar el DataSet al DataGridView si tiene datos
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                objcaja.dgvCierre.DataSource = ds.Tables[0];
                if (ControladorIdioma.idioma == 1)
                {
                    objcaja.dgvCierre.Columns[0].HeaderText = "Sale ID";
                    objcaja.dgvCierre.Columns[1].HeaderText = "Customer name";
                    objcaja.dgvCierre.Columns[2].HeaderText = "Employee name";
                    objcaja.dgvCierre.Columns[3].HeaderText = "Sale date";
                    objcaja.dgvCierre.Columns[4].HeaderText = "Total amount";
                }
                else
                {
                    objcaja.dgvCierre.Columns[0].HeaderText = "ID de la venta";
                    objcaja.dgvCierre.Columns[1].HeaderText = "Nombre del cliente";
                    objcaja.dgvCierre.Columns[2].HeaderText = "Nombre del empleado";
                    objcaja.dgvCierre.Columns[3].HeaderText = "Fecha de la venta";
                    objcaja.dgvCierre.Columns[4].HeaderText = "Monto total";
                }
            }
            else
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("No sales found", "No results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontraron ventas", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void CerrarCaja(object sender, EventArgs e)
        {
            DAOCierreCaja dao = new DAOCierreCaja();
            decimal totalDia = 0;
            string filasCierres = string.Empty;

            // Sumar todas las ventas del DataGridView
            foreach (DataGridViewRow row in objcaja.dgvCierre.Rows)
            {
                if (row.Cells["MontoTotal"].Value != null &&
                    decimal.TryParse(row.Cells["MontoTotal"].Value.ToString(), out decimal monto))
                {
                    totalDia += monto;
                    filasCierres += "<tr>";
                    filasCierres += $"<td>{row.Cells["Nombre del empleado"].Value}</td>";
                    filasCierres += $"<td>{row.Cells["Nombre del cliente"].Value}</td>";
                    filasCierres += $"<td>{row.Cells["FechaVenta"].Value}</td>";
                    filasCierres += $"<td>{row.Cells["MontoTotal"].Value}</td>";
                    filasCierres += "</tr>";
                }
            }

            // Validar si hay ventas
            if (totalDia <= 0)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("There are no sales to close the cash register", "No sales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("No hay ventas para cerrar la caja", "Sin ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            // Generar el PDF de cierre de caja
            string pdfFilePath = GenerarInformeCierreCaja(filasCierres, totalDia);

            // Guardar los detalles del cierre en la base de datos
            int resp = dao.RegistrarCierreCaja(StaticSession.Username, totalDia, DateTime.Now);

            if (resp > 0)
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("Cash closing successfully completed", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cierre de caja realizado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Opción para abrir el PDF generado
                if (ControladorIdioma.idioma == 1)
                {
                    if (MessageBox.Show("¿You want to open the cash closing report?", "Open Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(pdfFilePath);
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Desea abrir el informe de cierre de caja?", "Abrir Informe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(pdfFilePath);
                    }
                }
            }
            else
            {
                if (ControladorIdioma.idioma == 1)
                {
                    MessageBox.Show("The cash register closing could not be recorded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    MessageBox.Show("No se pudo registrar el cierre de caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GenerarInformeCierreCaja(string filasCierres, decimal totalDia)
        {
            string pdfFilePath = Path.Combine(Path.GetTempPath(), "CierreCaja_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf");
            string paginahtml_texto = Properties.Resources.cierre_caja_plantilla.ToString();

            paginahtml_texto = paginahtml_texto.Replace("@FechaInforme", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            paginahtml_texto = paginahtml_texto.Replace("@filasCierres", filasCierres);
            paginahtml_texto = paginahtml_texto.Replace("@totalDia", totalDia.ToString("C"));
            paginahtml_texto = paginahtml_texto.Replace("@empleadoInforme", StaticSession.Username);

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

            return pdfFilePath;
        }
    }
}
