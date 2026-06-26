namespace NegrellAGSLocForge.Forms
{
    partial class AboutForm
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
            this.AppTitleLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AppTitleLabel
            // 
            this.AppTitleLabel.AutoSize = true;
            this.AppTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.AppTitleLabel.Location = new System.Drawing.Point(25, 18);
            this.AppTitleLabel.Name = "AppTitleLabel";
            this.AppTitleLabel.Size = new System.Drawing.Size(199, 25);
            this.AppTitleLabel.TabIndex = 0;
            this.AppTitleLabel.Text = "Negrell AGS LocForge";
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CloseButton.Location = new System.Drawing.Point(128, 210);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(77, 29);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(27, 43);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(82, 17);
            this.VersionLabel.TabIndex = 3;
            this.VersionLabel.Text = "Version 2.0.0";
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutLabel.Location = new System.Drawing.Point(27, 86);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(252, 102);
            this.AboutLabel.TabIndex = 6;
            this.AboutLabel.Text = "Based on AGS Translation Editor (2015)\r\nOriginal author: Bernd Keilmann (Taktloss" +
    ")\r\n\r\nCurrent development: Ivan L. Negrell\r\n\r\nLicensed under GPL v3 or later";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 251);
            this.Controls.Add(this.AboutLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AppTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About Negrell AGS LocForge";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AppTitleLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AboutLabel;
    }
}