using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgroServicios.Modelo;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using AgroServicios.Vista.Estadisticas;
using AgroServicios.Vista.Estadisticas.EstadisticasVentas;

namespace AgroServicios.Controlador.EstadisticasVentas
{
    class ControladorEstadisticasEmpleados
    {
        VistaEstadisticasVentas ObjEstadisticasVentas;
        private int estadoGrafico = 0; // 0: Ventas por empleados, 1: Ventas semanales, 2: Ventas mensuales
        public ControladorEstadisticasEmpleados (VistaEstadisticasVentas vista)
        {
            ObjEstadisticasVentas = vista;
            ObjEstadisticasVentas.Load += Actualizar;
            ObjEstadisticasVentas.FlechaDer.Click += MoverDerecha;
            ObjEstadisticasVentas.FlechaIzq.Click += MoverIzquierda;
        }
        private void MoverIzquierda(object sender, EventArgs e)
        {
            estadoGrafico--;
            if (estadoGrafico < 0) // Si estamos antes del primer estado, volvemos al último
            {
                estadoGrafico = 2;
            }
            ActualizarGrafico();
        }
        private void MoverDerecha(object sender, EventArgs e)
        {
            estadoGrafico++;
            if (estadoGrafico > 2) // Si pasamos el último estado, volvemos al primero
            {
                estadoGrafico = 0;
            }
            ActualizarGrafico();
        }

        private void Actualizar(object sender, EventArgs e)
        {
            ActualizarGrafico();
        }
        private void ActualizarGrafico()
        {
            if (ControladorIdioma.idioma == 1)
            {
                switch (estadoGrafico)
                {
                    case 0:
                        // Ventas por empleados
                        ObjEstadisticasVentas.lbVentasEchasPorEmpleados.Text = "Sales made by employees";
                        CargarVentasPorEmpleados(); // Cargar datos de ventas por empleados
                        break;

                    case 1:
                        // Ventas semanales
                        ObjEstadisticasVentas.lbVentasEchasPorEmpleados.Text = "Weekly sales";
                        CargarVentasSemanales(); // Cargar datos de ventas semanales
                        break;

                    case 2:
                        // Ventas mensuales
                        ObjEstadisticasVentas.lbVentasEchasPorEmpleados.Text = "Monthly sales";
                        CargarVentasMensuales(); // Cargar datos de ventas mensuales
                        break;
                }
            }
            else 
            {
                switch (estadoGrafico)
                {
                    case 0:
                        // Ventas por empleados
                        ObjEstadisticasVentas.lbVentasEchasPorEmpleados.Text = "Ventas hechas por empleados";
                        CargarVentasPorEmpleados(); // Cargar datos de ventas por empleados
                        break;

                    case 1:
                        // Ventas semanales
                        ObjEstadisticasVentas.lbVentasEchasPorEmpleados.Text = "Ventas semanales";
                        CargarVentasSemanales(); // Cargar datos de ventas semanales
                        break;

                    case 2:
                        // Ventas mensuales
                        ObjEstadisticasVentas.lbVentasEchasPorEmpleados.Text = "Ventas mensuales";
                        CargarVentasMensuales(); // Cargar datos de ventas mensuales
                        break;
                }
            }
        }
        private void CargarVentasPorEmpleados()
        {
            using (SqlConnection conn = dbContext.getConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT e.Nombre, COUNT(v.IdVenta) AS TotalVentas " +
                                                "FROM Ventas v " +
                                                "JOIN Empleados e ON v.IdEmpleado = e.IdEmpleado " +
                "GROUP BY e.Nombre", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                ObjEstadisticasVentas.chart1.Series.Clear();
                ObjEstadisticasVentas.chart1.Series.Add("Ventas por Empleado");
                ObjEstadisticasVentas.chart1.Series["Ventas por Empleado"].ChartType = SeriesChartType.Bar;

                while (reader.Read())
                {
                    string empleado = reader["Nombre"].ToString();
                    int totalVentas = (int)reader["TotalVentas"];
                    ObjEstadisticasVentas.chart1.Series["Ventas por Empleado"].Points.AddXY(empleado, totalVentas);
                }
            }
        }
        private void CargarVentasSemanales()
        {
            try
            {
                using (SqlConnection conn = dbContext.getConnection())
                {

                    SqlCommand cmd = new SqlCommand(
                        "SELECT DATEPART(WEEK, FechaVenta) AS Semana, " +
                        "MIN(FechaVenta) AS FechaInicioSemana, MAX(FechaVenta) AS FechaFinSemana, " +
                        "SUM(MontoTotal) AS TotalSemanal " +
                        "FROM Ventas " +
                        "WHERE FechaVenta >= DATEADD(WEEK, -6, GETDATE()) " +
                        "GROUP BY DATEPART(WEEK, FechaVenta)", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            ObjEstadisticasVentas.chart1.Series.Clear();
                            ObjEstadisticasVentas.chart1.Series.Add("Ventas Semanales");
                            ObjEstadisticasVentas.chart1.Series["Ventas Semanales"].ChartType = SeriesChartType.Line;

                            while (reader.Read())
                            {
                                // Rango de fechas de la semana
                                DateTime fechaInicio = (DateTime)reader["FechaInicioSemana"];
                                DateTime fechaFin = (DateTime)reader["FechaFinSemana"];
                                decimal totalSemanal = (decimal)reader["TotalSemanal"];

                                // Formatear el rango de fechas
                                string rangoFechas = $"{fechaInicio:dd/MM} - {fechaFin:dd/MM}";

                                // Agregar los puntos al gráfico
                                ObjEstadisticasVentas.chart1.Series["Ventas Semanales"].Points.AddXY(rangoFechas, totalSemanal);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay datos de ventas semanales para mostrar.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas semanales: {ex.Message}");
            }
        }

        private void CargarVentasMensuales()
        {
            try
            {
                using (SqlConnection conn = dbContext.getConnection())
                {

                    SqlCommand cmd = new SqlCommand("SELECT DATEPART(MONTH, FechaVenta) AS Mes, SUM(MontoTotal) AS TotalMensual " +
                                                    "FROM Ventas " +
                                                    "WHERE FechaVenta >= DATEADD(MONTH, -6, GETDATE()) " +
                                                    "GROUP BY DATEPART(MONTH, FechaVenta)", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            ObjEstadisticasVentas.chart1.Series.Clear();
                            ObjEstadisticasVentas.chart1.Series.Add("Ventas Mensuales");
                            ObjEstadisticasVentas.chart1.Series["Ventas Mensuales"].ChartType = SeriesChartType.Area;

                            // Diccionario para convertir el número del mes a nombre del mes
                            Dictionary<int, string> meses = new Dictionary<int, string>
                    {
                        {1, "Enero"}, {2, "Febrero"}, {3, "Marzo"}, {4, "Abril"},
                        {5, "Mayo"}, {6, "Junio"}, {7, "Julio"}, {8, "Agosto"},
                        {9, "Septiembre"}, {10, "Octubre"}, {11, "Noviembre"}, {12, "Diciembre"}
                    };

                            while (reader.Read())
                            {
                                int mes = (int)reader["Mes"];
                                decimal totalMensual = (decimal)reader["TotalMensual"];

                                // Usa el nombre del mes en lugar del número
                                string nombreMes = meses[mes];
                                ObjEstadisticasVentas.chart1.Series["Ventas Mensuales"].Points.AddXY(nombreMes, totalMensual);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay datos de ventas mensuales para mostrar.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas mensuales: {ex.Message}");
            }
        }
    }
}
