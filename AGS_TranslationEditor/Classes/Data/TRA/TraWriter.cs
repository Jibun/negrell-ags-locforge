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
using NegrellAGSLocForge.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static NegrellAGSLocForge.Utils.StringUtils;
using static NegrellAGSLocForge.Data.TRA.TraConstants;

namespace NegrellAGSLocForge.Data.TRA
{
    public class TraWriter
    {
        private static readonly Dictionary<string, string> presetExt_sopts = new Dictionary<string, string>
        {
            { "encoding", "UTF-8" }
        };

        /// <summary>
        /// Create a TRA File for AGS
        /// </summary>
        /// <param name="info">Game Information like Title,UID</param>
        /// <param name="filename">Output filename</param>
        /// <param name="entryList">List with Translation entries</param>
        public static void CreateTraFile(GameInfo info, string filename, List<TranslationEntry> entryList, Encoding translationEncoding)
        {

            bool encrypt = true;

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                byte[] bEmptyEntry = { 0x00, 0x00, 0x00, 0x00, };

                //Write fileSign "AGSTranslation\0"
                byte[] agsHeader =
                {0x41, 0x47, 0x53, 0x54, 0x72, 0x61, 0x6E, 0x73, 0x6C, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x00,};
                fs.Write(agsHeader, 0, agsHeader.Length);

                //--GAME INFO BLOCK--
                byte[] gameInfoBlockID = BitConverter.GetBytes((int)TraBlockCode.GameId);
                fs.Write(gameInfoBlockID, 0, gameInfoBlockID.Length);

                //GameUID important or Translation does not load properly!
                string sGameUID = info.GameUID;
                int decAgain = int.Parse(sGameUID, System.Globalization.NumberStyles.HexNumber);
                byte[] bGameUID = BitConverter.GetBytes(SwapEndianness(decAgain));

                //If game version is higher that V360 no \0 will be added to the end of strings
                string stringEndingMarker = "\0";
                if (info.DataVersion >= GameDataVersion.V360)
                {
                    stringEndingMarker = "";
                }

                //Encrypt the Title
                string gameTitle = info.GameTitle + stringEndingMarker;
                byte[] bGameTitle = Encoding.ASCII.GetBytes(gameTitle);
                if (encrypt)
                {
                    EncryptBytes(bGameTitle);
                }

                //GameTitle Length
                byte[] bGameTitleLength = BitConverter.GetBytes(bGameTitle.Length);

                //Lenght of game info block (GameId and Game Title)
                byte[] bGameInfoLength = BitConverter.GetBytes(bGameUID.Length + bGameTitleLength.Length + bGameTitle.Length);
                fs.Write(bGameInfoLength, 0, bGameInfoLength.Length);

                fs.Write(bGameUID, 0, bGameUID.Length);
                fs.Write(bGameTitleLength, 0, bGameTitleLength.Length);
                fs.Write(bGameTitle, 0, bGameTitle.Length);

                //--DICTIONARY BLOCK--
                byte[] dictionaryBlockID = BitConverter.GetBytes((int)TraBlockCode.Dict);
                fs.Write(dictionaryBlockID, 0, dictionaryBlockID.Length);

                //Write Length translation
                long translationLengthPosition = fs.Position;
                //Dummy write for later
                fs.Write(bEmptyEntry, 0, bEmptyEntry.Length);

                long translationLength = 0;

                if (entryList.Count > 0)
                {
                    foreach (TranslationEntry entry in entryList)
                    {
                        if (entry.Translation != null) //this should be removed, empty lines must remain
                        {
                            //Get original string
                            string entry1 = entry.Source;
                            entry1 = entry1 + stringEndingMarker;

                            /*char[] cEntry1 = entry1.ToCharArray();
                            byte[] bEntry1 = CharsToBytes(cEntry1);*/
                            byte[] bEntry1 = translationEncoding.GetBytes(entry1);
                            if (encrypt)
                            {
                                EncryptBytes(bEntry1);
                            }
                            //Write original string length
                            byte[] bEntry1Length = BitConverter.GetBytes(bEntry1.Length);
                            fs.Write(bEntry1Length, 0, bEntry1Length.Length);

                            //Write original string bytes
                            fs.Write(bEntry1, 0, bEntry1.Length);

                            //Get translation string  
                            string entry2 = entry.Translation;
                            entry2 = entry2 + stringEndingMarker;

                            /*char[] cEntry2 = entry2.ToCharArray();
                            byte[] bEntry2 = CharsToBytes(cEntry2);*/
                            byte[] bEntry2 = translationEncoding.GetBytes(entry2);
                            if (encrypt)
                            {
                                EncryptBytes(bEntry2);
                            }
                            //Write translation string length
                            byte[] bEntry2Length = BitConverter.GetBytes(bEntry2.Length);
                            fs.Write(bEntry2Length, 0, bEntry2Length.Length);

                            //Write translation string bytes
                            fs.Write(bEntry2, 0, bEntry2.Length);

                            long lengthTemp = bEntry1.Length + 4 + bEntry2.Length + 4;
                            translationLength = translationLength + lengthTemp;
                        }

                    }

                }

                //--STRING OPTIONS BLOCK--
                byte[] textOptionsBlockID = BitConverter.GetBytes((int)TraBlockCode.TextOpts);
                fs.Write(textOptionsBlockID, 0, textOptionsBlockID.Length);

                //Write empty text options
                //From 3.6.3.10 - V363_10 it may include additional OptFlags. Not supported.
                byte[] textOptions =
                {
                0x0C, 0x00, 0x00, 0x00,
                0xFF, 0xFF, 0xFF, 0xFF, //Normal font: -1 default
                0xFF, 0xFF, 0xFF, 0xFF, //Speech font: -1 default
                0xFF, 0xFF, 0xFF, 0xFF, //Right to left: -1 default, 1 LTR, 2 RTL
                };
                fs.Write(textOptions, 0, textOptions.Length);

                //--ADDITIONAL EXTENSIONS BLOCK--
                //If game version is higher that V360 and the encoding is UTF-8 we write the extension ext_sopts block
                if (translationEncoding == Encoding.UTF8 && info.DataVersion >= GameDataVersion.V360) 
                {
                    byte[] extensionsBlockID = BitConverter.GetBytes((int)TraBlockCode.Extension);
                    fs.Write(extensionsBlockID, 0, extensionsBlockID.Length);
                    byte[] extType = new byte[16];
                    byte[] textBytes = Encoding.ASCII.GetBytes("ext_sopts");
                    Array.Copy(textBytes, extType, textBytes.Length);
                    fs.Write(extType, 0, extType.Length);
                    byte[] dictionariBytes = DictionaryToBytes(presetExt_sopts); //Temporary preset dictionary print
                    byte[] dictionaryLength = BitConverter.GetBytes((long)dictionariBytes.Length);
                    fs.Write(dictionaryLength, 0, dictionaryLength.Length);
                    fs.Write(dictionariBytes, 0, dictionariBytes.Length);
                }

                //--EOF--
                byte[] eofBlockID = BitConverter.GetBytes((int)TraBlockCode.Eof);
                fs.Write(eofBlockID, 0, eofBlockID.Length);
                fs.Write(bEmptyEntry, 0, bEmptyEntry.Length);

                //Write Translation length
                byte[] b = BitConverter.GetBytes((int)(translationLength));
                fs.Position = translationLengthPosition;
                fs.Write(b, 0, b.Length);

                fs.Close();
            }
        }
        private static byte[] DictionaryToBytes(Dictionary<string, string> dict)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] entriesCount = BitConverter.GetBytes(dict.Count);
                ms.Write(entriesCount, 0, entriesCount.Length);

                foreach (var item in dict)
                {
                    byte[] key = Encoding.ASCII.GetBytes(item.Key);
                    byte[] keyLength = BitConverter.GetBytes(key.Length);
                    ms.Write(keyLength, 0, keyLength.Length);
                    ms.Write(key, 0, key.Length);

                    byte[] value = Encoding.ASCII.GetBytes(item.Value);
                    byte[] valueLength = BitConverter.GetBytes(value.Length);
                    ms.Write(valueLength, 0, valueLength.Length);
                    ms.Write(value, 0, value.Length);
                }

                return ms.ToArray();
            }
        }
    }

}
