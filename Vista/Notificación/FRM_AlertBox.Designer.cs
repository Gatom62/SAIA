namespace AgroServicios.Vista.Notificación
{
    partial class AlertExito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertExito));
            this.TimerAnimation = new System.Windows.Forms.Timer(this.components);
            this.LinAlertBox = new System.Windows.Forms.Panel();
            this.LblTextAlertBox = new System.Windows.Forms.Label();
            this.LblTitleAlertBox = new System.Windows.Forms.Label();
            this.IconAlertBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconAlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerAnimation
            // 
            this.TimerAnimation.Interval = 1;
            this.TimerAnimation.Tick += new System.EventHandler(this.TimerAnimation_Tick);
            // 
            // LinAlertBox
            // 
            this.LinAlertBox.BackColor = System.Drawing.Color.Black;
            this.LinAlertBox.Location = new System.Drawing.Point(0, 76);
            this.LinAlertBox.Margin = new System.Windows.Forms.Padding(2);
            this.LinAlertBox.Name = "LinAlertBox";
            this.LinAlertBox.Size = new System.Drawing.Size(4, 5);
            this.LinAlertBox.TabIndex = 10;
            // 
            // LblTextAlertBox
            // 
            this.LblTextAlertBox.AutoSize = true;
            this.LblTextAlertBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTextAlertBox.Location = new System.Drawing.Point(68, 43);
            this.LblTextAlertBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTextAlertBox.Name = "LblTextAlertBox";
            this.LblTextAlertBox.Size = new System.Drawing.Size(47, 21);
            this.LblTextAlertBox.TabIndex = 9;
            this.LblTextAlertBox.Text = "Exito";
            // 
            // LblTitleAlertBox
            // 
            this.LblTitleAlertBox.AutoSize = true;
            this.LblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitleAlertBox.Location = new System.Drawing.Point(67, 14);
            this.LblTitleAlertBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitleAlertBox.Name = "LblTitleAlertBox";
            this.LblTitleAlertBox.Size = new System.Drawing.Size(61, 26);
            this.LblTitleAlertBox.TabIndex = 8;
            this.LblTitleAlertBox.Text = "Exito";
            // 
            // IconAlertBox
            // 
            this.IconAlertBox.Location = new System.Drawing.Point(16, 17);
            this.IconAlertBox.Margin = new System.Windows.Forms.Padding(2);
            this.IconAlertBox.Name = "IconAlertBox";
            this.IconAlertBox.Size = new System.Drawing.Size(38, 41);
            this.IconAlertBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconAlertBox.TabIndex = 7;
            this.IconAlertBox.TabStop = false;
            // 
            // AlertExito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 81);
            this.Controls.Add(this.IconAlertBox);
            this.Controls.Add(this.LinAlertBox);
            this.Controls.Add(this.LblTextAlertBox);
            this.Controls.Add(this.LblTitleAlertBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AlertExito";
            this.Load += new System.EventHandler(this.AlertExito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconAlertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TimerAnimation;
        private System.Windows.Forms.Panel LinAlertBox;
        private System.Windows.Forms.Label LblTextAlertBox;
        private System.Windows.Forms.Label LblTitleAlertBox;
        private System.Windows.Forms.PictureBox IconAlertBox;
    }
}