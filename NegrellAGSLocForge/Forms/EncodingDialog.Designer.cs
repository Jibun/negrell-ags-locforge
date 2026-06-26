namespace NegrellAGSLocForge.Forms
{
    partial class EncodingDialog
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
            this.EncodingComboBox = new System.Windows.Forms.ComboBox();
            this.EncodingLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.EncodingInfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // EncodingComboBox
            // 
            this.EncodingComboBox.FormattingEnabled = true;
            this.EncodingComboBox.Location = new System.Drawing.Point(131, 223);
            this.EncodingComboBox.Name = "EncodingComboBox";
            this.EncodingComboBox.Size = new System.Drawing.Size(217, 21);
            this.EncodingComboBox.TabIndex = 0;
            // 
            // EncodingLabel
            // 
            this.EncodingLabel.AutoSize = true;
            this.EncodingLabel.Location = new System.Drawing.Point(70, 226);
            this.EncodingLabel.Name = "EncodingLabel";
            this.EncodingLabel.Size = new System.Drawing.Size(55, 13);
            this.EncodingLabel.TabIndex = 1;
            this.EncodingLabel.Text = "Encoding:";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(273, 268);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.Location = new System.Drawing.Point(73, 268);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(75, 23);
            this.CancelActionButton.TabIndex = 3;
            this.CancelActionButton.Text = "Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            this.CancelActionButton.Click += new System.EventHandler(this.CancelActionButton_Click);
            // 
            // EncodingInfoRichTextBox
            // 
            this.EncodingInfoRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EncodingInfoRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.EncodingInfoRichTextBox.Name = "EncodingInfoRichTextBox";
            this.EncodingInfoRichTextBox.ReadOnly = true;
            this.EncodingInfoRichTextBox.Size = new System.Drawing.Size(401, 205);
            this.EncodingInfoRichTextBox.TabIndex = 7;
            this.EncodingInfoRichTextBox.TabStop = false;
            this.EncodingInfoRichTextBox.Text = "";
            // 
            // EncodingDialog
            // 
            this.ClientSize = new System.Drawing.Size(425, 308);
            this.Controls.Add(this.EncodingInfoRichTextBox);
            this.Controls.Add(this.CancelActionButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.EncodingLabel);
            this.Controls.Add(this.EncodingComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EncodingDialog";
            this.Text = "Encoding Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EncodingComboBox;
        private System.Windows.Forms.Label EncodingLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelActionButton;
        private System.Windows.Forms.RichTextBox EncodingInfoRichTextBox;
    }
}
