namespace AgroServicios.Vista.Cuentas
{
    partial class VistaCuentasAdminUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaCuentasAdminUser));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.GriewEmpleados = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.contextGriewEmpleados = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsinfo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRestablecer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPreguntas = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ptbback = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBuscarP = new Bunifu.UI.WinForms.BunifuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GriewEmpleados)).BeginInit();
            this.contextGriewEmpleados.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GriewEmpleados
            // 
            this.GriewEmpleados.AllowCustomTheming = false;
            this.GriewEmpleados.AllowUserToAddRows = false;
            this.GriewEmpleados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.GriewEmpleados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GriewEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GriewEmpleados.BackgroundColor = System.Drawing.Color.White;
            this.GriewEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GriewEmpleados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GriewEmpleados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GriewEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GriewEmpleados.ColumnHeadersHeight = 40;
            this.GriewEmpleados.ContextMenuStrip = this.contextGriewEmpleados;
            this.GriewEmpleados.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.GriewEmpleados.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.GriewEmpleados.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GriewEmpleados.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.GriewEmpleados.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.GriewEmpleados.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.GriewEmpleados.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.GriewEmpleados.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.GriewEmpleados.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.GriewEmpleados.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GriewEmpleados.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.GriewEmpleados.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GriewEmpleados.CurrentTheme.Name = null;
            this.GriewEmpleados.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GriewEmpleados.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.GriewEmpleados.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GriewEmpleados.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.GriewEmpleados.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GriewEmpleados.DefaultCellStyle = dataGridViewCellStyle3;
            this.GriewEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GriewEmpleados.EnableHeadersVisualStyles = false;
            this.GriewEmpleados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.GriewEmpleados.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.GriewEmpleados.HeaderBgColor = System.Drawing.Color.Empty;
            this.GriewEmpleados.HeaderForeColor = System.Drawing.Color.White;
            this.GriewEmpleados.Location = new System.Drawing.Point(0, 60);
            this.GriewEmpleados.Margin = new System.Windows.Forms.Padding(2);
            this.GriewEmpleados.Name = "GriewEmpleados";
            this.GriewEmpleados.ReadOnly = true;
            this.GriewEmpleados.RowHeadersVisible = false;
            this.GriewEmpleados.RowHeadersWidth = 51;
            this.GriewEmpleados.RowTemplate.Height = 40;
            this.GriewEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GriewEmpleados.Size = new System.Drawing.Size(1044, 272);
            this.GriewEmpleados.TabIndex = 3;
            this.GriewEmpleados.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // contextGriewEmpleados
            // 
            this.contextGriewEmpleados.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextGriewEmpleados.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEliminar,
            this.cmsUpdate,
            this.cmsinfo,
            this.cmsRestablecer,
            this.cmsPreguntas});
            this.contextGriewEmpleados.Name = "contextMenuStrip1";
            this.contextGriewEmpleados.Size = new System.Drawing.Size(219, 134);
            // 
            // cmsEliminar
            // 
            this.cmsEliminar.Image = global::AgroServicios.Properties.Resources.borrar;
            this.cmsEliminar.Name = "cmsEliminar";
            this.cmsEliminar.Size = new System.Drawing.Size(218, 26);
            this.cmsEliminar.Text = "Eliminar";
            // 
            // cmsUpdate
            // 
            this.cmsUpdate.Image = global::AgroServicios.Properties.Resources.actualizar;
            this.cmsUpdate.Name = "cmsUpdate";
            this.cmsUpdate.Size = new System.Drawing.Size(218, 26);
            this.cmsUpdate.Text = "Actualizar Datos";
            // 
            // cmsinfo
            // 
            this.cmsinfo.Image = global::AgroServicios.Properties.Resources.informacion;
            this.cmsinfo.Name = "cmsinfo";
            this.cmsinfo.Size = new System.Drawing.Size(218, 26);
            this.cmsinfo.Text = "Información del Empleado";
            // 
            // cmsRestablecer
            // 
            this.cmsRestablecer.Image = global::AgroServicios.Properties.Resources.bloqueo_de_rotacion__2_;
            this.cmsRestablecer.Name = "cmsRestablecer";
            this.cmsRestablecer.Size = new System.Drawing.Size(218, 26);
            this.cmsRestablecer.Text = "Restablecer Empleado";
            // 
            // cmsPreguntas
            // 
            this.cmsPreguntas.Name = "cmsPreguntas";
            this.cmsPreguntas.Size = new System.Drawing.Size(218, 26);
            this.cmsPreguntas.Text = "Preguntas de seguridad.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 60);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.350194F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.225681F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.72763F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.6965F));
            this.tableLayoutPanel1.Controls.Add(this.ptbback, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ptbback
            // 
            this.ptbback.AllowAnimations = true;
            this.ptbback.AllowBorderColorChanges = true;
            this.ptbback.AllowMouseEffects = true;
            this.ptbback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbback.AnimationSpeed = 200;
            this.ptbback.BackColor = System.Drawing.Color.Transparent;
            this.ptbback.BackgroundColor = System.Drawing.Color.Transparent;
            this.ptbback.BorderColor = System.Drawing.Color.Transparent;
            this.ptbback.BorderRadius = 1;
            this.ptbback.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
            this.ptbback.BorderThickness = 1;
            this.ptbback.ColorContrastOnClick = 30;
            this.ptbback.ColorContrastOnHover = 30;
            this.ptbback.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.ptbback.CustomizableEdges = borderEdges1;
            this.ptbback.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ptbback.Image = global::AgroServicios.Properties.Resources.turn_left_11044726;
            this.ptbback.ImageMargin = new System.Windows.Forms.Padding(0);
            this.ptbback.Location = new System.Drawing.Point(2, 6);
            this.ptbback.Margin = new System.Windows.Forms.Padding(2);
            this.ptbback.Name = "ptbback";
            this.ptbback.RoundBorders = false;
            this.ptbback.ShowBorders = false;
            this.ptbback.Size = new System.Drawing.Size(50, 48);
            this.ptbback.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Flat;
            this.ptbback.TabIndex = 27;
            this.ptbback.MouseEnter += new System.EventHandler(this.ptbback_MouseEnter);
            this.ptbback.MouseLeave += new System.EventHandler(this.ptbback_MouseLeave);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::AgroServicios.Properties.Resources.Lupa_1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(82, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 37);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtBuscarP, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(121, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(619, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtBuscarP
            // 
            this.txtBuscarP.AcceptsReturn = false;
            this.txtBuscarP.AcceptsTab = false;
            this.txtBuscarP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarP.AnimationSpeed = 200;
            this.txtBuscarP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBuscarP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBuscarP.AutoSizeHeight = true;
            this.txtBuscarP.BackColor = System.Drawing.Color.Transparent;
            this.txtBuscarP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtBuscarP.BackgroundImage")));
            this.txtBuscarP.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtBuscarP.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtBuscarP.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtBuscarP.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtBuscarP.BorderRadius = 30;
            this.txtBuscarP.BorderThickness = 1;
            this.txtBuscarP.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtBuscarP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBuscarP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarP.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtBuscarP.DefaultText = "";
            this.txtBuscarP.FillColor = System.Drawing.Color.White;
            this.txtBuscarP.HideSelection = true;
            this.txtBuscarP.IconLeft = null;
            this.txtBuscarP.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarP.IconPadding = 10;
            this.txtBuscarP.IconRight = null;
            this.txtBuscarP.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarP.Lines = new string[0];
            this.txtBuscarP.Location = new System.Drawing.Point(2, 10);
            this.txtBuscarP.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscarP.MaxLength = 32767;
            this.txtBuscarP.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBuscarP.Modified = false;
            this.txtBuscarP.Multiline = false;
            this.txtBuscarP.Name = "txtBuscarP";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscarP.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtBuscarP.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscarP.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscarP.OnIdleState = stateProperties4;
            this.txtBuscarP.Padding = new System.Windows.Forms.Padding(2);
            this.txtBuscarP.PasswordChar = '\0';
            this.txtBuscarP.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBuscarP.PlaceholderText = "Buscar";
            this.txtBuscarP.ReadOnly = false;
            this.txtBuscarP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuscarP.SelectedText = "";
            this.txtBuscarP.SelectionLength = 0;
            this.txtBuscarP.SelectionStart = 0;
            this.txtBuscarP.ShortcutsEnabled = true;
            this.txtBuscarP.Size = new System.Drawing.Size(615, 35);
            this.txtBuscarP.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtBuscarP.TabIndex = 2;
            this.txtBuscarP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarP.TextMarginBottom = 0;
            this.txtBuscarP.TextMarginLeft = 3;
            this.txtBuscarP.TextMarginTop = 1;
            this.txtBuscarP.TextPlaceholder = "Buscar";
            this.txtBuscarP.UseSystemPasswordChar = false;
            this.txtBuscarP.WordWrap = true;
            // 
            // VistaCuentasAdminUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 332);
            this.Controls.Add(this.GriewEmpleados);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaCuentasAdminUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas de los administradores y empleados - Administrador";
            this.Load += new System.EventHandler(this.VistaCuentasAdminUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GriewEmpleados)).EndInit();
            this.contextGriewEmpleados.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Bunifu.UI.WinForms.BunifuDataGridView GriewEmpleados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public Bunifu.UI.WinForms.BunifuTextBox txtBuscarP;
        private System.Windows.Forms.ContextMenuStrip contextGriewEmpleados;
        public System.Windows.Forms.ToolStripMenuItem cmsEliminar;
        public System.Windows.Forms.ToolStripMenuItem cmsUpdate;
        public System.Windows.Forms.ToolStripMenuItem cmsinfo;
        public System.Windows.Forms.ToolStripMenuItem cmsRestablecer;
        public System.Windows.Forms.ToolStripMenuItem cmsPreguntas;
        public Bunifu.UI.WinForms.BunifuButton.BunifuIconButton ptbback;
    }
}