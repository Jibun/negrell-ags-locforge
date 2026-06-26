/* 
   Copyright 2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/
using NegrellAGSLocForge.Utils;
using System;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace NegrellAGSLocForge.Forms
{
    public partial class EncodingDialog : Form
    {

        public Encoding SelectedEncoding { get; private set; }

        public enum Function { Encrypting, Decrypting};

        public EncodingDialog(Function function)
        {
            InitializeComponent();

            EncodingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            EncodingComboBox.DataSource = EncodingData.encodingsList;
            EncodingComboBox.SelectedItem = EncodingData.encodingsList
                .FirstOrDefault(e => e.Encoding == Encoding.UTF8);

            EncodingInfoRichTextBox.Rtf = @"{\rtf1\ansi
            \b Encoding information not found in this .TRS file\b0\par
            \par
            This file does not contain metadata about the encoding used to create it.\par
            You must select an encoding manually before continuing.\par
            \par
            \b What this affects:\b0\par
            - How text is converted when saving to .TRA files\par
            - How special characters (accents, non-Latin text) are encoded\par
            \par
            \b Important:\b0\par
            If the selected encoding does not match the original game encoding,\par
            some characters may appear incorrect or be lost in the exported file.\par
            \par
            Please select the encoding used by the original game or translation.\par
            }";

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            EncodingData.EncodingItem item = EncodingComboBox.SelectedItem as EncodingData.EncodingItem;
            if (item != null)
            {
                SelectedEncoding = item.Encoding;
            }
            else
            {
                SelectedEncoding = Encoding.UTF8;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelActionButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
