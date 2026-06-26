/* 
   Copyright 2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/
using static NegrellAGSLocForge.Data.TRA.TraConstants;

namespace NegrellAGSLocForge.Data.TRA
{
    public class TraOptions
    {
        public int NormalFont { get; set; } = -1;
        public int SpeechFont { get; set; } = -1;
        public TextDirectionMode RightToLeft { get; set; } = TextDirectionMode.Default;
        public int OptFlags { get; set; } = -1;
        public string GameEncodingHint { get; set; } = null;
        public string EncodingHint { get; set; } = null;
        public string LanguageHint { get; set; } = null;
    }
}
