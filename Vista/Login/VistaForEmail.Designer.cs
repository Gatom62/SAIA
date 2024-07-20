namespace AgroServicios.Vista.Login
{
    partial class VistaForEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaForEmail));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.txtUser = new Bunifu.UI.WinForms.BunifuTextBox();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.btnEnviar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.lblResult = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.AcceptsReturn = false;
            this.txtUser.AcceptsTab = false;
            this.txtUser.AnimationSpeed = 200;
            this.txtUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUser.AutoSizeHeight = true;
            this.txtUser.BackColor = System.Drawing.Color.Transparent;
            this.txtUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtUser.BackgroundImage")));
            this.txtUser.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtUser.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtUser.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtUser.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtUser.BorderRadius = 33;
            this.txtUser.BorderThickness = 1;
            this.txtUser.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtUser.DefaultText = "";
            this.txtUser.FillColor = System.Drawing.Color.White;
            this.txtUser.HideSelection = true;
            this.txtUser.IconLeft = null;
            this.txtUser.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.IconPadding = 10;
            this.txtUser.IconRight = null;
            this.txtUser.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Lines = new string[0];
            this.txtUser.Location = new System.Drawing.Point(290, 222);
            this.txtUser.MaxLength = 32767;
            this.txtUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtUser.Modified = false;
            this.txtUser.Multiline = false;
            this.txtUser.Name = "txtUser";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUser.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtUser.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUser.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUser.OnIdleState = stateProperties4;
            this.txtUser.Padding = new System.Windows.Forms.Padding(3);
            this.txtUser.PasswordChar = '\0';
            this.txtUser.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtUser.PlaceholderText = "Ingrese el usuario";
            this.txtUser.ReadOnly = false;
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUser.SelectedText = "";
            this.txtUser.SelectionLength = 0;
            this.txtUser.SelectionStart = 0;
            this.txtUser.ShortcutsEnabled = true;
            this.txtUser.Size = new System.Drawing.Size(305, 43);
            this.txtUser.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtUser.TabIndex = 0;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUser.TextMarginBottom = 0;
            this.txtUser.TextMarginLeft = 3;
            this.txtUser.TextMarginTop = 1;
            this.txtUser.TextPlaceholder = "Ingrese el usuario";
            this.txtUser.UseSystemPasswordChar = false;
            this.txtUser.WordWrap = true;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 72;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(375, 51);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(145, 145);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 1;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // btnEnviar
            // 
            this.btnEnviar.AllowAnimations = true;
            this.btnEnviar.AllowMouseEffects = true;
            this.btnEnviar.AllowToggling = false;
            this.btnEnviar.AnimationSpeed = 200;
            this.btnEnviar.AutoGenerateColors = false;
            this.btnEnviar.AutoRoundBorders = false;
            this.btnEnviar.AutoSizeLeftIcon = true;
            this.btnEnviar.AutoSizeRightIcon = true;
            this.btnEnviar.BackColor = System.Drawing.Color.Transparent;
            this.btnEnviar.BackColor1 = System.Drawing.Color.LawnGreen;
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEnviar.ButtonText = "Enviar Correo";
            this.btnEnviar.ButtonTextMarginLeft = 0;
            this.btnEnviar.ColorContrastOnClick = 45;
            this.btnEnviar.ColorContrastOnHover = 45;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnEnviar.CustomizableEdges = borderEdges1;
            this.btnEnviar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEnviar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEnviar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEnviar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEnviar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnEnviar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEnviar.ForeColor = System.Drawing.Color.Black;
            this.btnEnviar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnEnviar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnEnviar.IconMarginLeft = 11;
            this.btnEnviar.IconPadding = 10;
            this.btnEnviar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnEnviar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnEnviar.IconSize = 25;
            this.btnEnviar.IdleBorderColor = System.Drawing.Color.LawnGreen;
            this.btnEnviar.IdleBorderRadius = 33;
            this.btnEnviar.IdleBorderThickness = 1;
            this.btnEnviar.IdleFillColor = System.Drawing.Color.LawnGreen;
            this.btnEnviar.IdleIconLeftImage = null;
            this.btnEnviar.IdleIconRightImage = null;
            this.btnEnviar.IndicateFocus = false;
            this.btnEnviar.Location = new System.Drawing.Point(276, 286);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEnviar.OnDisabledState.BorderRadius = 33;
            this.btnEnviar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEnviar.OnDisabledState.BorderThickness = 1;
            this.btnEnviar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEnviar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEnviar.OnDisabledState.IconLeftImage = null;
            this.btnEnviar.OnDisabledState.IconRightImage = null;
            this.btnEnviar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnEnviar.onHoverState.BorderRadius = 33;
            this.btnEnviar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEnviar.onHoverState.BorderThickness = 1;
            this.btnEnviar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnEnviar.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.onHoverState.IconLeftImage = null;
            this.btnEnviar.onHoverState.IconRightImage = null;
            this.btnEnviar.OnIdleState.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnEnviar.OnIdleState.BorderRadius = 33;
            this.btnEnviar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEnviar.OnIdleState.BorderThickness = 1;
            this.btnEnviar.OnIdleState.FillColor = System.Drawing.Color.LawnGreen;
            this.btnEnviar.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnEnviar.OnIdleState.IconLeftImage = null;
            this.btnEnviar.OnIdleState.IconRightImage = null;
            this.btnEnviar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnEnviar.OnPressedState.BorderRadius = 33;
            this.btnEnviar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEnviar.OnPressedState.BorderThickness = 1;
            this.btnEnviar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnEnviar.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.OnPressedState.IconLeftImage = null;
            this.btnEnviar.OnPressedState.IconRightImage = null;
            this.btnEnviar.Size = new System.Drawing.Size(329, 39);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEnviar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEnviar.TextMarginLeft = 0;
            this.btnEnviar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnEnviar.UseDefaultRadiusAndThickness = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblResult
            // 
            this.lblResult.AllowParentOverrides = false;
            this.lblResult.AutoEllipsis = false;
            this.lblResult.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResult.Location = new System.Drawing.Point(94, 378);
            this.lblResult.Name = "lblResult";
            this.lblResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblResult.Size = new System.Drawing.Size(66, 20);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Resultado";
            this.lblResult.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblResult.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // VistaForEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(925, 550);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.bunifuPictureBox1);
            this.Controls.Add(this.txtUser);
            this.Name = "VistaForEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VistaForEmail";
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        public Bunifu.UI.WinForms.BunifuTextBox txtUser;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnEnviar;
        public Bunifu.UI.WinForms.BunifuLabel lblResult;
    }
}