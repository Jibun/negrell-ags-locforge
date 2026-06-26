/* 
   Copyright 2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/
using System.Collections.Generic;

namespace NegrellAGSLocForge.Data.TRS
{
    public class TrsFile
    {
        public List<TranslationEntry> translationEntries;
        public string EncodingHint;

        public TrsFile() {
            translationEntries = new List<TranslationEntry>();
            EncodingHint = null;
        }

    }
}
