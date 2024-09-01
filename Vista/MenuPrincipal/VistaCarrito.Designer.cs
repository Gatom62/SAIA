namespace AgroServicios.Vista.MenuPrincipal
{
    partial class VistaCarrito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaCarrito));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbCliente = new Bunifu.UI.WinForms.BunifuDropdown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarClientes = new Bunifu.UI.WinForms.BunifuTextBox();
            this.dgvCarrito = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEliminarP = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btneliminar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnComprar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.dgvTotal = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.tableLayoutPanel2);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(1028, 70);
            this.bunifuPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbCliente, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBuscarClientes, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1028, 70);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::AgroServicios.Properties.Resources.Lupa_1;
            this.pictureBox2.Location = new System.Drawing.Point(257, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // cmbCliente
            // 
            this.cmbCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCliente.BackColor = System.Drawing.Color.Transparent;
            this.cmbCliente.BackgroundColor = System.Drawing.Color.White;
            this.cmbCliente.BorderColor = System.Drawing.Color.Silver;
            this.cmbCliente.BorderRadius = 1;
            this.cmbCliente.Color = System.Drawing.Color.Silver;
            this.cmbCliente.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cmbCliente.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbCliente.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbCliente.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbCliente.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbCliente.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbCliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCliente.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbCliente.FillDropDown = true;
            this.cmbCliente.FillIndicator = false;
            this.cmbCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCliente.ForeColor = System.Drawing.Color.Black;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Icon = null;
            this.cmbCliente.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbCliente.IndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbCliente.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbCliente.IndicatorThickness = 2;
            this.cmbCliente.IsDropdownOpened = false;
            this.cmbCliente.ItemBackColor = System.Drawing.Color.White;
            this.cmbCliente.ItemBorderColor = System.Drawing.Color.White;
            this.cmbCliente.ItemForeColor = System.Drawing.Color.Black;
            this.cmbCliente.ItemHeight = 26;
            this.cmbCliente.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cmbCliente.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cmbCliente.ItemTopMargin = 3;
            this.cmbCliente.Location = new System.Drawing.Point(619, 19);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(196, 32);
            this.cmbCliente.TabIndex = 2;
            this.cmbCliente.Text = null;
            this.cmbCliente.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbCliente.TextLeftMargin = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::AgroServicios.Properties.Resources.bolsita;
            this.pictureBox1.Location = new System.Drawing.Point(978, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carrito";
            // 
            // txtBuscarClientes
            // 
            this.txtBuscarClientes.AcceptsReturn = false;
            this.txtBuscarClientes.AcceptsTab = false;
            this.txtBuscarClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarClientes.AnimationSpeed = 200;
            this.txtBuscarClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBuscarClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBuscarClientes.AutoSizeHeight = true;
            this.txtBuscarClientes.BackColor = System.Drawing.Color.Transparent;
            this.txtBuscarClientes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtBuscarClientes.BackgroundImage")));
            this.txtBuscarClientes.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtBuscarClientes.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtBuscarClientes.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtBuscarClientes.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtBuscarClientes.BorderRadius = 15;
            this.txtBuscarClientes.BorderThickness = 1;
            this.txtBuscarClientes.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtBuscarClientes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBuscarClientes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarClientes.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtBuscarClientes.DefaultText = "";
            this.txtBuscarClientes.FillColor = System.Drawing.Color.White;
            this.txtBuscarClientes.HideSelection = true;
            this.txtBuscarClientes.IconLeft = null;
            this.txtBuscarClientes.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarClientes.IconPadding = 10;
            this.txtBuscarClientes.IconRight = null;
            this.txtBuscarClientes.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscarClientes.Lines = new string[0];
            this.txtBuscarClientes.Location = new System.Drawing.Point(309, 17);
            this.txtBuscarClientes.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscarClientes.MaxLength = 32767;
            this.txtBuscarClientes.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBuscarClientes.Modified = false;
            this.txtBuscarClientes.Multiline = false;
            this.txtBuscarClientes.Name = "txtBuscarClientes";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscarClientes.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtBuscarClientes.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscarClientes.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscarClientes.OnIdleState = stateProperties4;
            this.txtBuscarClientes.Padding = new System.Windows.Forms.Padding(2);
            this.txtBuscarClientes.PasswordChar = '\0';
            this.txtBuscarClientes.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBuscarClientes.PlaceholderText = "Buscar clientes";
            this.txtBuscarClientes.ReadOnly = false;
            this.txtBuscarClientes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuscarClientes.SelectedText = "";
            this.txtBuscarClientes.SelectionLength = 0;
            this.txtBuscarClientes.SelectionStart = 0;
            this.txtBuscarClientes.ShortcutsEnabled = true;
            this.txtBuscarClientes.Size = new System.Drawing.Size(304, 35);
            this.txtBuscarClientes.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtBuscarClientes.TabIndex = 1;
            this.txtBuscarClientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarClientes.TextMarginBottom = 0;
            this.txtBuscarClientes.TextMarginLeft = 3;
            this.txtBuscarClientes.TextMarginTop = 1;
            this.txtBuscarClientes.TextPlaceholder = "Buscar clientes";
            this.txtBuscarClientes.UseSystemPasswordChar = false;
            this.txtBuscarClientes.WordWrap = true;
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowCustomTheming = false;
            this.dgvCarrito.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvCarrito.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCarrito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCarrito.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCarrito.ColumnHeadersHeight = 40;
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Cantidad,
            this.PrecioUnitario,
            this.PrecioTotal});
            this.dgvCarrito.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCarrito.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvCarrito.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvCarrito.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCarrito.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvCarrito.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCarrito.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvCarrito.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvCarrito.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvCarrito.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvCarrito.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCarrito.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvCarrito.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCarrito.CurrentTheme.Name = null;
            this.dgvCarrito.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCarrito.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvCarrito.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCarrito.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvCarrito.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCarrito.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.EnableHeadersVisualStyles = false;
            this.dgvCarrito.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvCarrito.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvCarrito.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvCarrito.HeaderForeColor = System.Drawing.Color.White;
            this.dgvCarrito.Location = new System.Drawing.Point(0, 70);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.RowTemplate.Height = 40;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(1028, 448);
            this.dgvCarrito.TabIndex = 3;
            this.dgvCarrito.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.MinimumWidth = 6;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.MinimumWidth = 6;
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            // 
            // PrecioTotal
            // 
            this.PrecioTotal.HeaderText = "Precio Total";
            this.PrecioTotal.MinimumWidth = 6;
            this.PrecioTotal.Name = "PrecioTotal";
            this.PrecioTotal.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEliminarP});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 30);
            // 
            // cmsEliminarP
            // 
            this.cmsEliminarP.Image = global::AgroServicios.Properties.Resources.borrar;
            this.cmsEliminarP.Name = "cmsEliminarP";
            this.cmsEliminarP.Size = new System.Drawing.Size(173, 26);
            this.cmsEliminarP.Text = "Eliminar producto";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btneliminar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnComprar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 424);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1028, 94);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btneliminar
            // 
            this.btneliminar.AllowAnimations = true;
            this.btneliminar.AllowMouseEffects = true;
            this.btneliminar.AllowToggling = false;
            this.btneliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btneliminar.AnimationSpeed = 200;
            this.btneliminar.AutoGenerateColors = false;
            this.btneliminar.AutoRoundBorders = false;
            this.btneliminar.AutoSizeLeftIcon = true;
            this.btneliminar.AutoSizeRightIcon = true;
            this.btneliminar.BackColor = System.Drawing.Color.Transparent;
            this.btneliminar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.btneliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btneliminar.BackgroundImage")));
            this.btneliminar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btneliminar.ButtonText = "Eliminar compra";
            this.btneliminar.ButtonTextMarginLeft = 0;
            this.btneliminar.ColorContrastOnClick = 45;
            this.btneliminar.ColorContrastOnHover = 45;
            this.btneliminar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btneliminar.CustomizableEdges = borderEdges1;
            this.btneliminar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btneliminar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btneliminar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btneliminar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btneliminar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btneliminar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.ForeColor = System.Drawing.Color.Black;
            this.btneliminar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btneliminar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btneliminar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btneliminar.IconMarginLeft = 11;
            this.btneliminar.IconPadding = 10;
            this.btneliminar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btneliminar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btneliminar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btneliminar.IconSize = 25;
            this.btneliminar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.btneliminar.IdleBorderRadius = 20;
            this.btneliminar.IdleBorderThickness = 1;
            this.btneliminar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.btneliminar.IdleIconLeftImage = null;
            this.btneliminar.IdleIconRightImage = null;
            this.btneliminar.IndicateFocus = false;
            this.btneliminar.Location = new System.Drawing.Point(267, 51);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btneliminar.OnDisabledState.BorderRadius = 20;
            this.btneliminar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btneliminar.OnDisabledState.BorderThickness = 1;
            this.btneliminar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btneliminar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btneliminar.OnDisabledState.IconLeftImage = null;
            this.btneliminar.OnDisabledState.IconRightImage = null;
            this.btneliminar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btneliminar.onHoverState.BorderRadius = 20;
            this.btneliminar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btneliminar.onHoverState.BorderThickness = 1;
            this.btneliminar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btneliminar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btneliminar.onHoverState.IconLeftImage = null;
            this.btneliminar.onHoverState.IconRightImage = null;
            this.btneliminar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.btneliminar.OnIdleState.BorderRadius = 20;
            this.btneliminar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btneliminar.OnIdleState.BorderThickness = 1;
            this.btneliminar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(9)))), ((int)(((byte)(9)))));
            this.btneliminar.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btneliminar.OnIdleState.IconLeftImage = null;
            this.btneliminar.OnIdleState.IconRightImage = null;
            this.btneliminar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btneliminar.OnPressedState.BorderRadius = 20;
            this.btneliminar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btneliminar.OnPressedState.BorderThickness = 1;
            this.btneliminar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btneliminar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btneliminar.OnPressedState.IconLeftImage = null;
            this.btneliminar.OnPressedState.IconRightImage = null;
            this.btneliminar.Size = new System.Drawing.Size(494, 39);
            this.btneliminar.TabIndex = 6;
            this.btneliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btneliminar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btneliminar.TextMarginLeft = 0;
            this.btneliminar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btneliminar.UseDefaultRadiusAndThickness = true;
            // 
            // btnComprar
            // 
            this.btnComprar.AllowAnimations = true;
            this.btnComprar.AllowMouseEffects = true;
            this.btnComprar.AllowToggling = false;
            this.btnComprar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnComprar.AnimationSpeed = 200;
            this.btnComprar.AutoGenerateColors = false;
            this.btnComprar.AutoRoundBorders = false;
            this.btnComprar.AutoSizeLeftIcon = true;
            this.btnComprar.AutoSizeRightIcon = true;
            this.btnComprar.BackColor = System.Drawing.Color.Transparent;
            this.btnComprar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(231)))), ((int)(((byte)(64)))));
            this.btnComprar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnComprar.BackgroundImage")));
            this.btnComprar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnComprar.ButtonText = "Realizar compra";
            this.btnComprar.ButtonTextMarginLeft = 0;
            this.btnComprar.ColorContrastOnClick = 45;
            this.btnComprar.ColorContrastOnHover = 45;
            this.btnComprar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnComprar.CustomizableEdges = borderEdges2;
            this.btnComprar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnComprar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnComprar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnComprar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnComprar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnComprar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.ForeColor = System.Drawing.Color.Black;
            this.btnComprar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComprar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnComprar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnComprar.IconMarginLeft = 11;
            this.btnComprar.IconPadding = 10;
            this.btnComprar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComprar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnComprar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnComprar.IconSize = 25;
            this.btnComprar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(231)))), ((int)(((byte)(64)))));
            this.btnComprar.IdleBorderRadius = 20;
            this.btnComprar.IdleBorderThickness = 1;
            this.btnComprar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(231)))), ((int)(((byte)(64)))));
            this.btnComprar.IdleIconLeftImage = null;
            this.btnComprar.IdleIconRightImage = null;
            this.btnComprar.IndicateFocus = false;
            this.btnComprar.Location = new System.Drawing.Point(268, 4);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnComprar.OnDisabledState.BorderRadius = 20;
            this.btnComprar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnComprar.OnDisabledState.BorderThickness = 1;
            this.btnComprar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnComprar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnComprar.OnDisabledState.IconLeftImage = null;
            this.btnComprar.OnDisabledState.IconRightImage = null;
            this.btnComprar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnComprar.onHoverState.BorderRadius = 20;
            this.btnComprar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnComprar.onHoverState.BorderThickness = 1;
            this.btnComprar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnComprar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnComprar.onHoverState.IconLeftImage = null;
            this.btnComprar.onHoverState.IconRightImage = null;
            this.btnComprar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(231)))), ((int)(((byte)(64)))));
            this.btnComprar.OnIdleState.BorderRadius = 20;
            this.btnComprar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnComprar.OnIdleState.BorderThickness = 1;
            this.btnComprar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(231)))), ((int)(((byte)(64)))));
            this.btnComprar.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnComprar.OnIdleState.IconLeftImage = null;
            this.btnComprar.OnIdleState.IconRightImage = null;
            this.btnComprar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnComprar.OnPressedState.BorderRadius = 20;
            this.btnComprar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnComprar.OnPressedState.BorderThickness = 1;
            this.btnComprar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnComprar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnComprar.OnPressedState.IconLeftImage = null;
            this.btnComprar.OnPressedState.IconRightImage = null;
            this.btnComprar.Size = new System.Drawing.Size(492, 39);
            this.btnComprar.TabIndex = 5;
            this.btnComprar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnComprar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnComprar.TextMarginLeft = 0;
            this.btnComprar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnComprar.UseDefaultRadiusAndThickness = true;
            // 
            // dgvTotal
            // 
            this.dgvTotal.AllowCustomTheming = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvTotal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTotal.BackgroundColor = System.Drawing.Color.White;
            this.dgvTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTotal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTotal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTotal.ColumnHeadersHeight = 40;
            this.dgvTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Total});
            this.dgvTotal.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvTotal.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvTotal.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTotal.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvTotal.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTotal.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvTotal.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvTotal.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvTotal.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvTotal.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTotal.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvTotal.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTotal.CurrentTheme.Name = null;
            this.dgvTotal.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTotal.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvTotal.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTotal.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvTotal.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTotal.EnableHeadersVisualStyles = false;
            this.dgvTotal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvTotal.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvTotal.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvTotal.HeaderForeColor = System.Drawing.Color.White;
            this.dgvTotal.Location = new System.Drawing.Point(0, 329);
            this.dgvTotal.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.ReadOnly = true;
            this.dgvTotal.RowHeadersVisible = false;
            this.dgvTotal.RowHeadersWidth = 51;
            this.dgvTotal.RowTemplate.Height = 40;
            this.dgvTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotal.Size = new System.Drawing.Size(1028, 95);
            this.dgvTotal.TabIndex = 4;
            this.dgvTotal.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // VistaCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 518);
            this.Controls.Add(this.dgvTotal);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.bunifuPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "VistaCarrito";
            this.Text = "VistaCarrito";
            this.bunifuPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btneliminar;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnComprar;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvCarrito;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        public Bunifu.UI.WinForms.BunifuDropdown cmbCliente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        public Bunifu.UI.WinForms.BunifuTextBox txtBuscarClientes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem cmsEliminarP;
    }
}