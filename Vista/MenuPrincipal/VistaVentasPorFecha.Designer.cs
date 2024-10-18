namespace AgroServicios.Vista.MenuPrincipal
{
    partial class VistaVentasPorFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaVentasPorFecha));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Productos = new System.Windows.Forms.Label();
            this.btnBuscar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpinicio = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpfinal = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.GriewFiltroV = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GriewFiltroV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 68);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.90909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.81818F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.27273F));
            this.tableLayoutPanel1.Controls.Add(this.Productos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1210, 68);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Productos
            // 
            this.Productos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Productos.AutoSize = true;
            this.Productos.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Productos.ForeColor = System.Drawing.Color.White;
            this.Productos.Location = new System.Drawing.Point(17, 13);
            this.Productos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Productos.Name = "Productos";
            this.Productos.Size = new System.Drawing.Size(134, 41);
            this.Productos.TabIndex = 35;
            this.Productos.Text = "Ventas";
            // 
            // btnBuscar
            // 
            this.btnBuscar.AllowAnimations = true;
            this.btnBuscar.AllowMouseEffects = true;
            this.btnBuscar.AllowToggling = false;
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscar.AnimationSpeed = 200;
            this.btnBuscar.AutoGenerateColors = false;
            this.btnBuscar.AutoRoundBorders = false;
            this.btnBuscar.AutoSizeLeftIcon = true;
            this.btnBuscar.AutoSizeRightIcon = true;
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnBuscar.ButtonText = "Buscar";
            this.btnBuscar.ButtonTextMarginLeft = 0;
            this.btnBuscar.ColorContrastOnClick = 45;
            this.btnBuscar.ColorContrastOnHover = 45;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnBuscar.CustomizableEdges = borderEdges1;
            this.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBuscar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBuscar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBuscar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBuscar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnBuscar.IconMarginLeft = 11;
            this.btnBuscar.IconPadding = 10;
            this.btnBuscar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnBuscar.IconSize = 25;
            this.btnBuscar.IdleBorderColor = System.Drawing.Color.Transparent;
            this.btnBuscar.IdleBorderRadius = 15;
            this.btnBuscar.IdleBorderThickness = 1;
            this.btnBuscar.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.IdleIconLeftImage = null;
            this.btnBuscar.IdleIconRightImage = null;
            this.btnBuscar.IndicateFocus = false;
            this.btnBuscar.Location = new System.Drawing.Point(188, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnBuscar.OnDisabledState.BorderRadius = 15;
            this.btnBuscar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnBuscar.OnDisabledState.BorderThickness = 1;
            this.btnBuscar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnBuscar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnBuscar.OnDisabledState.IconLeftImage = null;
            this.btnBuscar.OnDisabledState.IconRightImage = null;
            this.btnBuscar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnBuscar.onHoverState.BorderRadius = 15;
            this.btnBuscar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnBuscar.onHoverState.BorderThickness = 1;
            this.btnBuscar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnBuscar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.onHoverState.IconLeftImage = null;
            this.btnBuscar.onHoverState.IconRightImage = null;
            this.btnBuscar.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.btnBuscar.OnIdleState.BorderRadius = 15;
            this.btnBuscar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnBuscar.OnIdleState.BorderThickness = 1;
            this.btnBuscar.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.OnIdleState.IconLeftImage = null;
            this.btnBuscar.OnIdleState.IconRightImage = null;
            this.btnBuscar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnBuscar.OnPressedState.BorderRadius = 15;
            this.btnBuscar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnBuscar.OnPressedState.BorderThickness = 1;
            this.btnBuscar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnBuscar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.OnPressedState.IconLeftImage = null;
            this.btnBuscar.OnPressedState.IconRightImage = null;
            this.btnBuscar.Size = new System.Drawing.Size(186, 48);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBuscar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnBuscar.TextMarginLeft = 0;
            this.btnBuscar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnBuscar.UseDefaultRadiusAndThickness = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.dtpinicio);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtpfinal);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(397, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(811, 64);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 16, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de inicio:";
            // 
            // dtpinicio
            // 
            this.dtpinicio.BackColor = System.Drawing.Color.Transparent;
            this.dtpinicio.BorderColor = System.Drawing.Color.White;
            this.dtpinicio.BorderRadius = 10;
            this.dtpinicio.CalendarFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpinicio.Color = System.Drawing.Color.White;
            this.dtpinicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpinicio.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtpinicio.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtpinicio.DisabledColor = System.Drawing.Color.Gray;
            this.dtpinicio.DisplayWeekNumbers = false;
            this.dtpinicio.DPHeight = 0;
            this.dtpinicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpinicio.FillDatePicker = false;
            this.dtpinicio.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpinicio.ForeColor = System.Drawing.Color.Black;
            this.dtpinicio.Icon = ((System.Drawing.Image)(resources.GetObject("dtpinicio.Icon")));
            this.dtpinicio.IconColor = System.Drawing.Color.Gray;
            this.dtpinicio.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtpinicio.LeftTextMargin = 5;
            this.dtpinicio.Location = new System.Drawing.Point(172, 20);
            this.dtpinicio.Margin = new System.Windows.Forms.Padding(5, 20, 2, 2);
            this.dtpinicio.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtpinicio.Name = "dtpinicio";
            this.dtpinicio.Size = new System.Drawing.Size(247, 32);
            this.dtpinicio.TabIndex = 1;
            this.dtpinicio.Value = new System.DateTime(2024, 8, 28, 17, 52, 0, 0);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(436, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(15, 16, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Final:";
            // 
            // dtpfinal
            // 
            this.dtpfinal.BackColor = System.Drawing.Color.Transparent;
            this.dtpfinal.BorderColor = System.Drawing.Color.White;
            this.dtpfinal.BorderRadius = 10;
            this.dtpfinal.Color = System.Drawing.Color.White;
            this.dtpfinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpfinal.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dtpfinal.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.dtpfinal.DisabledColor = System.Drawing.Color.Gray;
            this.dtpfinal.DisplayWeekNumbers = false;
            this.dtpfinal.DPHeight = 0;
            this.dtpfinal.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpfinal.FillDatePicker = false;
            this.dtpfinal.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfinal.ForeColor = System.Drawing.Color.Black;
            this.dtpfinal.Icon = ((System.Drawing.Image)(resources.GetObject("dtpfinal.Icon")));
            this.dtpfinal.IconColor = System.Drawing.Color.Gray;
            this.dtpfinal.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.dtpfinal.LeftTextMargin = 5;
            this.dtpfinal.Location = new System.Drawing.Point(560, 20);
            this.dtpfinal.Margin = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.dtpfinal.MinimumSize = new System.Drawing.Size(4, 32);
            this.dtpfinal.Name = "dtpfinal";
            this.dtpfinal.Size = new System.Drawing.Size(242, 32);
            this.dtpfinal.TabIndex = 3;
            this.dtpfinal.Value = new System.DateTime(2024, 8, 28, 17, 55, 0, 0);
            // 
            // GriewFiltroV
            // 
            this.GriewFiltroV.AllowCustomTheming = false;
            this.GriewFiltroV.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.GriewFiltroV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GriewFiltroV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GriewFiltroV.BackgroundColor = System.Drawing.Color.White;
            this.GriewFiltroV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GriewFiltroV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GriewFiltroV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GriewFiltroV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GriewFiltroV.ColumnHeadersHeight = 40;
            this.GriewFiltroV.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.GriewFiltroV.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.GriewFiltroV.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GriewFiltroV.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.GriewFiltroV.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.GriewFiltroV.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.GriewFiltroV.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.GriewFiltroV.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.GriewFiltroV.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.GriewFiltroV.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GriewFiltroV.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.GriewFiltroV.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.GriewFiltroV.CurrentTheme.Name = null;
            this.GriewFiltroV.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GriewFiltroV.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.GriewFiltroV.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GriewFiltroV.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.GriewFiltroV.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GriewFiltroV.DefaultCellStyle = dataGridViewCellStyle3;
            this.GriewFiltroV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GriewFiltroV.EnableHeadersVisualStyles = false;
            this.GriewFiltroV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.GriewFiltroV.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.GriewFiltroV.HeaderBgColor = System.Drawing.Color.Empty;
            this.GriewFiltroV.HeaderForeColor = System.Drawing.Color.White;
            this.GriewFiltroV.Location = new System.Drawing.Point(0, 68);
            this.GriewFiltroV.Margin = new System.Windows.Forms.Padding(2);
            this.GriewFiltroV.Name = "GriewFiltroV";
            this.GriewFiltroV.ReadOnly = true;
            this.GriewFiltroV.RowHeadersVisible = false;
            this.GriewFiltroV.RowHeadersWidth = 51;
            this.GriewFiltroV.RowTemplate.Height = 40;
            this.GriewFiltroV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GriewFiltroV.Size = new System.Drawing.Size(1210, 509);
            this.GriewFiltroV.TabIndex = 1;
            this.GriewFiltroV.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // VistaVentasPorFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 577);
            this.Controls.Add(this.GriewFiltroV);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1027, 591);
            this.Name = "VistaVentasPorFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas por fecha";
            this.Load += new System.EventHandler(this.VistaVentasPorFecha_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GriewFiltroV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public Bunifu.UI.WinForms.BunifuDataGridView GriewFiltroV;
        public Bunifu.UI.WinForms.BunifuDatePicker dtpinicio;
        public Bunifu.UI.WinForms.BunifuDatePicker dtpfinal;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnBuscar;
        private System.Windows.Forms.Label Productos;
    }
}