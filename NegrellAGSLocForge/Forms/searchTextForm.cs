/* 
   Copyright 2022-2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/
using System;
using System.Windows.Forms;

namespace NegrellAGSLocForge.Forms {
    public partial class SearchTextForm : Form {

        public SearchTextForm() {
            InitializeComponent();
        }

        private void StartSearch(bool forward) {
            MainForm parent = (MainForm)this.Owner;

            SearchOptions options = new SearchOptions();
            options.CaseSensitive = CaseSensitiveCheckBox.Checked;
            options.Forward = forward;
            options.WrapAround = WrapAroundCheckBox.Checked;

            String text = SearchTextTextBox.Text;
            if (!String.IsNullOrWhiteSpace(text.Trim())) {
                if (parent.translationGridUtils.Search.IsEnabled() && !parent.translationGridUtils.Search.SearchedText.Equals(text)) {
                    parent.translationGridUtils.Search.ResetPosition();
                }
                parent.translationGridUtils.SearchText(text, options);
            } else {
                AudioManager.getInstance().audio.PlaySystemSound(System.Media.SystemSounds.Exclamation);
                MessageBox.Show("Text to search is empty.", "Empty text");
            }
        }

        private void SearchNextButton_Click(object sender, EventArgs e) {
            StartSearch(true);
            
        }

        private void SearchPreviewButton_Click(object sender, EventArgs e) {
            StartSearch(false);
        }

        private void SearchTextForm_FormClosed(object sender, FormClosedEventArgs e) {
            MainForm parent = (MainForm)this.Owner;
            parent.translationGridUtils.Search.Disable();
        }
    }
}
