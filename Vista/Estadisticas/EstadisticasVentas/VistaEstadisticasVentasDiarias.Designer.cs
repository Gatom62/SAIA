namespace AgroServicios.Vista.Estadisticas.EstadisticasVentas
{
    partial class VistaEstadisticasVentasDiarias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaEstadisticasVentasDiarias));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnEstructura = new Bunifu.UI.WinForms.BunifuPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bunifuShadowPanel2 = new Bunifu.UI.WinForms.BunifuShadowPanel();
            this.pnTitulo = new Bunifu.UI.WinForms.BunifuPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbVentasDiarias = new Bunifu.UI.WinForms.BunifuLabel();
            this.pnEstructura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.bunifuShadowPanel2.SuspendLayout();
            this.pnTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnEstructura
            // 
            this.pnEstructura.BackgroundColor = System.Drawing.Color.White;
            this.pnEstructura.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnEstructura.BackgroundImage")));
            this.pnEstructura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnEstructura.BorderColor = System.Drawing.Color.Transparent;
            this.pnEstructura.BorderRadius = 30;
            this.pnEstructura.BorderThickness = 2;
            this.pnEstructura.Controls.Add(this.chart1);
            this.pnEstructura.Controls.Add(this.bunifuShadowPanel2);
            this.pnEstructura.Location = new System.Drawing.Point(28, 23);
            this.pnEstructura.Margin = new System.Windows.Forms.Padding(2);
            this.pnEstructura.Name = "pnEstructura";
            this.pnEstructura.ShowBorders = true;
            this.pnEstructura.Size = new System.Drawing.Size(758, 462);
            this.pnEstructura.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 77);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(752, 382);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // bunifuShadowPanel2
            // 
            this.bunifuShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShadowPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuShadowPanel2.BorderRadius = 25;
            this.bunifuShadowPanel2.BorderThickness = 1;
            this.bunifuShadowPanel2.Controls.Add(this.pnTitulo);
            this.bunifuShadowPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuShadowPanel2.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
            this.bunifuShadowPanel2.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
            this.bunifuShadowPanel2.Location = new System.Drawing.Point(0, 0);
            this.bunifuShadowPanel2.Name = "bunifuShadowPanel2";
            this.bunifuShadowPanel2.PanelColor = System.Drawing.Color.Transparent;
            this.bunifuShadowPanel2.PanelColor2 = System.Drawing.Color.Transparent;
            this.bunifuShadowPanel2.ShadowColor = System.Drawing.Color.Silver;
            this.bunifuShadowPanel2.ShadowDept = 2;
            this.bunifuShadowPanel2.ShadowDepth = 5;
            this.bunifuShadowPanel2.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
            this.bunifuShadowPanel2.ShadowTopLeftVisible = false;
            this.bunifuShadowPanel2.Size = new System.Drawing.Size(758, 86);
            this.bunifuShadowPanel2.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
            this.bunifuShadowPanel2.TabIndex = 0;
            // 
            // pnTitulo
            // 
            this.pnTitulo.BackgroundColor = System.Drawing.Color.White;
            this.pnTitulo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnTitulo.BackgroundImage")));
            this.pnTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnTitulo.BorderColor = System.Drawing.Color.Transparent;
            this.pnTitulo.BorderRadius = 20;
            this.pnTitulo.BorderThickness = 2;
            this.pnTitulo.Controls.Add(this.pictureBox1);
            this.pnTitulo.Controls.Add(this.lbVentasDiarias);
            this.pnTitulo.Location = new System.Drawing.Point(0, -1);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.ShowBorders = true;
            this.pnTitulo.Size = new System.Drawing.Size(758, 72);
            this.pnTitulo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::AgroServicios.Properties.Resources.tdesign_money;
            this.pictureBox1.Location = new System.Drawing.Point(477, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lbVentasDiarias
            // 
            this.lbVentasDiarias.AllowParentOverrides = false;
            this.lbVentasDiarias.AutoEllipsis = false;
            this.lbVentasDiarias.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbVentasDiarias.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbVentasDiarias.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVentasDiarias.Location = new System.Drawing.Point(253, 22);
            this.lbVentasDiarias.Name = "lbVentasDiarias";
            this.lbVentasDiarias.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbVentasDiarias.Size = new System.Drawing.Size(218, 38);
            this.lbVentasDiarias.TabIndex = 16;
            this.lbVentasDiarias.Text = "Ventas diarias";
            this.lbVentasDiarias.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbVentasDiarias.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // VistaEstadisticasVentasDiarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 508);
            this.Controls.Add(this.pnEstructura);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaEstadisticasVentasDiarias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas de ventas diarias / Estadisticas - 2";
            this.Load += new System.EventHandler(this.VistaEstadisticasVentasDiarias_Load);
            this.pnEstructura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.bunifuShadowPanel2.ResumeLayout(false);
            this.pnTitulo.ResumeLayout(false);
            this.pnTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel pnEstructura;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Bunifu.UI.WinForms.BunifuShadowPanel bunifuShadowPanel2;
        private Bunifu.UI.WinForms.BunifuPanel pnTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuLabel lbVentasDiarias;
    }
}