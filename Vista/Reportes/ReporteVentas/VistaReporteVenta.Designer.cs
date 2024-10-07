namespace AgroServicios.Vista.Reportes.ReporteVentas
{
    partial class VistaReporteVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaReporteVenta));
            this.ventasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetVentas = new AgroServicios.Vista.Reportes.ReporteVentas.DataSetVentas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ventasTableAdapter = new AgroServicios.Vista.Reportes.ReporteVentas.DataSetVentasTableAdapters.VentasTableAdapter();
            this.Panel12 = new Bunifu.UI.WinForms.BunifuPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ventasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVentas)).BeginInit();
            this.Panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ventasBindingSource
            // 
            this.ventasBindingSource.DataMember = "Ventas";
            this.ventasBindingSource.DataSource = this.dataSetVentas;
            // 
            // dataSetVentas
            // 
            this.dataSetVentas.DataSetName = "DataSetVentas";
            this.dataSetVentas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "VentasDataset";
            reportDataSource1.Value = this.ventasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AgroServicios.Vista.Reportes.ReporteVentas.info.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 105);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(856, 433);
            this.reportViewer1.TabIndex = 0;
            // 
            // ventasTableAdapter
            // 
            this.ventasTableAdapter.ClearBeforeFill = true;
            // 
            // Panel12
            // 
            this.Panel12.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19)))));
            this.Panel12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel12.BackgroundImage")));
            this.Panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel12.BorderColor = System.Drawing.Color.Transparent;
            this.Panel12.BorderRadius = 3;
            this.Panel12.BorderThickness = 1;
            this.Panel12.Controls.Add(this.label1);
            this.Panel12.Controls.Add(this.bunifuPictureBox1);
            this.Panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel12.Location = new System.Drawing.Point(0, 0);
            this.Panel12.Name = "Panel12";
            this.Panel12.ShowBorders = true;
            this.Panel12.Size = new System.Drawing.Size(840, 100);
            this.Panel12.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ficha de ventas";
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 45;
            this.bunifuPictureBox1.Image = global::AgroServicios.Properties.Resources.Report1;
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(232, 3);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(91, 91);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 3;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // VistaReporteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 374);
            this.Controls.Add(this.Panel12);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(856, 413);
            this.MinimumSize = new System.Drawing.Size(856, 413);
            this.Name = "VistaReporteVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de ventas";
            this.Load += new System.EventHandler(this.VistaReporteVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ventasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetVentas)).EndInit();
            this.Panel12.ResumeLayout(false);
            this.Panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetVentas dataSetVentas;
        private System.Windows.Forms.BindingSource ventasBindingSource;
        private DataSetVentasTableAdapters.VentasTableAdapter ventasTableAdapter;
        private Bunifu.UI.WinForms.BunifuPanel Panel12;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Label label1;
    }
}