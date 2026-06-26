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
using System.Text;

namespace NegrellAGSLocForge.Utils
{
    internal class EncodingData
    {
        public static Encoding gameDataEncoding = Encoding.Default;

        public class EncodingItem
        {
            public string Name { get; set; }
            public Encoding Encoding { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public readonly static List<EncodingItem> encodingsList = new List<EncodingItem>
        {
            new EncodingItem { Name = "UTF-8", Encoding = Encoding.UTF8 },
            new EncodingItem { Name = "Windows-1252 (Western)", Encoding = Encoding.GetEncoding(1252) },
            new EncodingItem { Name = "Windows-1250 (Central Europe)", Encoding = Encoding.GetEncoding(1250) },
            new EncodingItem { Name = "Windows-1251 (Cyrillic)", Encoding = Encoding.GetEncoding(1251) }
        };
    }
}
