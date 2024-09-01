namespace AgroServicios.Vista.Estadisticas
{
    partial class VistaProveedores
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
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaProveedores));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.contextGriewProveedores = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GriewProveedores = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBuscarP = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnAgregarProv = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextGriewProveedores.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GriewProveedores)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextGriewProveedores
            // 
            this.contextGriewProveedores.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextGriewProveedores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEliminar,
            this.cmsActualizar});
            this.contextGriewProveedores.Name = "contextMenuStrip1";
            this.contextGriewProveedores.Size = new System.Drawing.Size(131, 56);
            this.contextGriewProveedores.Opening += new System.ComponentModel.CancelEventHandler(this.contextGriewProveedores_Opening);
            // 
            // cmsEliminar
            // 
            this.cmsEliminar.Image = global::AgroServicios.Properties.Resources.borrar;
            this.cmsEliminar.Name = "cmsEliminar";
            this.cmsEliminar.Size = new System.Drawing.Size(130, 26);
            this.cmsEliminar.Text = "Eliminar";
            this.cmsEliminar.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // cmsActualizar
            // 
            this.cmsActualizar.Image = global::AgroServicios.Properties.Resources.actualizar;
            this.cmsActualizar.Name = "cmsActualizar";
            this.cmsActualizar.Size = new System.Drawing.Size(130, 26);
            this.cmsActualizar.Text = "Actualizar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 62);
            this.panel1.TabIndex = 0;
            // 
            // GriewProveedores
            // 
            this.GriewProveedores.AllowCustomTheming = false;
            this.GriewProveedores.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.GriewProveedores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GriewProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GriewProveedores.BackgroundColor = System.Drawing.Color.White;
            this.GriewProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GriewProveedores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GriewProveedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GriewProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GriewProveedores.ColumnHeadersHeight = 40;
            this.GriewProveedores.ContextMenuStrip = this.contextGriewProveedores;
            this.GriewProveedores.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.GriewProveedores.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.GriewProveedores.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GriewProveedores.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.GriewProveedores.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.GriewProveedores.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.GriewProveedores.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.GriewProveedores.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.GriewProveedores.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.GriewProveedores.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GriewProveedores.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.GriewProveedores.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GriewProveedores.CurrentTheme.Name = null;
            this.GriewProveedores.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GriewProveedores.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.GriewProveedores.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GriewProveedores.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.GriewProveedores.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GriewProveedores.DefaultCellStyle = dataGridViewCellStyle3;
            this.GriewProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GriewProveedores.EnableHeadersVisualStyles = false;
            this.GriewProveedores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.GriewProveedores.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.GriewProveedores.HeaderBgColor = System.Drawing.Color.Empty;
            this.GriewProveedores.HeaderForeColor = System.Drawing.Color.White;
            this.GriewProveedores.Location = new System.Drawing.Point(0, 62);
            this.GriewProveedores.Name = "GriewProveedores";
            this.GriewProveedores.ReadOnly = true;
            this.GriewProveedores.RowHeadersVisible = false;
            this.GriewProveedores.RowHeadersWidth = 51;
            this.GriewProveedores.RowTemplate.Height = 40;
            this.GriewProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GriewProveedores.Size = new System.Drawing.Size(1028, 515);
            this.GriewProveedores.TabIndex = 3;
            this.GriewProveedores.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::AgroServicios.Properties.Resources.Lupa_1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(295, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 37);
            this.button1.TabIndex = 27;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtBuscarP, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(334, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(480, 58);
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
            this.txtBuscarP.Size = new System.Drawing.Size(476, 36);
            this.txtBuscarP.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtBuscarP.TabIndex = 1;
            this.txtBuscarP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarP.TextMarginBottom = 0;
            this.txtBuscarP.TextMarginLeft = 3;
            this.txtBuscarP.TextMarginTop = 1;
            this.txtBuscarP.TextPlaceholder = "Buscar";
            this.txtBuscarP.UseSystemPasswordChar = false;
            this.txtBuscarP.WordWrap = true;
            // 
            // btnAgregarProv
            // 
            this.btnAgregarProv.AllowAnimations = true;
            this.btnAgregarProv.AllowMouseEffects = true;
            this.btnAgregarProv.AllowToggling = true;
            this.btnAgregarProv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarProv.AnimationSpeed = 200;
            this.btnAgregarProv.AutoGenerateColors = false;
            this.btnAgregarProv.AutoRoundBorders = true;
            this.btnAgregarProv.AutoSizeLeftIcon = true;
            this.btnAgregarProv.AutoSizeRightIcon = true;
            this.btnAgregarProv.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarProv.BackColor1 = System.Drawing.Color.LimeGreen;
            this.btnAgregarProv.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarProv.BackgroundImage")));
            this.btnAgregarProv.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregarProv.ButtonText = "Agregar";
            this.btnAgregarProv.ButtonTextMarginLeft = 0;
            this.btnAgregarProv.ColorContrastOnClick = 45;
            this.btnAgregarProv.ColorContrastOnHover = 45;
            this.btnAgregarProv.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAgregarProv.CustomizableEdges = borderEdges1;
            this.btnAgregarProv.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAgregarProv.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAgregarProv.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAgregarProv.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAgregarProv.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAgregarProv.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProv.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProv.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarProv.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregarProv.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAgregarProv.IconMarginLeft = 11;
            this.btnAgregarProv.IconPadding = 10;
            this.btnAgregarProv.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarProv.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregarProv.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAgregarProv.IconSize = 25;
            this.btnAgregarProv.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnAgregarProv.IdleBorderRadius = 43;
            this.btnAgregarProv.IdleBorderThickness = 1;
            this.btnAgregarProv.IdleFillColor = System.Drawing.Color.LimeGreen;
            this.btnAgregarProv.IdleIconLeftImage = null;
            this.btnAgregarProv.IdleIconRightImage = null;
            this.btnAgregarProv.IndicateFocus = true;
            this.btnAgregarProv.Location = new System.Drawing.Point(847, 8);
            this.btnAgregarProv.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarProv.Name = "btnAgregarProv";
            this.btnAgregarProv.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAgregarProv.OnDisabledState.BorderRadius = 1;
            this.btnAgregarProv.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregarProv.OnDisabledState.BorderThickness = 1;
            this.btnAgregarProv.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAgregarProv.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAgregarProv.OnDisabledState.IconLeftImage = null;
            this.btnAgregarProv.OnDisabledState.IconRightImage = null;
            this.btnAgregarProv.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnAgregarProv.onHoverState.BorderRadius = 1;
            this.btnAgregarProv.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregarProv.onHoverState.BorderThickness = 1;
            this.btnAgregarProv.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnAgregarProv.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProv.onHoverState.IconLeftImage = null;
            this.btnAgregarProv.onHoverState.IconRightImage = null;
            this.btnAgregarProv.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAgregarProv.OnIdleState.BorderRadius = 1;
            this.btnAgregarProv.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregarProv.OnIdleState.BorderThickness = 1;
            this.btnAgregarProv.OnIdleState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnAgregarProv.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProv.OnIdleState.IconLeftImage = null;
            this.btnAgregarProv.OnIdleState.IconRightImage = null;
            this.btnAgregarProv.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnAgregarProv.OnPressedState.BorderRadius = 1;
            this.btnAgregarProv.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregarProv.OnPressedState.BorderThickness = 1;
            this.btnAgregarProv.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnAgregarProv.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProv.OnPressedState.IconLeftImage = null;
            this.btnAgregarProv.OnPressedState.IconRightImage = null;
            this.btnAgregarProv.Size = new System.Drawing.Size(151, 45);
            this.btnAgregarProv.TabIndex = 2;
            this.btnAgregarProv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregarProv.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAgregarProv.TextMarginLeft = 0;
            this.btnAgregarProv.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAgregarProv.UseDefaultRadiusAndThickness = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19)))));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.161567F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.33415F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.147059F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.31372F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarProv, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 62);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedores";
            // 
            // VistaProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 577);
            this.Controls.Add(this.GriewProveedores);
            this.Controls.Add(this.panel1);
            this.Name = "VistaProveedores";
            this.Text = "VistaProveedores";
            this.Load += new System.EventHandler(this.VistaProveedores_Load);
            this.contextGriewProveedores.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GriewProveedores)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextGriewProveedores;
        public System.Windows.Forms.ToolStripMenuItem cmsEliminar;
        public System.Windows.Forms.ToolStripMenuItem cmsActualizar;
        private System.Windows.Forms.Panel panel1;
        public Bunifu.UI.WinForms.BunifuDataGridView GriewProveedores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAgregarProv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public Bunifu.UI.WinForms.BunifuTextBox txtBuscarP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}