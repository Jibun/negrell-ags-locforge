/*
    Original work:
    Copyright 2015 Bernd Keilmann

    Modifications:
    Copyright 2022-2026 Ivan L. Negrell

    This file is part of a program licensed under the GNU GPL v3 or later.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    See the LICENSE.md file for details.
*/
using NegrellAGSLocForge.Utils;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.Application;
using NegrellAGSLocForge.Data.TRA;
using NegrellAGSLocForge.Data.TRS;
using NegrellAGSLocForge.Services;
using NegrellAGSLocForge.Forms;

namespace NegrellAGSLocForge
{
    public partial class MainForm : Form
    {
        private TranslationDocument _document;
        public TranslationGridUtils translationGridUtils;
        private TranslationGridRenderer _gridRenderer;

        //private int selectedRow = 0;

        public MainForm()
        {
            InitializeComponent();
            _document = new TranslationDocument();
            _document.ModifiedChanged += Document_ModifiedChanged;
            _document.LoadedChanged += Document_LoadedChanged;
            _document.EncodingChanged += Document_EncodingChanged;
            _document.Initialize();
        }

        private void MainForm_Load(object sender, EventArgs e) 
        {
            translationGridUtils = new TranslationGridUtils(TranslationGrid);
            TranslationGrid.AutoGenerateColumns = false;

            _gridRenderer = new TranslationGridRenderer(translationGridUtils);

            InitEncodingStripCombo();
        }

        private void Document_LoadedChanged(object sender, EventArgs e)
        {
            SaveToolStripMenuItem.Enabled = _document.Loaded;
            SaveAsToolStripMenuItem.Enabled = _document.Loaded;

            AddToolStripMenuItem.Enabled = _document.Loaded;
            RemoveToolStripMenuItem.Enabled = _document.Loaded;

            SearchTextToolStripMenuItem.Enabled = _document.Loaded;
            GoToRowToolStripMenuItem.Enabled = _document.Loaded;

            SaveStripButton.Enabled = _document.Loaded;
            StatsStripButton.Enabled = _document.Loaded;

            CsvToolStripMenuItem.Enabled = _document.Loaded;
            XmlToolStripMenuItem.Enabled = _document.Loaded;

            EncodingStripCombo.Enabled = _document.Loaded && !_document.EncodingIsAuto;

            this.Text = $"{_document.FileName} - {Properties.Resources.ProjectName}";
            FileStatusLabel.Text = _document.Loaded ? "File loaded" : FileStatusLabel.Text;
            EntriesCountLabel.Text = _document.Loaded ?  $"Entries: {_document.Entries.Count}" : EntriesCountLabel.Text;
        }

        private void Document_ModifiedChanged(object sender, EventArgs e)
        {
            this.Text = 
                (_document.Modified ? "*" : "")
                + $"{_document.FileName} - {Properties.Resources.ProjectName}";
            FileStatusLabel.Text = _document.Modified ? "Unsaved changes" : "File saved";
        }

        private void Document_EncodingChanged(object sender, EventArgs e)
        {
            var item = EncodingData.encodingsList
                .FirstOrDefault(entry => entry.Encoding == _document.CurrentEncoding);
            if (item != null)
                EncodingStripCombo.SelectedItem = item;

            TranslationGrid.Refresh();
        }

