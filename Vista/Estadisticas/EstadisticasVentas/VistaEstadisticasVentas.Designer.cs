namespace AgroServicios.Vista.Estadisticas.EstadisticasVentas
{
    partial class VistaEstadisticasVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaEstadisticasVentas));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
            this.pnEstructura = new Bunifu.UI.WinForms.BunifuPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bunifuShadowPanel2 = new Bunifu.UI.WinForms.BunifuShadowPanel();
            this.pnTitulo = new Bunifu.UI.WinForms.BunifuPanel();
            this.FlechaDer = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
            this.FlechaIzq = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
            this.lbVentasEchasPorEmpleados = new Bunifu.UI.WinForms.BunifuLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
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
            this.pnEstructura.Location = new System.Drawing.Point(29, 20);
            this.pnEstructura.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnEstructura.Name = "pnEstructura";
            this.pnEstructura.ShowBorders = true;
            this.pnEstructura.Size = new System.Drawing.Size(758, 462);
            this.pnEstructura.TabIndex = 1;
            this.bunifuToolTip1.SetToolTip(this.pnEstructura, "");
            this.bunifuToolTip1.SetToolTipIcon(this.pnEstructura, null);
            this.bunifuToolTip1.SetToolTipTitle(this.pnEstructura, "");
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 77);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(752, 382);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            this.bunifuToolTip1.SetToolTip(this.chart1, "");
            this.bunifuToolTip1.SetToolTipIcon(this.chart1, null);
            this.bunifuToolTip1.SetToolTipTitle(this.chart1, "");
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
            this.bunifuToolTip1.SetToolTip(this.bunifuShadowPanel2, "");
            this.bunifuToolTip1.SetToolTipIcon(this.bunifuShadowPanel2, null);
            this.bunifuToolTip1.SetToolTipTitle(this.bunifuShadowPanel2, "");
            // 
            // pnTitulo
            // 
            this.pnTitulo.BackgroundColor = System.Drawing.Color.White;
            this.pnTitulo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnTitulo.BackgroundImage")));
            this.pnTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnTitulo.BorderColor = System.Drawing.Color.Transparent;
            this.pnTitulo.BorderRadius = 20;
            this.pnTitulo.BorderThickness = 2;
            this.pnTitulo.Controls.Add(this.FlechaDer);
            this.pnTitulo.Controls.Add(this.FlechaIzq);
            this.pnTitulo.Controls.Add(this.lbVentasEchasPorEmpleados);
            this.pnTitulo.Controls.Add(this.pictureBox1);
            this.pnTitulo.Location = new System.Drawing.Point(0, -1);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.ShowBorders = true;
            this.pnTitulo.Size = new System.Drawing.Size(758, 72);
            this.pnTitulo.TabIndex = 0;
            this.bunifuToolTip1.SetToolTip(this.pnTitulo, "");
            this.bunifuToolTip1.SetToolTipIcon(this.pnTitulo, null);
            this.bunifuToolTip1.SetToolTipTitle(this.pnTitulo, "");
            // 
            // FlechaDer
            // 
            this.FlechaDer.AllowAnimations = true;
            this.FlechaDer.AllowBorderColorChanges = true;
            this.FlechaDer.AllowMouseEffects = true;
            this.FlechaDer.AnimationSpeed = 200;
            this.FlechaDer.BackColor = System.Drawing.Color.Transparent;
            this.FlechaDer.BackgroundColor = System.Drawing.Color.Transparent;
            this.FlechaDer.BorderColor = System.Drawing.Color.Transparent;
            this.FlechaDer.BorderRadius = 1;
            this.FlechaDer.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
            this.FlechaDer.BorderThickness = 1;
            this.FlechaDer.ColorContrastOnClick = 30;
            this.FlechaDer.ColorContrastOnHover = 30;
            this.FlechaDer.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.FlechaDer.CustomizableEdges = borderEdges1;
            this.FlechaDer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.FlechaDer.Image = global::AgroServicios.Properties.Resources.IconoFlecha_flipped;
            this.FlechaDer.ImageMargin = new System.Windows.Forms.Padding(0);
            this.FlechaDer.Location = new System.Drawing.Point(697, 15);
            this.FlechaDer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FlechaDer.Name = "FlechaDer";
            this.FlechaDer.RoundBorders = true;
            this.FlechaDer.ShowBorders = true;
            this.FlechaDer.Size = new System.Drawing.Size(38, 38);
            this.FlechaDer.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Round;
            this.FlechaDer.TabIndex = 19;
            this.bunifuToolTip1.SetToolTip(this.FlechaDer, "");
            this.bunifuToolTip1.SetToolTipIcon(this.FlechaDer, null);
            this.bunifuToolTip1.SetToolTipTitle(this.FlechaDer, "");
            // 
            // FlechaIzq
            // 
            this.FlechaIzq.AllowAnimations = true;
            this.FlechaIzq.AllowBorderColorChanges = true;
            this.FlechaIzq.AllowMouseEffects = true;
            this.FlechaIzq.AnimationSpeed = 200;
            this.FlechaIzq.BackColor = System.Drawing.Color.Transparent;
            this.FlechaIzq.BackgroundColor = System.Drawing.Color.Transparent;
            this.FlechaIzq.BorderColor = System.Drawing.Color.Transparent;
            this.FlechaIzq.BorderRadius = 1;
            this.FlechaIzq.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
            this.FlechaIzq.BorderThickness = 1;
            this.FlechaIzq.ColorContrastOnClick = 30;
            this.FlechaIzq.ColorContrastOnHover = 30;
            this.FlechaIzq.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.FlechaIzq.CustomizableEdges = borderEdges2;
            this.FlechaIzq.DialogResult = System.Windows.Forms.DialogResult.None;
            this.FlechaIzq.Image = global::AgroServicios.Properties.Resources.IconoFlecha;
            this.FlechaIzq.ImageMargin = new System.Windows.Forms.Padding(0);
            this.FlechaIzq.Location = new System.Drawing.Point(28, 15);
            this.FlechaIzq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FlechaIzq.Name = "FlechaIzq";
            this.FlechaIzq.RoundBorders = true;
            this.FlechaIzq.ShowBorders = true;
            this.FlechaIzq.Size = new System.Drawing.Size(38, 38);
            this.FlechaIzq.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Round;
            this.FlechaIzq.TabIndex = 18;
            this.bunifuToolTip1.SetToolTip(this.FlechaIzq, "");
            this.bunifuToolTip1.SetToolTipIcon(this.FlechaIzq, null);
            this.bunifuToolTip1.SetToolTipTitle(this.FlechaIzq, "");
            // 
            // lbVentasEchasPorEmpleados
            // 
            this.lbVentasEchasPorEmpleados.AllowParentOverrides = false;
            this.lbVentasEchasPorEmpleados.AutoEllipsis = false;
            this.lbVentasEchasPorEmpleados.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbVentasEchasPorEmpleados.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbVentasEchasPorEmpleados.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVentasEchasPorEmpleados.Location = new System.Drawing.Point(204, 22);
            this.lbVentasEchasPorEmpleados.Name = "lbVentasEchasPorEmpleados";
            this.lbVentasEchasPorEmpleados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbVentasEchasPorEmpleados.Size = new System.Drawing.Size(344, 28);
            this.lbVentasEchasPorEmpleados.TabIndex = 16;
            this.lbVentasEchasPorEmpleados.Text = "Ventas echas por empleados";
            this.lbVentasEchasPorEmpleados.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbVentasEchasPorEmpleados.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuToolTip1.SetToolTip(this.lbVentasEchasPorEmpleados, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lbVentasEchasPorEmpleados, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lbVentasEchasPorEmpleados, "");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::AgroServicios.Properties.Resources.silueta_de_multiples_usuarios;
            this.pictureBox1.Location = new System.Drawing.Point(597, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.bunifuToolTip1.SetToolTip(this.pictureBox1, "");
            this.bunifuToolTip1.SetToolTipIcon(this.pictureBox1, null);
            this.bunifuToolTip1.SetToolTipTitle(this.pictureBox1, "");
            // 
            // bunifuToolTip1
            // 
            this.bunifuToolTip1.Active = true;
            this.bunifuToolTip1.AlignTextWithTitle = false;
            this.bunifuToolTip1.AllowAutoClose = false;
            this.bunifuToolTip1.AllowFading = true;
            this.bunifuToolTip1.AutoCloseDuration = 5000;
            this.bunifuToolTip1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuToolTip1.BorderColor = System.Drawing.Color.Gainsboro;
            this.bunifuToolTip1.ClickToShowDisplayControl = false;
            this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
            this.bunifuToolTip1.DisplayControl = null;
            this.bunifuToolTip1.EntryAnimationSpeed = 350;
            this.bunifuToolTip1.ExitAnimationSpeed = 200;
            this.bunifuToolTip1.GenerateAutoCloseDuration = false;
            this.bunifuToolTip1.IconMargin = 6;
            this.bunifuToolTip1.InitialDelay = 0;
            this.bunifuToolTip1.Name = "bunifuToolTip1";
            this.bunifuToolTip1.Opacity = 1D;
            this.bunifuToolTip1.OverrideToolTipTitles = false;
            this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
            this.bunifuToolTip1.ReshowDelay = 100;
            this.bunifuToolTip1.ShowAlways = true;
            this.bunifuToolTip1.ShowBorders = false;
            this.bunifuToolTip1.ShowIcons = true;
            this.bunifuToolTip1.ShowShadows = true;
            this.bunifuToolTip1.Tag = null;
            this.bunifuToolTip1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuToolTip1.TextForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuToolTip1.TextMargin = 2;
            this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Black;
            this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
            this.bunifuToolTip1.ToolTipTitle = null;
            // 
            // VistaEstadisticasVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 514);
            this.Controls.Add(this.pnEstructura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(831, 553);
            this.MinimumSize = new System.Drawing.Size(831, 553);
            this.Name = "VistaEstadisticasVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas de empleados / Estadisticas - 1";
            this.Load += new System.EventHandler(this.VistaEstadisticasVentas_Load);
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
        private Bunifu.UI.WinForms.BunifuShadowPanel bunifuShadowPanel2;
        private Bunifu.UI.WinForms.BunifuPanel pnTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuToolTip bunifuToolTip1;
        public Bunifu.UI.WinForms.BunifuLabel lbVentasEchasPorEmpleados;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public Bunifu.UI.WinForms.BunifuButton.BunifuIconButton FlechaDer;
        public Bunifu.UI.WinForms.BunifuButton.BunifuIconButton FlechaIzq;
    }
}