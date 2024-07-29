namespace AgroServicios.Vista.Login
{
    partial class Bienvenida
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblbienvenido = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.BarradeProgeso = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.bunifuColorTransition1 = new Bunifu.UI.WinForms.BunifuColorTransition(this.components);
            this.bunifuColorTransition2 = new Bunifu.UI.WinForms.BunifuColorTransition(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(197)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.bunifuPictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1410, 116);
            this.panel1.TabIndex = 0;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 0;
            this.bunifuPictureBox1.Image = global::AgroServicios.Properties.Resources.Imagen_de_WhatsApp_2024_07_08_a_las_17_27_06_487df51c_removebg_preview;
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(71, 22);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(70, 70);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 3;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(147, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 93);
            this.label2.TabIndex = 2;
            this.label2.Text = "SAIA";
            // 
            // lblbienvenido
            // 
            this.lblbienvenido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblbienvenido.AutoSize = true;
            this.lblbienvenido.Font = new System.Drawing.Font("Century Gothic", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbienvenido.ForeColor = System.Drawing.Color.White;
            this.lblbienvenido.Location = new System.Drawing.Point(523, 149);
            this.lblbienvenido.Name = "lblbienvenido";
            this.lblbienvenido.Size = new System.Drawing.Size(590, 117);
            this.lblbienvenido.TabIndex = 0;
            this.lblbienvenido.Text = "Bienvenido";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(218)))), ((int)(((byte)(50)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 547);
            this.panel2.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 30;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // BarradeProgeso
            // 
            this.BarradeProgeso.Animated = true;
            this.BarradeProgeso.AnimationInterval = 1;
            this.BarradeProgeso.AnimationSpeed = 1;
            this.BarradeProgeso.BackColor = System.Drawing.Color.Transparent;
            this.BarradeProgeso.CircleMargin = 10;
            this.BarradeProgeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.BarradeProgeso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BarradeProgeso.IsPercentage = true;
            this.BarradeProgeso.LineProgressThickness = 10;
            this.BarradeProgeso.LineThickness = 10;
            this.BarradeProgeso.Location = new System.Drawing.Point(721, 323);
            this.BarradeProgeso.Name = "BarradeProgeso";
            this.BarradeProgeso.ProgressAnimationSpeed = 200;
            this.BarradeProgeso.ProgressBackColor = System.Drawing.Color.White;
            this.BarradeProgeso.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19)))));
            this.BarradeProgeso.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19)))));
            this.BarradeProgeso.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.BarradeProgeso.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Solid;
            this.BarradeProgeso.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.BarradeProgeso.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BarradeProgeso.Size = new System.Drawing.Size(200, 200);
            this.BarradeProgeso.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.BarradeProgeso.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.BarradeProgeso.SubScriptText = "";
            this.BarradeProgeso.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.BarradeProgeso.SuperScriptMargin = new System.Windows.Forms.Padding(5, 50, 0, 0);
            this.BarradeProgeso.SuperScriptText = "%";
            this.BarradeProgeso.TabIndex = 16;
            this.BarradeProgeso.Text = "30";
            this.BarradeProgeso.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.BarradeProgeso.Value = 30;
            this.BarradeProgeso.ValueByTransition = 30;
            this.BarradeProgeso.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            // 
            // bunifuColorTransition1
            // 
            this.bunifuColorTransition1.AutoTransition = true;
            this.bunifuColorTransition1.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(231)))), ((int)(((byte)(64))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19)))))};
            this.bunifuColorTransition1.EndColor = System.Drawing.Color.White;
            this.bunifuColorTransition1.Interval = 10;
            this.bunifuColorTransition1.ProgessValue = 0;
            this.bunifuColorTransition1.StartColor = System.Drawing.Color.White;
            this.bunifuColorTransition1.TransitionControl = this.panel1;
            // 
            // bunifuColorTransition2
            // 
            this.bunifuColorTransition2.AutoTransition = true;
            this.bunifuColorTransition2.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(188)))), ((int)(((byte)(19))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(231)))), ((int)(((byte)(64)))))};
            this.bunifuColorTransition2.EndColor = System.Drawing.Color.White;
            this.bunifuColorTransition2.Interval = 10;
            this.bunifuColorTransition2.ProgessValue = 0;
            this.bunifuColorTransition2.StartColor = System.Drawing.Color.White;
            this.bunifuColorTransition2.TransitionControl = this.panel2;
            // 
            // Bienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1410, 663);
            this.Controls.Add(this.BarradeProgeso);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblbienvenido);
            this.Controls.Add(this.panel1);
            this.Name = "Bienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            this.Load += new System.EventHandler(this.Bienvenida_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Bunifu.UI.WinForms.BunifuCircleProgress BarradeProgeso;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private Bunifu.UI.WinForms.BunifuColorTransition bunifuColorTransition1;
        private Bunifu.UI.WinForms.BunifuColorTransition bunifuColorTransition2;
        public System.Windows.Forms.Label lblbienvenido;
    }
}