        private void InitEncodingStripCombo()
        {
            EncodingStripCombo.Enabled = false;

            var combo = EncodingStripCombo.ComboBox;

            combo.DisplayMember = "Name";
            combo.ValueMember = "Encoding";
            combo.DataSource = EncodingData.encodingsList;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "AGS Translation File(*.TRA,*.TRS)|*.tra;*.trs";

            if (fileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            if (!_document.LoadFromFile(fileDialog.FileName))
                return;

            translationGridUtils.BindDataSource(_document.Entries);
            TranslationGrid.Refresh();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) 
        {
            if (_document.Entries == null || _document.Entries.Count <= 0)
                return;

            if (_document.Modified) {
                SaveManager.SaveBeforeExiting(_document);
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            Exit();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (_document.Entries.Count <= 0)
                return;

            if (SaveManager.Save(_document))
            {
                _document.Modified = false;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (_document.Entries.Count <= 0)
                return;

            SaveManager.SaveAs(_document);

            //TODO when saved as, load new .TRS file and work over it.
        }

        private void StatsStripButton_Click(object sender, EventArgs e)
        {
            StatsForm statsWindow = new StatsForm();
            int countNotTrans = _document.CountUntranslatedEntries();

            statsWindow.LoadData(_document.Entries.Count, countNotTrans);
            statsWindow.StartPosition = FormStartPosition.CenterParent;
            statsWindow.ShowDialog(this);
        }

        private void TranslationGrid_SelectionChanged(object sender, EventArgs e) 
        {

            if (TranslationGrid.SelectedRows.Count == 0)
                return;

            translationGridUtils.Search.ResetPosition();
            int selectedRow = TranslationGrid.SelectedRows[0].Index;

            string originalText = _document.Entries[selectedRow].Source;
            SourceTextBox.Text = originalText;

            string translationText = _document.Entries[selectedRow].Translation;
            TranslationTextBox.Text = translationText;
        }

        private void TranslationGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) 
        {
            _gridRenderer.RowNumbering((DataGridView)sender, e);
        }

        private void TranslationGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            _gridRenderer.CellPainting(e);
        }

        private void TranslationGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.RowIndex < 0)
                return;

            string newText = Convert.ToString(TranslationGrid.Rows[e.RowIndex].Cells["colTranslation"].Value);
            _document.UpdateTranslation(e.RowIndex, newText);
            TranslationGrid.Refresh();
        }

        private void TranslationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (_document.Entries == null)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                int selectedRow = TranslationGrid.SelectedRows[0].Index;
                string newText = TranslationTextBox.Text;
                _document.UpdateTranslation(selectedRow, newText);
                TranslationGrid.Refresh();

                e.Handled = true;
                e.SuppressKeyPress = true;

                TranslationGrid.Focus();
                translationGridUtils.Search.ResetPosition();
                int nextRow = selectedRow + 1;
                if (nextRow >= TranslationGrid.RowCount)
                    return;
                translationGridUtils.SelectRow(TranslationGrid.Rows[nextRow]);
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = TranslationGrid.SelectedRows[0].Index;
            if (selectedRow < 0 || selectedRow >= _document.Entries.Count)
                return;

            int insertionRow = selectedRow + 1;
            TranslationEntry entry = new TranslationEntry("", "");
            _document.Entries.Insert(insertionRow, entry);
            EntriesCountLabel.Text = _document.Entries.Count.ToString();

            translationGridUtils.Search.ResetPosition();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = TranslationGrid.SelectedRows[0].Index;
            if (selectedRow < 0 || selectedRow >= _document.Entries.Count)
                return;

            _document.Entries.RemoveAt(selectedRow);
            EntriesCountLabel.Text = _document.Entries.Count.ToString();

