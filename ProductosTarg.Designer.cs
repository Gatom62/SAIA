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
            this.ptbimg = new System.Windows.Forms.PictureBox();
            this.btnadd = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.lbldesc = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblcodigo = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblPrecio = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblname = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbimg)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 30;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.ptbimg);
            this.bunifuPanel1.Controls.Add(this.btnadd);
            this.bunifuPanel1.Controls.Add(this.lbldesc);
            this.bunifuPanel1.Controls.Add(this.lblcodigo);
            this.bunifuPanel1.Controls.Add(this.lblPrecio);
            this.bunifuPanel1.Controls.Add(this.lblname);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(390, 285);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // ptbimg
            // 
            this.ptbimg.Image = global::AgroServicios.Properties.Resources.Group;
            this.ptbimg.Location = new System.Drawing.Point(19, 20);
            this.ptbimg.Name = "ptbimg";
            this.ptbimg.Size = new System.Drawing.Size(159, 245);
            this.ptbimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbimg.TabIndex = 6;
            this.ptbimg.TabStop = false;
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
            this.btnadd.BackColor1 = System.Drawing.Color.DodgerBlue;
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
            this.btnadd.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnadd.IdleBorderRadius = 31;
            this.btnadd.IdleBorderThickness = 1;
            this.btnadd.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnadd.IdleIconLeftImage = null;
            this.btnadd.IdleIconRightImage = null;
            this.btnadd.IndicateFocus = false;
            this.btnadd.Location = new System.Drawing.Point(210, 232);
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
            this.btnadd.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnadd.OnIdleState.BorderRadius = 1;
            this.btnadd.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnadd.OnIdleState.BorderThickness = 1;
            this.btnadd.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
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
            this.btnadd.Size = new System.Drawing.Size(140, 33);
            this.btnadd.TabIndex = 5;
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnadd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnadd.TextMarginLeft = 0;
            this.btnadd.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnadd.UseDefaultRadiusAndThickness = true;
            // 
            // lbldesc
            // 
            this.lbldesc.AllowParentOverrides = false;
            this.lbldesc.AutoEllipsis = false;
            this.lbldesc.CursorType = null;
            this.lbldesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbldesc.Location = new System.Drawing.Point(215, 149);
            this.lbldesc.Name = "lbldesc";
            this.lbldesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbldesc.Size = new System.Drawing.Size(78, 20);
            this.lbldesc.TabIndex = 4;
            this.lbldesc.Text = "Descripción";
            this.lbldesc.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbldesc.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblcodigo
            // 
            this.lblcodigo.AllowParentOverrides = false;
            this.lblcodigo.AutoEllipsis = false;
            this.lblcodigo.CursorType = null;
            this.lblcodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblcodigo.Location = new System.Drawing.Point(215, 105);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblcodigo.Size = new System.Drawing.Size(49, 20);
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
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecio.Location = new System.Drawing.Point(210, 64);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrecio.Size = new System.Drawing.Size(41, 20);
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
            this.lblname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblname.Location = new System.Drawing.Point(210, 20);
            this.lblname.Name = "lblname";
            this.lblname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblname.Size = new System.Drawing.Size(145, 20);
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
            this.Name = "ProductosTarg";
            this.Size = new System.Drawing.Size(390, 285);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbimg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        public Bunifu.UI.WinForms.BunifuLabel lblname;
        public Bunifu.UI.WinForms.BunifuLabel lbldesc;
        public Bunifu.UI.WinForms.BunifuLabel lblcodigo;
        public Bunifu.UI.WinForms.BunifuLabel lblPrecio;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnadd;
        public System.Windows.Forms.PictureBox ptbimg;
    }
}
