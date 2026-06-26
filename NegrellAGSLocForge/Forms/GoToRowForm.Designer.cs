namespace NegrellAGSLocForge.Forms {
    partial class GoToRowForm {
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
            this.RowNumberLabel = new System.Windows.Forms.Label();
            this.GoToRowTextBox = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RowNumberLabel
            // 
            this.RowNumberLabel.AutoSize = true;
            this.RowNumberLabel.Location = new System.Drawing.Point(20, 26);
            this.RowNumberLabel.Name = "RowNumberLabel";
            this.RowNumberLabel.Size = new System.Drawing.Size(70, 13);
            this.RowNumberLabel.TabIndex = 0;
            this.RowNumberLabel.Text = "Row number:";
            // 
            // GoToRowTextBox
            // 
            this.GoToRowTextBox.Location = new System.Drawing.Point(96, 23);
            this.GoToRowTextBox.Name = "GoToRowTextBox";
            this.GoToRowTextBox.Size = new System.Drawing.Size(128, 20);
            this.GoToRowTextBox.TabIndex = 1;
            this.GoToRowTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GoToRowTextBox_KeyPress);
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(230, 20);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(39, 24);
            this.GoButton.TabIndex = 2;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // GoToRowForm
            // 
            this.AcceptButton = this.GoButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 68);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.GoToRowTextBox);
            this.Controls.Add(this.RowNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GoToRowForm";
            this.Text = "Go to row";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RowNumberLabel;
        private System.Windows.Forms.TextBox GoToRowTextBox;
        private System.Windows.Forms.Button GoButton;
    }
}