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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static NegrellAGSLocForge.Utils.StringUtils;

namespace NegrellAGSLocForge.Forms
{
    public partial class DecryptForm: Form
    {
        Encoding encoding = Encoding.UTF8;

        public DecryptForm()
        {
            InitializeComponent();
            InitEncodingCombo();
        }

        private void InitEncodingCombo()
        {
            EncodingComboBox.DisplayMember = "Name";
            EncodingComboBox.ValueMember = "Encoding";
            EncodingComboBox.DataSource = EncodingData.encodingsList;
            EncodingComboBox.SelectedIndex = 0;
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckHexString(HexadecimalDataTextBox.Text))
                {
                    byte[] bInputBytes = HexStringToByteArray(HexadecimalDataTextBox.Text);
                    DecryptBytes(bInputBytes);
                    char[] cTranslatedText = encoding.GetChars(bInputBytes, 0, GetHexStringLength(HexadecimalDataTextBox.Text));
                    string sDecTranslatedText = new string(cTranslatedText).Trim('\0');
                    DecryptedHexRichTextBox.Text = BitConverter.ToString(bInputBytes);
                    DecryptedTextRichTextBox.Text = sDecTranslatedText;
                }

            } 
            catch (ArgumentException ae)
            {
                AudioManager.getInstance().audio.PlaySystemSound(System.Media.SystemSounds.Exclamation);
                MessageBox.Show(ae.Message, "Wrong input");
            }
        }
        public static bool CheckHexString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input is empty.");

            input = Regex.Replace(input, @"\s+", "");

            if (!Regex.IsMatch(input, @"\A[0-9A-Fa-f]+\z"))
                throw new ArgumentException("Input must be a valid hexadecimal value.");

            if (input.Length % 2 != 0)
                throw new ArgumentException("Input hexadecimal length must be even.");

            return true;
        }

        public static int GetHexStringLength(string input)
        {
            input = Regex.Replace(input, @"\s+", "");
            return input.Length / 2;
        }

        public static byte[] HexStringToByteArray(string input)
        {
            input = Regex.Replace(input, @"\s+", "");
            byte[] result = new byte[GetHexStringLength(input)];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(input.Substring(i * 2, 2), 16);
            }

            return result;
        }

        private void EncodingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            encoding = (Encoding)EncodingComboBox.SelectedValue;
        }
    }
}
