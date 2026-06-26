/* 
   Copyright 2022-2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/

namespace NegrellAGSLocForge.Data.TRA
{
    public static class TraConstants
    {
        //File block codes
        public enum TraBlockCode : int
        {
            Extension = 0,
            Dict = 1,
            GameId = 2,
            TextOpts = 3,
            Eof = -1
        }

        public const string ExtensionStringOptions = "ext_sopts";
        public const string ExtensionFontOverrides = "ext_fonts";
        public const string ExtensionParserDictionary = "ext_parserdict";

        public const string GameEncodingOption = "gameencoding";
        public const string EncodingOption = "encoding";
        public const string LanguageOption = "language";

        public enum TextDirectionMode: int
        {
            Default = -1,
            Ltr = 1,
            Rtl = 2
        };

        //Encryption string
        public static readonly char[] EncryptionChars = { 'A', 'v', 'i', 's', ' ', 'D', 'u', 'r', 'g', 'a', 'n' };
        public static readonly byte[] EncryptionBytes = { 0x41, 0x76, 0x69, 0x73, 0x20, 0x44, 0x75, 0x72, 0x67, 0x61, 0x6e };

        //TRA file signature
        public const string FileSignature = "AGSTranslation\0";
    }
}
