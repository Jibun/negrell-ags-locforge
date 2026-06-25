namespace NegrellAGSLocForge.Forms
{
    partial class StatsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsForm));
            this.TranslatedLabel = new System.Windows.Forms.Label();
            this.NotTranslatedLabel = new System.Windows.Forms.Label();
            this.CountEntriesLabel = new System.Windows.Forms.Label();
            this.TranslatedCountLabel = new System.Windows.Forms.Label();
            this.NotTranslatedCountLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // TranslatedLabel
            // 
            resources.ApplyResources(this.TranslatedLabel, "TranslatedLabel");
            this.TranslatedLabel.Name = "TranslatedLabel";
            // 
            // NotTranslatedLabel
            // 
            resources.ApplyResources(this.NotTranslatedLabel, "NotTranslatedLabel");
            this.NotTranslatedLabel.Name = "NotTranslatedLabel";
            // 
            // CountEntriesLabel
            // 
            resources.ApplyResources(this.CountEntriesLabel, "CountEntriesLabel");
            this.CountEntriesLabel.Name = "CountEntriesLabel";
            // 
            // TranslatedCountLabel
            // 
            resources.ApplyResources(this.TranslatedCountLabel, "TranslatedCountLabel");
            this.TranslatedCountLabel.Name = "TranslatedCountLabel";
            // 
            // NotTranslatedCountLabel
            // 
            resources.ApplyResources(this.NotTranslatedCountLabel, "NotTranslatedCountLabel");
            this.NotTranslatedCountLabel.Name = "NotTranslatedCountLabel";
            // 
            // ProgressBar
            // 
            resources.ApplyResources(this.ProgressBar, "ProgressBar");
            this.ProgressBar.Name = "ProgressBar";
            // 
            // StatsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.NotTranslatedCountLabel);
            this.Controls.Add(this.TranslatedCountLabel);
            this.Controls.Add(this.CountEntriesLabel);
            this.Controls.Add(this.NotTranslatedLabel);
            this.Controls.Add(this.TranslatedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatsForm";
            this.ShowIcon = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TranslatedLabel;
        private System.Windows.Forms.Label NotTranslatedLabel;
        private System.Windows.Forms.Label CountEntriesLabel;
        private System.Windows.Forms.Label TranslatedCountLabel;
        private System.Windows.Forms.Label NotTranslatedCountLabel;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}