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
    public partial class GoToRowForm : Form {

        public GoToRowForm() {
            InitializeComponent();
        }

        private void GoButton_Click(object sender, EventArgs e) {
            MainForm parent = (MainForm)this.Owner;

            if (int.TryParse(GoToRowTextBox.Text, out int rowNumber)) {
                rowNumber -= 1;

                parent.translationGridUtils.GoToRow(rowNumber);
            } else {
                AudioManager.getInstance().audio.PlaySystemSound(System.Media.SystemSounds.Exclamation);
                MessageBox.Show("Field must be a number.", "Wrong format");
            }

        }

        private void GoToRowTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)) {
                e.Handled = true;
                AudioManager.getInstance().audio.PlaySystemSound(System.Media.SystemSounds.Exclamation);
            }
        }
    }
}
