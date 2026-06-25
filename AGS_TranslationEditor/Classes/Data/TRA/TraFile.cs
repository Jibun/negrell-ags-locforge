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

namespace NegrellAGSLocForge.Data.TRA
{
    public class TraFile
    {
        
        public GameInfo gameInfo;
        public List<TranslationEntry> translationEntries;
        public TraOptions options;

        public TraFile() {
            gameInfo = new GameInfo();
            translationEntries = new List<TranslationEntry>();
            options = new TraOptions();
        }

    }
}
