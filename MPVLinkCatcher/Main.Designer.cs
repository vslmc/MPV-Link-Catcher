namespace MPVLinkCatcher
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.URLTextbox = new System.Windows.Forms.TextBox();
            this.StartPlayButton = new System.Windows.Forms.Button();
            this.BootCheckbox = new System.Windows.Forms.CheckBox();
            this.SimpleLabel = new System.Windows.Forms.Label();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.HideInTrayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // URLTextbox
            // 
            this.URLTextbox.Location = new System.Drawing.Point(12, 29);
            this.URLTextbox.Name = "URLTextbox";
            this.URLTextbox.Size = new System.Drawing.Size(427, 22);
            this.URLTextbox.TabIndex = 0;
            this.URLTextbox.TabStop = false;
            // 
            // StartPlayButton
            // 
            this.StartPlayButton.Location = new System.Drawing.Point(359, 90);
            this.StartPlayButton.Name = "StartPlayButton";
            this.StartPlayButton.Size = new System.Drawing.Size(80, 32);
            this.StartPlayButton.TabIndex = 8;
            this.StartPlayButton.TabStop = false;
            this.StartPlayButton.Text = "OK";
            this.StartPlayButton.UseVisualStyleBackColor = true;
            this.StartPlayButton.Click += new System.EventHandler(this.OKButton);
            // 
            // BootCheckbox
            // 
            this.BootCheckbox.AutoSize = true;
            this.BootCheckbox.Location = new System.Drawing.Point(12, 97);
            this.BootCheckbox.Name = "BootCheckbox";
            this.BootCheckbox.Size = new System.Drawing.Size(148, 21);
            this.BootCheckbox.TabIndex = 2;
            this.BootCheckbox.TabStop = false;
            this.BootCheckbox.Text = "Start with Windows";
            this.BootCheckbox.UseVisualStyleBackColor = true;
            this.BootCheckbox.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // SimpleLabel
            // 
            this.SimpleLabel.AllowDrop = true;
            this.SimpleLabel.AutoSize = true;
            this.SimpleLabel.Location = new System.Drawing.Point(9, 9);
            this.SimpleLabel.Name = "SimpleLabel";
            this.SimpleLabel.Size = new System.Drawing.Size(38, 17);
            this.SimpleLabel.TabIndex = 3;
            this.SimpleLabel.Text = "Link:";
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipText = "MPV Link Catcher";
            this.TrayIcon.BalloonTipTitle = "MPV Link Catcher";
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "MPV Link Catcher";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIconClick);
            // 
            // HideInTrayButton
            // 
            this.HideInTrayButton.Location = new System.Drawing.Point(273, 90);
            this.HideInTrayButton.Name = "HideInTrayButton";
            this.HideInTrayButton.Size = new System.Drawing.Size(80, 32);
            this.HideInTrayButton.TabIndex = 4;
            this.HideInTrayButton.TabStop = false;
            this.HideInTrayButton.Text = "Hide";
            this.HideInTrayButton.UseVisualStyleBackColor = true;
            this.HideInTrayButton.Click += new System.EventHandler(this.HideButton);
            // 
            // Main
            // 
            this.AcceptButton = this.StartPlayButton;
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(451, 134);
            this.Controls.Add(this.HideInTrayButton);
            this.Controls.Add(this.SimpleLabel);
            this.Controls.Add(this.BootCheckbox);
            this.Controls.Add(this.StartPlayButton);
            this.Controls.Add(this.URLTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPV Link Catcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLTextbox;
        private System.Windows.Forms.Button StartPlayButton;
        private System.Windows.Forms.CheckBox BootCheckbox;
        private System.Windows.Forms.Label SimpleLabel;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.Button HideInTrayButton;
    }
}

