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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NegrellAGSLocForge.Data.TRS
{
    public class TrsReaderWriter
    {
        private const string encodingPrefix = "//#Encoding=";

        /// <summary>
        /// Parse a TRS file for AGS
        /// </summary>
        /// <param name="filename">Input filename</param>
        /// <returns>TrsFile with the translation data</returns>
        public static TrsFile ParseTrsTranslation(string filename)
        {
            TrsFile trsFile = new TrsFile();

            string[] lines = File.ReadAllLines(filename, new UTF8Encoding(false));

            List<string> translationLines = new List<string>();
            foreach (string line in lines)
            {
                if (line.StartsWith(encodingPrefix))
                {
                    trsFile.EncodingHint = line.Substring(encodingPrefix.Length);
                }
                else if (!line.StartsWith("//"))
                {
                    translationLines.Add(line);
                }
            }

            for (int i = 0; i < translationLines.Count;)
            {
                string sSourceText = translationLines[i++];
                string sTranslationText = "";

                if (i < translationLines.Count)
                {
                    sTranslationText = translationLines[i++];
                }

                trsFile.translationEntries.Add(new TranslationEntry(sSourceText, sTranslationText));
            }
            return trsFile;
        }

        public static void CreateTrsFile(string filename, IEnumerable<TranslationEntry> entryList, Encoding translationEncoding)
        {
            using (StreamWriter fw = new StreamWriter(filename, false, new UTF8Encoding(false)))
            {
                fw.WriteLine(encodingPrefix + translationEncoding.WebName);
                foreach (TranslationEntry entry in entryList)
                {
                    fw.WriteLine(entry.Source);
                    fw.WriteLine(entry.Translation);
                }
            }
        }
    }
}