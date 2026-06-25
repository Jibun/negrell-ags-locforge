namespace NegrellAGSLocForge.Forms
{
    partial class DecryptForm
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
            this.HexadecimalDataTextBox = new System.Windows.Forms.TextBox();
            this.HexValueLabel = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.DecryptedTextRichTextBox = new System.Windows.Forms.RichTextBox();
            this.DecryptedHexLabel = new System.Windows.Forms.Label();
            this.DecryptedHexRichTextBox = new System.Windows.Forms.RichTextBox();
            this.EncodingComboBox = new System.Windows.Forms.ComboBox();
            this.EncodingLabel = new System.Windows.Forms.Label();
            this.ResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.DecryptedTextLabel = new System.Windows.Forms.Label();
            this.ResultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // HexadecimalDataTextBox
            // 
            this.HexadecimalDataTextBox.Location = new System.Drawing.Point(28, 41);
            this.HexadecimalDataTextBox.Name = "HexadecimalDataTextBox";
            this.HexadecimalDataTextBox.Size = new System.Drawing.Size(499, 20);
            this.HexadecimalDataTextBox.TabIndex = 0;
            // 
            // HexValueLabel
            // 
            this.HexValueLabel.AutoSize = true;
            this.HexValueLabel.Location = new System.Drawing.Point(25, 25);
            this.HexValueLabel.Name = "HexValueLabel";
            this.HexValueLabel.Size = new System.Drawing.Size(58, 13);
            this.HexValueLabel.TabIndex = 1;
            this.HexValueLabel.Text = "Hex value:";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(452, 67);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(75, 23);
            this.DecryptButton.TabIndex = 2;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // DecryptedTextRichTextBox
            // 
            this.DecryptedTextRichTextBox.Location = new System.Drawing.Point(16, 140);
            this.DecryptedTextRichTextBox.Name = "DecryptedTextRichTextBox";
            this.DecryptedTextRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.DecryptedTextRichTextBox.Size = new System.Drawing.Size(500, 60);
            this.DecryptedTextRichTextBox.TabIndex = 3;
            this.DecryptedTextRichTextBox.Text = "";
            // 
            // DecryptedHexLabel
            // 
            this.DecryptedHexLabel.AutoSize = true;
            this.DecryptedHexLabel.Location = new System.Drawing.Point(13, 27);
            this.DecryptedHexLabel.Name = "DecryptedHexLabel";
            this.DecryptedHexLabel.Size = new System.Drawing.Size(81, 13);
            this.DecryptedHexLabel.TabIndex = 4;
            this.DecryptedHexLabel.Text = "Decrypted Hex:";
            // 
            // DecryptedHexRichTextBox
            // 
            this.DecryptedHexRichTextBox.Location = new System.Drawing.Point(16, 48);
            this.DecryptedHexRichTextBox.Name = "DecryptedHexRichTextBox";
            this.DecryptedHexRichTextBox.Size = new System.Drawing.Size(499, 60);
            this.DecryptedHexRichTextBox.TabIndex = 5;
            this.DecryptedHexRichTextBox.Text = "";
            // 
            // EncodingComboBox
            // 
            this.EncodingComboBox.FormattingEnabled = true;
            this.EncodingComboBox.Location = new System.Drawing.Point(274, 67);
            this.EncodingComboBox.Name = "EncodingComboBox";
            this.EncodingComboBox.Size = new System.Drawing.Size(172, 21);
            this.EncodingComboBox.TabIndex = 6;
            this.EncodingComboBox.SelectedIndexChanged += new System.EventHandler(this.EncodingComboBox_SelectedIndexChanged);
            // 
            // EncodingLabel
            // 
            this.EncodingLabel.AutoSize = true;
            this.EncodingLabel.Location = new System.Drawing.Point(213, 70);
            this.EncodingLabel.Name = "EncodingLabel";
            this.EncodingLabel.Size = new System.Drawing.Size(55, 13);
            this.EncodingLabel.TabIndex = 7;
            this.EncodingLabel.Text = "Encoding:";
            // 
            // ResultsGroupBox
            // 
            this.ResultsGroupBox.Controls.Add(this.DecryptedTextLabel);
            this.ResultsGroupBox.Controls.Add(this.DecryptedHexLabel);
            this.ResultsGroupBox.Controls.Add(this.DecryptedTextRichTextBox);
            this.ResultsGroupBox.Controls.Add(this.DecryptedHexRichTextBox);
            this.ResultsGroupBox.Location = new System.Drawing.Point(12, 105);
            this.ResultsGroupBox.Name = "ResultsGroupBox";
            this.ResultsGroupBox.Size = new System.Drawing.Size(530, 225);
            this.ResultsGroupBox.TabIndex = 8;
            this.ResultsGroupBox.TabStop = false;
            this.ResultsGroupBox.Text = "Results";
            // 
            // DecryptedTextLabel
            // 
            this.DecryptedTextLabel.AutoSize = true;
            this.DecryptedTextLabel.Location = new System.Drawing.Point(13, 124);
            this.DecryptedTextLabel.Name = "DecryptedTextLabel";
            this.DecryptedTextLabel.Size = new System.Drawing.Size(83, 13);
            this.DecryptedTextLabel.TabIndex = 6;
            this.DecryptedTextLabel.Text = "Decrypted Text:";
            // 
            // DecryptForm
            // 
            this.ClientSize = new System.Drawing.Size(554, 350);
            this.Controls.Add(this.ResultsGroupBox);
            this.Controls.Add(this.EncodingLabel);
            this.Controls.Add(this.EncodingComboBox);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.HexValueLabel);
            this.Controls.Add(this.HexadecimalDataTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DecryptForm";
            this.Text = "Decrypt Segment";
            this.ResultsGroupBox.ResumeLayout(false);
            this.ResultsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HexadecimalDataTextBox;
        private System.Windows.Forms.Label HexValueLabel;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.RichTextBox DecryptedTextRichTextBox;
        private System.Windows.Forms.Label DecryptedHexLabel;
        private System.Windows.Forms.RichTextBox DecryptedHexRichTextBox;
        private System.Windows.Forms.ComboBox EncodingComboBox;
        private System.Windows.Forms.Label EncodingLabel;
        private System.Windows.Forms.GroupBox ResultsGroupBox;
        private System.Windows.Forms.Label DecryptedTextLabel;
    }
}
