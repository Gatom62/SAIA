namespace AgroServicios.Vista.Notificación
{
    partial class MessagePersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagePersonal));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LblTitleAlertBox = new System.Windows.Forms.Label();
            this.LblTextAlertBox = new System.Windows.Forms.Label();
            this.TimeLapse = new System.Windows.Forms.Timer(this.components);
            this.IconAlertBox = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.ShadowColor = new Bunifu.UI.WinForms.BunifuShadowPanel();
            this.LinBotton = new Bunifu.UI.WinForms.BunifuPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconAlertBox)).BeginInit();
            this.ShadowColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LblTitleAlertBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblTextAlertBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(111, 54);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 92);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // LblTitleAlertBox
            // 
            this.LblTitleAlertBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTitleAlertBox.AutoSize = true;
            this.LblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitleAlertBox.Location = new System.Drawing.Point(133, 10);
            this.LblTitleAlertBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitleAlertBox.Name = "LblTitleAlertBox";
            this.LblTitleAlertBox.Size = new System.Drawing.Size(61, 26);
            this.LblTitleAlertBox.TabIndex = 11;
            this.LblTitleAlertBox.Text = "Exito";
            // 
            // LblTextAlertBox
            // 
            this.LblTextAlertBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTextAlertBox.AutoSize = true;
            this.LblTextAlertBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTextAlertBox.Location = new System.Drawing.Point(140, 58);
            this.LblTextAlertBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTextAlertBox.Name = "LblTextAlertBox";
            this.LblTextAlertBox.Size = new System.Drawing.Size(47, 21);
            this.LblTextAlertBox.TabIndex = 12;
            this.LblTextAlertBox.Text = "Exito";
            // 
            // TimeLapse
            // 
            this.TimeLapse.Interval = 10;
            this.TimeLapse.Tick += new System.EventHandler(this.TimeLapse_Tick);
            // 
            // IconAlertBox
            // 
            this.IconAlertBox.AllowFocused = false;
            this.IconAlertBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IconAlertBox.AutoSizeHeight = true;
            this.IconAlertBox.BorderRadius = 35;
            this.IconAlertBox.Image = ((System.Drawing.Image)(resources.GetObject("IconAlertBox.Image")));
            this.IconAlertBox.IsCircle = true;
            this.IconAlertBox.Location = new System.Drawing.Point(36, 64);
            this.IconAlertBox.Name = "IconAlertBox";
            this.IconAlertBox.Size = new System.Drawing.Size(70, 70);
            this.IconAlertBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconAlertBox.TabIndex = 15;
            this.IconAlertBox.TabStop = false;
            this.IconAlertBox.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // ShadowColor
            // 
            this.ShadowColor.BackColor = System.Drawing.Color.Transparent;
            this.ShadowColor.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.ShadowColor.BorderRadius = 20;
            this.ShadowColor.BorderThickness = 1;
            this.ShadowColor.Controls.Add(this.IconAlertBox);
            this.ShadowColor.Controls.Add(this.tableLayoutPanel1);
            this.ShadowColor.Controls.Add(this.LinBotton);
            this.ShadowColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShadowColor.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
            this.ShadowColor.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
            this.ShadowColor.Location = new System.Drawing.Point(0, 0);
            this.ShadowColor.Margin = new System.Windows.Forms.Padding(2);
            this.ShadowColor.Name = "ShadowColor";
            this.ShadowColor.PanelColor = System.Drawing.Color.White;
            this.ShadowColor.PanelColor2 = System.Drawing.Color.White;
            this.ShadowColor.ShadowColor = System.Drawing.Color.DarkGray;
            this.ShadowColor.ShadowDept = 2;
            this.ShadowColor.ShadowDepth = 8;
            this.ShadowColor.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
            this.ShadowColor.ShadowTopLeftVisible = false;
            this.ShadowColor.Size = new System.Drawing.Size(472, 224);
            this.ShadowColor.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
            this.ShadowColor.TabIndex = 0;
            this.ShadowColor.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ShadowColor_ControlAdded);
            // 
            // LinBotton
            // 
            this.LinBotton.BackgroundColor = System.Drawing.Color.Black;
            this.LinBotton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LinBotton.BackgroundImage")));
            this.LinBotton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LinBotton.BorderColor = System.Drawing.Color.Transparent;
            this.LinBotton.BorderRadius = 5;
            this.LinBotton.BorderThickness = 1;
            this.LinBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LinBotton.Location = new System.Drawing.Point(0, 214);
            this.LinBotton.Margin = new System.Windows.Forms.Padding(2);
            this.LinBotton.Name = "LinBotton";
            this.LinBotton.ShowBorders = true;
            this.LinBotton.Size = new System.Drawing.Size(472, 10);
            this.LinBotton.TabIndex = 13;
            this.LinBotton.Visible = false;
            // 
            // MessagePersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(472, 224);
            this.Controls.Add(this.ShadowColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MessagePersonal";
            this.Load += new System.EventHandler(this.MessagePersonal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconAlertBox)).EndInit();
            this.ShadowColor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblTextAlertBox;
        private System.Windows.Forms.Label LblTitleAlertBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer TimeLapse;
        private Bunifu.UI.WinForms.BunifuPictureBox IconAlertBox;
        private Bunifu.UI.WinForms.BunifuShadowPanel ShadowColor;
        private Bunifu.UI.WinForms.BunifuPanel LinBotton;
    }
}