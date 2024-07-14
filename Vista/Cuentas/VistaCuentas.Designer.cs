namespace AgroServicios.Vista.Cuentas
{
    partial class VistaCuentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaCuentas));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.GriewEmpleados = new System.Windows.Forms.DataGridView();
            this.contextGriewEmpleados = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAgregar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.cmsEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónDelEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GriewEmpleados)).BeginInit();
            this.contextGriewEmpleados.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19)))));
            this.flowLayoutPanel1.Controls.Add(this.btnAgregar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1394, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // GriewEmpleados
            // 
            this.GriewEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GriewEmpleados.BackgroundColor = System.Drawing.Color.White;
            this.GriewEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GriewEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GriewEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GriewEmpleados.ContextMenuStrip = this.contextGriewEmpleados;
            this.GriewEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GriewEmpleados.EnableHeadersVisualStyles = false;
            this.GriewEmpleados.Location = new System.Drawing.Point(0, 64);
            this.GriewEmpleados.Name = "GriewEmpleados";
            this.GriewEmpleados.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.GriewEmpleados.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GriewEmpleados.RowTemplate.Height = 24;
            this.GriewEmpleados.Size = new System.Drawing.Size(1394, 297);
            this.GriewEmpleados.TabIndex = 2;
            // 
            // contextGriewEmpleados
            // 
            this.contextGriewEmpleados.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextGriewEmpleados.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEliminar,
            this.actualizarDatosToolStripMenuItem,
            this.informaciónDelEmpleadoToolStripMenuItem});
            this.contextGriewEmpleados.Name = "contextMenuStrip1";
            this.contextGriewEmpleados.Size = new System.Drawing.Size(260, 110);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AllowAnimations = true;
            this.btnAgregar.AllowMouseEffects = true;
            this.btnAgregar.AllowToggling = true;
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.AnimationSpeed = 200;
            this.btnAgregar.AutoGenerateColors = false;
            this.btnAgregar.AutoRoundBorders = true;
            this.btnAgregar.AutoSizeLeftIcon = true;
            this.btnAgregar.AutoSizeRightIcon = true;
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(242)))), ((int)(((byte)(32)))));
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.ButtonText = "Añadir";
            this.btnAgregar.ButtonTextMarginLeft = 0;
            this.btnAgregar.ColorContrastOnClick = 45;
            this.btnAgregar.ColorContrastOnHover = 45;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAgregar.CustomizableEdges = borderEdges1;
            this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAgregar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAgregar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAgregar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAgregar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAgregar.IconMarginLeft = 11;
            this.btnAgregar.IconPadding = 10;
            this.btnAgregar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAgregar.IconSize = 25;
            this.btnAgregar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(242)))), ((int)(((byte)(32)))));
            this.btnAgregar.IdleBorderRadius = 53;
            this.btnAgregar.IdleBorderThickness = 1;
            this.btnAgregar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(242)))), ((int)(((byte)(32)))));
            this.btnAgregar.IdleIconLeftImage = null;
            this.btnAgregar.IdleIconRightImage = null;
            this.btnAgregar.IndicateFocus = true;
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAgregar.OnDisabledState.BorderRadius = 1;
            this.btnAgregar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.OnDisabledState.BorderThickness = 1;
            this.btnAgregar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAgregar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAgregar.OnDisabledState.IconLeftImage = null;
            this.btnAgregar.OnDisabledState.IconRightImage = null;
            this.btnAgregar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnAgregar.onHoverState.BorderRadius = 1;
            this.btnAgregar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.onHoverState.BorderThickness = 1;
            this.btnAgregar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnAgregar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.onHoverState.IconLeftImage = null;
            this.btnAgregar.onHoverState.IconRightImage = null;
            this.btnAgregar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(242)))), ((int)(((byte)(32)))));
            this.btnAgregar.OnIdleState.BorderRadius = 1;
            this.btnAgregar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.OnIdleState.BorderThickness = 1;
            this.btnAgregar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(242)))), ((int)(((byte)(32)))));
            this.btnAgregar.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.OnIdleState.IconLeftImage = null;
            this.btnAgregar.OnIdleState.IconRightImage = null;
            this.btnAgregar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnAgregar.OnPressedState.BorderRadius = 1;
            this.btnAgregar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.OnPressedState.BorderThickness = 1;
            this.btnAgregar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnAgregar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.OnPressedState.IconLeftImage = null;
            this.btnAgregar.OnPressedState.IconRightImage = null;
            this.btnAgregar.Size = new System.Drawing.Size(216, 55);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAgregar.TextMarginLeft = 0;
            this.btnAgregar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAgregar.UseDefaultRadiusAndThickness = true;
            // 
            // cmsEliminar
            // 
            this.cmsEliminar.Image = global::AgroServicios.Properties.Resources.borrar;
            this.cmsEliminar.Name = "cmsEliminar";
            this.cmsEliminar.Size = new System.Drawing.Size(259, 26);
            this.cmsEliminar.Text = "Eliminar";
            // 
            // actualizarDatosToolStripMenuItem
            // 
            this.actualizarDatosToolStripMenuItem.Image = global::AgroServicios.Properties.Resources.actualizar;
            this.actualizarDatosToolStripMenuItem.Name = "actualizarDatosToolStripMenuItem";
            this.actualizarDatosToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.actualizarDatosToolStripMenuItem.Text = "Actualizar Datos";
            // 
            // informaciónDelEmpleadoToolStripMenuItem
            // 
            this.informaciónDelEmpleadoToolStripMenuItem.Image = global::AgroServicios.Properties.Resources.informacion;
            this.informaciónDelEmpleadoToolStripMenuItem.Name = "informaciónDelEmpleadoToolStripMenuItem";
            this.informaciónDelEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.informaciónDelEmpleadoToolStripMenuItem.Text = "Información del Empleado";
            // 
            // VistaCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 361);
            this.Controls.Add(this.GriewEmpleados);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "VistaCuentas";
            this.Text = "VistaCuentas";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GriewEmpleados)).EndInit();
            this.contextGriewEmpleados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.DataGridView GriewEmpleados;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAgregar;
        private System.Windows.Forms.ContextMenuStrip contextGriewEmpleados;
        private System.Windows.Forms.ToolStripMenuItem actualizarDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaciónDelEmpleadoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cmsEliminar;
    }
}