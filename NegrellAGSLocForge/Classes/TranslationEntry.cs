/* 
   Copyright 2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/
using System.Text;

namespace NegrellAGSLocForge
{
    public class TranslationEntry
    {
        public byte[] RawSource { get; set; }
        public byte[] RawTranslation { get; set; }
        public string Source { get; set; }
        public string Translation { get; set; }

        public TranslationEntry() { }

        public TranslationEntry(byte[] source, byte[] translation)
        {
            RawSource = source;
            RawTranslation = translation;
        }

        public TranslationEntry(string source, string translation) {
            Source = source;
            Translation = translation;
        }

        public void DecodeEntry(Encoding enc)
        {
            if (RawSource != null) 
                Source = enc.GetString(RawSource).Trim('\0');

            if (RawTranslation != null)
                Translation = enc.GetString(RawTranslation).Trim('\0');
        }
        
    }
}
