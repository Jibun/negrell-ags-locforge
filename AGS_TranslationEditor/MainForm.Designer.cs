namespace NegrellAGSLocForge
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoToRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetGameInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateTraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdvancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DecryptSegmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.EntriesCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TranslationGrid = new System.Windows.Forms.DataGridView();
            this.colSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTranslation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.StatsStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EncodingStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.EncodingStripCombo = new System.Windows.Forms.ToolStripComboBox();
            this.SourceTextBox = new System.Windows.Forms.RichTextBox();
            this.SourceTextLabel = new System.Windows.Forms.Label();
            this.TranslationTextLabel = new System.Windows.Forms.Label();
            this.TranslationTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TranslationGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.SearchToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.toolStripMenuItem3,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.CloseToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            resources.ApplyResources(this.OpenToolStripMenuItem, "OpenToolStripMenuItem");
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            resources.ApplyResources(this.SaveToolStripMenuItem, "SaveToolStripMenuItem");
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            resources.ApplyResources(this.SaveAsToolStripMenuItem, "SaveAsToolStripMenuItem");
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            resources.ApplyResources(this.CloseToolStripMenuItem, "CloseToolStripMenuItem");
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.RemoveToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            resources.ApplyResources(this.EditToolStripMenuItem, "EditToolStripMenuItem");
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            resources.ApplyResources(this.AddToolStripMenuItem, "AddToolStripMenuItem");
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            resources.ApplyResources(this.RemoveToolStripMenuItem, "RemoveToolStripMenuItem");
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchTextToolStripMenuItem,
            this.GoToRowToolStripMenuItem});
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            resources.ApplyResources(this.SearchToolStripMenuItem, "SearchToolStripMenuItem");
            // 
            // SearchTextToolStripMenuItem
            // 
            this.SearchTextToolStripMenuItem.Name = "SearchTextToolStripMenuItem";
            resources.ApplyResources(this.SearchTextToolStripMenuItem, "SearchTextToolStripMenuItem");
            this.SearchTextToolStripMenuItem.Click += new System.EventHandler(this.SearchTextToolStripMenuItem_Click);
            // 
            // GoToRowToolStripMenuItem
            // 
            this.GoToRowToolStripMenuItem.Name = "GoToRowToolStripMenuItem";
            resources.ApplyResources(this.GoToRowToolStripMenuItem, "GoToRowToolStripMenuItem");
            this.GoToRowToolStripMenuItem.Click += new System.EventHandler(this.GoToRowToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetGameInfoToolStripMenuItem,
            this.CreateTraToolStripMenuItem,
            this.ConvertToolStripMenuItem,
            this.AdvancedToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            resources.ApplyResources(this.ToolsToolStripMenuItem, "ToolsToolStripMenuItem");
            // 
            // GetGameInfoToolStripMenuItem
            // 
            this.GetGameInfoToolStripMenuItem.Name = "GetGameInfoToolStripMenuItem";
            resources.ApplyResources(this.GetGameInfoToolStripMenuItem, "GetGameInfoToolStripMenuItem");
            this.GetGameInfoToolStripMenuItem.Click += new System.EventHandler(this.GetGameInfoToolStripMenuItem_Click);
            // 
            // CreateTraToolStripMenuItem
            // 
            this.CreateTraToolStripMenuItem.Name = "CreateTraToolStripMenuItem";
            resources.ApplyResources(this.CreateTraToolStripMenuItem, "CreateTraToolStripMenuItem");
            this.CreateTraToolStripMenuItem.Click += new System.EventHandler(this.CreateTraToolStripMenuItem_Click);
            // 
            // ConvertToolStripMenuItem
            // 
            this.ConvertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XmlToolStripMenuItem,
            this.CsvToolStripMenuItem});
            this.ConvertToolStripMenuItem.Name = "ConvertToolStripMenuItem";
            resources.ApplyResources(this.ConvertToolStripMenuItem, "ConvertToolStripMenuItem");
            // 
            // XmlToolStripMenuItem
            // 
            this.XmlToolStripMenuItem.Name = "XmlToolStripMenuItem";
            resources.ApplyResources(this.XmlToolStripMenuItem, "XmlToolStripMenuItem");
            this.XmlToolStripMenuItem.Click += new System.EventHandler(this.XmlToolStripMenuItem_Click);
            // 
            // CsvToolStripMenuItem
            // 
            this.CsvToolStripMenuItem.Name = "CsvToolStripMenuItem";
            resources.ApplyResources(this.CsvToolStripMenuItem, "CsvToolStripMenuItem");
            this.CsvToolStripMenuItem.Click += new System.EventHandler(this.CsvToolStripMenuItem_Click);
            // 
            // AdvancedToolStripMenuItem
            // 
            this.AdvancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DecryptSegmentToolStripMenuItem});
            this.AdvancedToolStripMenuItem.Name = "AdvancedToolStripMenuItem";
            resources.ApplyResources(this.AdvancedToolStripMenuItem, "AdvancedToolStripMenuItem");
            // 
            // DecryptSegmentToolStripMenuItem
            // 
            this.DecryptSegmentToolStripMenuItem.Name = "DecryptSegmentToolStripMenuItem";
            resources.ApplyResources(this.DecryptSegmentToolStripMenuItem, "DecryptSegmentToolStripMenuItem");
            this.DecryptSegmentToolStripMenuItem.Click += new System.EventHandler(this.DecryptSegmentToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            resources.ApplyResources(this.HelpToolStripMenuItem, "HelpToolStripMenuItem");
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EntriesCountLabel,
            this.toolStripStatusLabel2,
            this.FileStatusLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // EntriesCountLabel
            // 
            this.EntriesCountLabel.Name = "EntriesCountLabel";
            resources.ApplyResources(this.EntriesCountLabel, "EntriesCountLabel");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // FileStatusLabel
            // 
            this.FileStatusLabel.Name = "FileStatusLabel";
            this.FileStatusLabel.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            resources.ApplyResources(this.FileStatusLabel, "FileStatusLabel");
            // 
            // TranslationGrid
            // 
            this.TranslationGrid.AllowUserToAddRows = false;
            this.TranslationGrid.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.TranslationGrid, "TranslationGrid");
            this.TranslationGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TranslationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TranslationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSource,
            this.colTranslation});
            this.TranslationGrid.MultiSelect = false;
            this.TranslationGrid.Name = "TranslationGrid";
            this.TranslationGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TranslationGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TranslationGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.TranslationGrid_CellPainting);
            this.TranslationGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.TranslationGrid_CellValueChanged);
            this.TranslationGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.TranslationGrid_RowPostPaint);
            this.TranslationGrid.SelectionChanged += new System.EventHandler(this.TranslationGrid_SelectionChanged);
            // 
            // colSource
            // 
            this.colSource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSource.DataPropertyName = "Source";
            resources.ApplyResources(this.colSource, "colSource");
            this.colSource.Name = "colSource";
            this.colSource.ReadOnly = true;
            this.colSource.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colTranslation
            // 
            this.colTranslation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTranslation.DataPropertyName = "Translation";
            resources.ApplyResources(this.colTranslation, "colTranslation");
            this.colTranslation.Name = "colTranslation";
            this.colTranslation.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenStripButton,
            this.SaveStripButton,
            this.toolStripSeparator1,
            this.StatsStripButton,
            this.toolStripSeparator2,
            this.EncodingStripLabel,
            this.EncodingStripCombo});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // OpenStripButton
            // 
            this.OpenStripButton.Image = global::NegrellAGSLocForge.Properties.Resources.document_open_2x;
            resources.ApplyResources(this.OpenStripButton, "OpenStripButton");
            this.OpenStripButton.Name = "OpenStripButton";
            this.OpenStripButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveStripButton
            // 
            this.SaveStripButton.Image = global::NegrellAGSLocForge.Properties.Resources.document_save;
            resources.ApplyResources(this.SaveStripButton, "SaveStripButton");
            this.SaveStripButton.Name = "SaveStripButton";
            this.SaveStripButton.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // StatsStripButton
            // 
            this.StatsStripButton.Image = global::NegrellAGSLocForge.Properties.Resources.stats;
            resources.ApplyResources(this.StatsStripButton, "StatsStripButton");
            this.StatsStripButton.Name = "StatsStripButton";
            this.StatsStripButton.Click += new System.EventHandler(this.StatsStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // EncodingStripLabel
            // 
            this.EncodingStripLabel.Name = "EncodingStripLabel";
            resources.ApplyResources(this.EncodingStripLabel, "EncodingStripLabel");
            // 
            // EncodingStripCombo
            // 
            this.EncodingStripCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncodingStripCombo.Name = "EncodingStripCombo";
            resources.ApplyResources(this.EncodingStripCombo, "EncodingStripCombo");
            this.EncodingStripCombo.SelectedIndexChanged += new System.EventHandler(this.EncodingStripCombo_Changed);
            // 
            // SourceTextBox
            // 
            resources.ApplyResources(this.SourceTextBox, "SourceTextBox");
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.ReadOnly = true;
            // 
            // SourceTextLabel
            // 
            resources.ApplyResources(this.SourceTextLabel, "SourceTextLabel");
            this.SourceTextLabel.Name = "SourceTextLabel";
            // 
            // TranslationTextLabel
            // 
            resources.ApplyResources(this.TranslationTextLabel, "TranslationTextLabel");
            this.TranslationTextLabel.Name = "TranslationTextLabel";
            // 
            // TranslationTextBox
            // 
            resources.ApplyResources(this.TranslationTextBox, "TranslationTextBox");
            this.TranslationTextBox.Name = "TranslationTextBox";
            this.TranslationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TranslationTextBox_KeyDown);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TranslationTextLabel);
            this.Controls.Add(this.TranslationTextBox);
            this.Controls.Add(this.SourceTextLabel);
            this.Controls.Add(this.SourceTextBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TranslationGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TranslationGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView TranslationGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton OpenStripButton;
        private System.Windows.Forms.RichTextBox SourceTextBox;
        private System.Windows.Forms.Label SourceTextLabel;
        private System.Windows.Forms.Label TranslationTextLabel;
        private System.Windows.Forms.RichTextBox TranslationTextBox;
        private System.Windows.Forms.ToolStripStatusLabel EntriesCountLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SaveStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton StatsStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel FileStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetGameInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateTraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConvertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoToRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdvancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DecryptSegmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox EncodingStripCombo;
        private System.Windows.Forms.ToolStripLabel EncodingStripLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTranslation;
    }
}

