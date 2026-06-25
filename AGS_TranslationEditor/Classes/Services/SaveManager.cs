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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static NegrellAGSLocForge.Data.TRS.TrsReaderWriter;

namespace NegrellAGSLocForge.Services
{
    static class SaveManager
    {
        public static bool Save(TranslationDocument document)
        {
            Match extension = Regex.Match(document.FileName, "\\.[0-9a-z]+$");
            if (extension.Value.Equals(".trs"))
            {
                return SaveFile(document.FileName, document);
            }
            else
            {
                return SaveAs(document);
            }
        }

        public static bool SaveBeforeExiting(TranslationDocument document)
        {
            string question = document.FileName.Substring(document.FileName.LastIndexOf("\\") + 1) +
                    " has been modified. Do you want to save the changes?";

            //Ask if user wants to save if data was changed
            if (MessageBox.Show(question, "AGS Translation Editor", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                //Save changes then exit
                return Save(document);
            }
            return false;
        }

        public static bool SaveFile(string filename, TranslationDocument document)
        {
            CreateTrsFile(filename, document.Entries, document.CurrentEncoding);

            MessageBox.Show(
                $"File was saved as {filename}",
                "File saved",
                MessageBoxButtons.OK);

            return true;
        }

        public static bool SaveAs(TranslationDocument document)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "trs";
            //saveDialog.AddExtension = true;
            saveDialog.Filter = "AGS Translation File(*.TRS)|*.trs";

            if (saveDialog.ShowDialog() == DialogResult.OK)
                return SaveFile(saveDialog.FileName, document);
            
            return false;
        }
    }
}
