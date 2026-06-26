namespace NegrellAGSLocForge.Forms {
    partial class SearchTextForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SearchTextTextBox = new System.Windows.Forms.TextBox();
            this.SearchTextLabel = new System.Windows.Forms.Label();
            this.SearchNextButton = new System.Windows.Forms.Button();
            this.SearchPreviewButton = new System.Windows.Forms.Button();
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.WrapAroundCheckBox = new System.Windows.Forms.CheckBox();
            this.CaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.OptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchTextTextBox
            // 
            this.SearchTextTextBox.Location = new System.Drawing.Point(81, 21);
            this.SearchTextTextBox.Name = "SearchTextTextBox";
            this.SearchTextTextBox.Size = new System.Drawing.Size(323, 20);
            this.SearchTextTextBox.TabIndex = 0;
            // 
            // SearchTextLabel
            // 
            this.SearchTextLabel.AutoSize = true;
            this.SearchTextLabel.Location = new System.Drawing.Point(17, 24);
            this.SearchTextLabel.Name = "SearchTextLabel";
            this.SearchTextLabel.Size = new System.Drawing.Size(64, 13);
            this.SearchTextLabel.TabIndex = 1;
            this.SearchTextLabel.Text = "Search text:";
            // 
            // SearchNextButton
            // 
            this.SearchNextButton.Location = new System.Drawing.Point(307, 50);
            this.SearchNextButton.Name = "SearchNextButton";
            this.SearchNextButton.Size = new System.Drawing.Size(97, 22);
            this.SearchNextButton.TabIndex = 2;
            this.SearchNextButton.Text = "Search next";
            this.SearchNextButton.UseVisualStyleBackColor = true;
            this.SearchNextButton.Click += new System.EventHandler(this.SearchNextButton_Click);
            // 
            // SearchPreviewButton
            // 
            this.SearchPreviewButton.Location = new System.Drawing.Point(204, 50);
            this.SearchPreviewButton.Name = "SearchPreviewButton";
            this.SearchPreviewButton.Size = new System.Drawing.Size(97, 22);
            this.SearchPreviewButton.TabIndex = 3;
            this.SearchPreviewButton.Text = "Search preview";
            this.SearchPreviewButton.UseVisualStyleBackColor = true;
            this.SearchPreviewButton.Click += new System.EventHandler(this.SearchPreviewButton_Click);
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Controls.Add(this.WrapAroundCheckBox);
            this.OptionsGroupBox.Controls.Add(this.CaseSensitiveCheckBox);
            this.OptionsGroupBox.Location = new System.Drawing.Point(20, 53);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(142, 78);
            this.OptionsGroupBox.TabIndex = 4;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            // 
            // WrapAroundCheckBox
            // 
            this.WrapAroundCheckBox.AutoSize = true;
            this.WrapAroundCheckBox.Enabled = false;
            this.WrapAroundCheckBox.Location = new System.Drawing.Point(22, 46);
            this.WrapAroundCheckBox.Name = "WrapAroundCheckBox";
            this.WrapAroundCheckBox.Size = new System.Drawing.Size(88, 17);
            this.WrapAroundCheckBox.TabIndex = 0;
            this.WrapAroundCheckBox.Text = "Wrap around";
            this.WrapAroundCheckBox.UseVisualStyleBackColor = true;
            // 
            // CaseSensitiveCheckBox
            // 
            this.CaseSensitiveCheckBox.AutoSize = true;
            this.CaseSensitiveCheckBox.Checked = true;
            this.CaseSensitiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CaseSensitiveCheckBox.Location = new System.Drawing.Point(22, 23);
            this.CaseSensitiveCheckBox.Name = "CaseSensitiveCheckBox";
            this.CaseSensitiveCheckBox.Size = new System.Drawing.Size(94, 17);
            this.CaseSensitiveCheckBox.TabIndex = 0;
            this.CaseSensitiveCheckBox.Text = "Case sensitive";
            this.CaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchTextForm
            // 
            this.AcceptButton = this.SearchNextButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 142);
            this.Controls.Add(this.OptionsGroupBox);
            this.Controls.Add(this.SearchPreviewButton);
            this.Controls.Add(this.SearchNextButton);
            this.Controls.Add(this.SearchTextLabel);
            this.Controls.Add(this.SearchTextTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchTextForm";
            this.Text = "Search text";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchTextForm_FormClosed);
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchTextTextBox;
        private System.Windows.Forms.Label SearchTextLabel;
        private System.Windows.Forms.Button SearchNextButton;
        private System.Windows.Forms.Button SearchPreviewButton;
        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.CheckBox WrapAroundCheckBox;
        private System.Windows.Forms.CheckBox CaseSensitiveCheckBox;
    }
}