            translationGridUtils.Search.ResetPosition();
        }

        private void GetGameInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExeDialog = new OpenFileDialog() {
                DefaultExt = "exe",
                Filter = "EXE or AGS File (*.exe;*.ags)|*.exe;*.ags",
                Title = "Game EXE or AGS for Translation"
            };

            if (openExeDialog.ShowDialog(this) != DialogResult.OK)
                return;

            GameInfo gameInfo = GameInfo.GetGameInfo(openExeDialog.FileName);
            if (gameInfo == null) {
                MessageBox.Show(
                    this, 
                    "The EXE/AGS selected is not compatible",
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            } else {
                if (gameInfo.DataVersion > GameDataVersion.Current)
                {
                    MessageBox.Show(
                        this,
                        "Warning: This file was created with a newer game data version than this tool supports.\n" +
                        "Some information may be read incorrectly.",
                        "Unsupported Version",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }

                MessageBox.Show(
                    this,
                    $"AGS Version: {gameInfo.CompiledWith}\n" +
                    $"Game Title: {gameInfo.GameTitle}\n" +
                    $"Game UID: {gameInfo.GameUID}",
                    "Game Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void CreateTraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExeDialog = new OpenFileDialog() {
                DefaultExt = "exe",
                Filter = "EXE or AGS File (*.exe;*.ags)|*.exe;*.ags",
                Title = "Game EXE or AGS for Translation"
            };

            OpenFileDialog openDialog = new OpenFileDialog() {
                DefaultExt = "trs",
                Filter = "TRS Translation File (*.trs)|*.trs",
                Title = "Open TRS Translation you want to use."
            };

            SaveFileDialog saveDialog = new SaveFileDialog() {
                DefaultExt = "tra",
                Filter = "TRA Translation File (*.tra)|*.tra",
                Title = "Save TRA Translation as..."
            };

            if (openExeDialog.ShowDialog(this) != DialogResult.OK)
                return;
            if (openDialog.ShowDialog(this) != DialogResult.OK)
                return;
            if (saveDialog.ShowDialog(this) != DialogResult.OK)
                return;

            GameInfo info = GameInfo.GetGameInfo(openExeDialog.FileName);
            if (info == null) {
                MessageBox.Show(
                    this, 
                    "The EXE/AGS selected is not compatible",
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            TrsFile trsFile = TrsReaderWriter.ParseTrsTranslation(openDialog.FileName);
            Encoding encoding;
            if (trsFile.EncodingHint == null)
            {
                using (var encodingDialog = new EncodingDialog(EncodingDialog.Function.Encrypting))
                {
                    if (encodingDialog.ShowDialog(this) != DialogResult.OK)
                        return;
                    encoding = encodingDialog.SelectedEncoding;
                }
            }
            else
            {
                encoding = Encoding.GetEncoding(trsFile.EncodingHint);
            }

            TraWriter.CreateTraFile(info, saveDialog.FileName,
                        trsFile.translationEntries, encoding);

            MessageBox.Show(
                this,
                "TRA successfully created",
                "Success", 
                MessageBoxButtons.OK);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog(this);
        }

        private void XmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_document.Entries.Count <= 0)
                return;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xml";
            saveDialog.AddExtension = true;

            if (saveDialog.ShowDialog(this) != DialogResult.OK)
                return;

            ExportManager.ExportXml(saveDialog.FileName, _document);

            MessageBox.Show(
                this,
                $"File was saved as {saveDialog.FileName}",
                "File saved",
                MessageBoxButtons.OK);
        }

        private void CsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_document.Entries.Count <= 0)
                return;
            
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "csv";
            saveDialog.AddExtension = true;

            if (saveDialog.ShowDialog(this) != DialogResult.OK)
                return;

            ExportManager.ExportCsv(saveDialog.FileName, _document);

            MessageBox.Show(
                this,
                $"File was saved as {saveDialog.FileName}",
                "File saved",
                MessageBoxButtons.OK);
        }

        private void SearchTextToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            SearchTextForm searchForm = new SearchTextForm();
            searchForm.StartPosition = FormStartPosition.CenterParent;
            searchForm.Show(this);
        }

        private void GoToRowToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            GoToRowForm goToRowForm = new GoToRowForm();
            goToRowForm.StartPosition = FormStartPosition.CenterParent;
            goToRowForm.Show(this);
        }

        private void DecryptSegmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DecryptForm decryptForm = new DecryptForm();
            decryptForm.StartPosition = FormStartPosition.CenterParent;
            decryptForm.Show(this);
        }

        private void EncodingStripCombo_Changed(object sender, EventArgs e)
        {
            Encoding selected = (Encoding)EncodingStripCombo.ComboBox.SelectedValue;
            _document.UpdateEncoding(selected);
        }
    }

}
