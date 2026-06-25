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
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static NegrellAGSLocForge.Utils.StringUtils;
using static NegrellAGSLocForge.Data.TRA.TraConstants;

namespace NegrellAGSLocForge.Data.TRA
{
    public class TraReader
    {
        private Dictionary<string, byte[]> translationBlocks;
        public TraFile traFile;

        public TraReader() {
            translationBlocks = new Dictionary<string, byte[]>();
            traFile =  new TraFile();
        }

        private bool CheckHeader(BinaryReader br)
        {
            //Translation File Signature
            byte[] header = br.ReadBytes(15);

            return Encoding.ASCII.GetString(header) == FileSignature;
        }

        private bool ReadBlock(BinaryReader br)
        {
            if (br.BaseStream.Position + 8 > br.BaseStream.Length)
                return false;

            int blockType = br.ReadInt32();
            if (!Enum.IsDefined(typeof(TraBlockCode), blockType))
                return false;

            string sBlockType;
            long blockLength;
            if (blockType == (int)TraBlockCode.Extension)
            {
                sBlockType = Encoding.ASCII.GetString(br.ReadBytes(16)).Trim('\0');
                blockLength = br.ReadInt64();
            }
            else
            {
                sBlockType = ((TraBlockCode)blockType).ToString();
                blockLength = br.ReadInt32();

                //Fix: files made by pre-3.0 editors have a block length miscount by 1 byte
                if (blockType == (int)TraBlockCode.GameId)
                {
                    long streamPosition = br.BaseStream.Position;

                    br.BaseStream.Position += 4; //We pass over Game ID
                    int titleLength = br.ReadInt32();
                    if (titleLength + 8 != blockLength)
                    {
                        blockLength = titleLength + 8;
                        System.Diagnostics.Debug.WriteLine("WARNING: GameInfo block lenght miscount (known issue).");
                    }

                    br.BaseStream.Position = streamPosition;
                }
                //End of Fix
            }

            translationBlocks.Add(sBlockType, br.ReadBytes(Convert.ToInt32(blockLength)));

            return true;
        }

        private void ReadAllBlocks(BinaryReader br)
        {
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                if (!ReadBlock(br))
                    break;
            }
        }

        private void ReadDictionary(BinaryReader br, out Dictionary<string, string> dictionary)
        {
            dictionary = new Dictionary<string, string>();
            int entriesCount = br.ReadInt32();
            int i = 0;
            while (i < entriesCount && br.BaseStream.Position < br.BaseStream.Length)
            {
                string key = Encoding.ASCII.GetString(ReadEntry(br));
                string value = Encoding.ASCII.GetString(ReadEntry(br));

                dictionary.Add(key, value);

                i++;
            }
        }

        private byte[] ReadEntry(BinaryReader br)
        {
            int entryLength = br.ReadInt32();
            return br.ReadBytes(entryLength);
        }

        private void ParseGameInfoBlock(byte[] blockBytes)
        {
            using (MemoryStream ms = new MemoryStream(blockBytes))
            using (BinaryReader brBlock = new BinaryReader(ms))
            {
                byte[] bGameId = brBlock.ReadBytes(4);
                traFile.gameInfo.GameUID = BitConverter.ToString(bGameId).Replace("-", "");

                byte[] bGameTitle = ReadEntry(brBlock);
                DecryptBytes(bGameTitle);
                traFile.gameInfo.GameTitle = Encoding.ASCII.GetString(bGameTitle).Trim('\0');
            }
        }

        private void ParseDictionaryBlock(byte[] blockBytes)
        {
            using (MemoryStream ms = new MemoryStream(blockBytes))
            using (BinaryReader brBlock = new BinaryReader(ms))
            {

                int entryNum = 0;
                while (ms.Position < ms.Length)
                {
                    int sourceLength = brBlock.ReadInt32();
                    byte[] sourceBytes = brBlock.ReadBytes(sourceLength);
                    DecryptBytes(sourceBytes);

                    int translatedLength = brBlock.ReadInt32();
                    byte[] translatedBytes = brBlock.ReadBytes(translatedLength);
                    DecryptBytes(translatedBytes);

                    traFile.translationEntries.Add(new TranslationEntry(sourceBytes, translatedBytes));

                    entryNum++;
                }
            }
        }

        private void ParseTextOptionsBlock(byte[] blockBytes)
        {
            using (MemoryStream ms = new MemoryStream(blockBytes))
            using (BinaryReader brBlock = new BinaryReader(ms))
            {
                traFile.options.NormalFont = brBlock.ReadInt32();
                traFile.options.SpeechFont = brBlock.ReadInt32();
                traFile.options.RightToLeft = (TextDirectionMode)brBlock.ReadInt32();
                // 3.6.3.10 expansion
                if (blockBytes.Length > 3 * 4)
                {
                    traFile.options.OptFlags = brBlock.ReadInt32();
                }
            }
        }

        private void ParseExtensionBlock(byte[] blockBytes)
        {
            using (MemoryStream ms = new MemoryStream(blockBytes))
            using (BinaryReader brBlock = new BinaryReader(ms))
            {
                ReadDictionary(brBlock, out var tempDict);

                traFile.options.GameEncodingHint = 
                    tempDict.TryGetValue(GameEncodingOption, out var gameEnc) 
                        ? gameEnc 
                        : null;

                traFile.options.EncodingHint = 
                    tempDict.TryGetValue(EncodingOption, out var enc) 
                        ? enc 
                        : null;

                traFile.options.LanguageHint = 
                    tempDict.TryGetValue(LanguageOption, out var lang) 
                        ? lang 
                        : null;
            }
        }

        /// <summary>
        /// Reads and parses a TRA file
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>A TraFile with the translation data</returns>
        public TraFile ParseTraTranslation(string filename)
        {
            using (FileStream fs = File.OpenRead(filename))
            {
                BinaryReader br = new BinaryReader(fs);

                CheckHeader(br);

                ReadAllBlocks(br);

                if(translationBlocks.TryGetValue(TraBlockCode.GameId.ToString(), out var gameInfoBlock))
                    ParseGameInfoBlock(gameInfoBlock);

                if (translationBlocks.TryGetValue(TraBlockCode.Dict.ToString(), out var translationBlock))
                    ParseDictionaryBlock(translationBlock);

                if (translationBlocks.TryGetValue(TraBlockCode.TextOpts.ToString(), out var optsBlock))
                    ParseTextOptionsBlock(optsBlock);

                if(translationBlocks.TryGetValue(ExtensionStringOptions, out var extBlock))
                    ParseExtensionBlock(extBlock);

                //For now ignore other extensions

                /*if (traFile.options.EncodingHint != null)
                {
                    Encoding encoding = Encoding.GetEncoding(traFile.options.EncodingHint);
                    traFile.DecodeTranslationEntries(encoding);
                }*/

                return traFile;
            }
        }
    }
}
