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
using System.IO;
using System.Text;
using static NegrellAGSLocForge.Data.TRA.TraConstants;

namespace NegrellAGSLocForge.Utils
{
    public class StringUtils
    {
        public static string ReadString(BinaryReader br)
        {
            int len = br.ReadInt32();
            if (len > 0)
            {
                byte[] data = br.ReadBytes(len);
                return Encoding.Default.GetString(data);
            }
            return string.Empty;
        }

        /// <summary>
        /// Help function to swap between endianns
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value to swap</returns>
        public static int SwapEndianness(int value)
        {
            var b1 = (value >> 0) & 0xff;
            var b2 = (value >> 8) & 0xff;
            var b3 = (value >> 16) & 0xff;
            var b4 = (value >> 24) & 0xff;

            return b1 << 24 | b2 << 16 | b3 << 8 | b4 << 0;
        }

        /// <summary>
        /// Decrypt a byte array
        /// </summary>
        /// <param name="toEnc">byte array to decrypt</param>
        public static void DecryptBytes(byte[] toEnc)
        {
            int adx = 0;
            int toencx = 0;

            while (toencx < toEnc.Length)
            {

                toEnc[toencx] -= EncryptionBytes[adx];

                adx++;
                toencx++;

                if (adx > 10)
                    adx = 0;
            }
        }

        /// <summary>
        /// Decrypt a char array
        /// </summary>
        /// <param name="toEnc">char array to decrypt</param>
        public static void DecryptChars(char[] toEnc)
        {
            int adx = 0;
            int toencx = 0;

            while (toencx < toEnc.Length)
            {
                /*if (toEnc[toencx] == 0)
                    break;*/

                if (toEnc[toencx] - EncryptionChars[adx] < 0)
                {
                    toEnc[toencx] += (char)256;
                }
                toEnc[toencx] -= EncryptionChars[adx];

                adx++;
                toencx++;

                if (adx > 10)
                    adx = 0;
            }
        }

        /// <summary>
        /// Encrypt a byte array
        /// </summary>
        /// <param name="toenc">byte array to encrypt</param>
        public static void EncryptBytes(byte[] toenc)
        {
            int adx = 0;
            int toencx = 0;

            while (toencx < toenc.Length)
            {
                toenc[toencx] += EncryptionBytes[adx];
                adx++;
                toencx++;

                if (adx > 10)
                    adx = 0;
            }
        }

        /// <summary>
        /// Encrypt a char array
        /// </summary>
        /// <param name="toenc">char array to encrypt</param>
        public static void EncryptChars(char[] toenc)
        {
            int adx = 0;
            int toencx = 0;

            while (toencx < toenc.Length)
            {
                toenc[toencx] += EncryptionChars[adx];
                adx++;
                toencx++;

                if (adx > 10)
                    adx = 0;
            }
        }

        public static byte[] CharsToBytes(char[] chars)
        {
            byte[] bytes = new byte[chars.Length];
            int x = 0;
            foreach (char c in chars)
            {
                bytes[x] = (byte)c;
                x++;
            }

            return bytes;
        }
    }
}
