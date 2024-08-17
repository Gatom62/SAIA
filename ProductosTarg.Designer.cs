namespace AgroServicios
{
    partial class ProductosTarg
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductosTarg));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ptbimg = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.lbldesc = new System.Windows.Forms.RichTextBox();
            this.btnadd = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.lblcodigo = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblPrecio = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblname = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbimg)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Black;
            this.bunifuPanel1.BorderRadius = 30;
            this.bunifuPanel1.BorderThickness = 2;
            this.bunifuPanel1.Controls.Add(this.numericUpDown1);
            this.bunifuPanel1.Controls.Add(this.ptbimg);
            this.bunifuPanel1.Controls.Add(this.lbldesc);
            this.bunifuPanel1.Controls.Add(this.btnadd);
            this.bunifuPanel1.Controls.Add(this.lblcodigo);
            this.bunifuPanel1.Controls.Add(this.lblPrecio);
            this.bunifuPanel1.Controls.Add(this.lblname);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(583, 292);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(468, 249);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 22);
            this.numericUpDown1.TabIndex = 9;
            // 
            // ptbimg
            // 
            this.ptbimg.AllowFocused = false;
            this.ptbimg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbimg.AutoSizeHeight = false;
            this.ptbimg.BorderRadius = 10;
            this.ptbimg.Image = ((System.Drawing.Image)(resources.GetObject("ptbimg.Image")));
            this.ptbimg.IsCircle = false;
            this.ptbimg.Location = new System.Drawing.Point(17, 20);
            this.ptbimg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbimg.Name = "ptbimg";
            this.ptbimg.Size = new System.Drawing.Size(223, 257);
            this.ptbimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbimg.TabIndex = 8;
            this.ptbimg.TabStop = false;
            this.ptbimg.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Custom;
            this.ptbimg.Click += new System.EventHandler(this.ptbimg_Click_1);
            // 
            // lbldesc
            // 
            this.lbldesc.BackColor = System.Drawing.Color.White;
            this.lbldesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbldesc.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldesc.Location = new System.Drawing.Point(271, 130);
            this.lbldesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbldesc.Name = "lbldesc";
            this.lbldesc.ReadOnly = true;
            this.lbldesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.lbldesc.Size = new System.Drawing.Size(217, 96);
            this.lbldesc.TabIndex = 7;
            this.lbldesc.Text = "";
            // 
            // btnadd
            // 
            this.btnadd.AllowAnimations = true;
            this.btnadd.AllowMouseEffects = true;
            this.btnadd.AllowToggling = false;
            this.btnadd.AnimationSpeed = 200;
            this.btnadd.AutoGenerateColors = false;
            this.btnadd.AutoRoundBorders = true;
            this.btnadd.AutoSizeLeftIcon = true;
            this.btnadd.AutoSizeRightIcon = true;
            this.btnadd.BackColor = System.Drawing.Color.Transparent;
            this.btnadd.BackColor1 = System.Drawing.Color.LimeGreen;
            this.btnadd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnadd.BackgroundImage")));
            this.btnadd.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnadd.ButtonText = "Añadir a la cesta";
            this.btnadd.ButtonTextMarginLeft = 0;
            this.btnadd.ColorContrastOnClick = 45;
            this.btnadd.ColorContrastOnHover = 45;
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnadd.CustomizableEdges = borderEdges1;
            this.btnadd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnadd.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnadd.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnadd.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnadd.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnadd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnadd.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnadd.IconMarginLeft = 11;
            this.btnadd.IconPadding = 10;
            this.btnadd.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnadd.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnadd.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnadd.IconSize = 25;
            this.btnadd.IdleBorderColor = System.Drawing.Color.LimeGreen;
            this.btnadd.IdleBorderRadius = 31;
            this.btnadd.IdleBorderThickness = 1;
            this.btnadd.IdleFillColor = System.Drawing.Color.LimeGreen;
            this.btnadd.IdleIconLeftImage = null;
            this.btnadd.IdleIconRightImage = null;
            this.btnadd.IndicateFocus = false;
            this.btnadd.Location = new System.Drawing.Point(271, 244);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnadd.Name = "btnadd";
            this.btnadd.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnadd.OnDisabledState.BorderRadius = 1;
            this.btnadd.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnadd.OnDisabledState.BorderThickness = 1;
            this.btnadd.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnadd.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnadd.OnDisabledState.IconLeftImage = null;
            this.btnadd.OnDisabledState.IconRightImage = null;
            this.btnadd.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnadd.onHoverState.BorderRadius = 1;
            this.btnadd.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnadd.onHoverState.BorderThickness = 1;
            this.btnadd.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnadd.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnadd.onHoverState.IconLeftImage = null;
            this.btnadd.onHoverState.IconRightImage = null;
            this.btnadd.OnIdleState.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnadd.OnIdleState.BorderRadius = 1;
            this.btnadd.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnadd.OnIdleState.BorderThickness = 1;
            this.btnadd.OnIdleState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnadd.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnadd.OnIdleState.IconLeftImage = null;
            this.btnadd.OnIdleState.IconRightImage = null;
            this.btnadd.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnadd.OnPressedState.BorderRadius = 1;
            this.btnadd.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnadd.OnPressedState.BorderThickness = 1;
            this.btnadd.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnadd.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnadd.OnPressedState.IconLeftImage = null;
            this.btnadd.OnPressedState.IconRightImage = null;
            this.btnadd.Size = new System.Drawing.Size(177, 33);
            this.btnadd.TabIndex = 5;
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnadd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnadd.TextMarginLeft = 0;
            this.btnadd.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnadd.UseDefaultRadiusAndThickness = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // lblcodigo
            // 
            this.lblcodigo.AllowParentOverrides = false;
            this.lblcodigo.AutoEllipsis = false;
            this.lblcodigo.CursorType = null;
            this.lblcodigo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcodigo.Location = new System.Drawing.Point(271, 105);
            this.lblcodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblcodigo.Size = new System.Drawing.Size(55, 20);
            this.lblcodigo.TabIndex = 3;
            this.lblcodigo.Text = "Codígo";
            this.lblcodigo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblcodigo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AllowParentOverrides = false;
            this.lblPrecio.AutoEllipsis = false;
            this.lblPrecio.CursorType = null;
            this.lblPrecio.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(271, 63);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrecio.Size = new System.Drawing.Size(47, 20);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio";
            this.lblPrecio.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblPrecio.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblname
            // 
            this.lblname.AllowParentOverrides = false;
            this.lblname.AutoEllipsis = false;
            this.lblname.CursorType = null;
            this.lblname.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(271, 20);
            this.lblname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblname.Name = "lblname";
            this.lblname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblname.Size = new System.Drawing.Size(177, 19);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "Nombre del producto";
            this.lblname.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblname.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ProductosTarg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuPanel1);
            this.Margin = new System.Windows.Forms.Padding(8, 15, 8, 15);
            this.Name = "ProductosTarg";
            this.Size = new System.Drawing.Size(583, 292);
            this.Load += new System.EventHandler(this.ProductosTarg_Load);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbimg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        public Bunifu.UI.WinForms.BunifuLabel lblname;
        public Bunifu.UI.WinForms.BunifuLabel lblcodigo;
        public Bunifu.UI.WinForms.BunifuLabel lblPrecio;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnadd;
        public System.Windows.Forms.RichTextBox lbldesc;
        public Bunifu.UI.WinForms.BunifuPictureBox ptbimg;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
