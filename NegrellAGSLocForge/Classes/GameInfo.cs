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
using System.IO;
using static NegrellAGSLocForge.Utils.StringUtils;

namespace NegrellAGSLocForge
{
    public class GameInfo
    {
        public GameDataVersion DataVersion { get; set; }
        public string CompiledWith { get; set; }
        public string GameTitle { get; set; }
        public string GameUID { get; set; }


        /// <summary>
        /// Get Game information (GameTitle and GameUID) from AGS EXE File
        /// </summary>
        /// <param name="filename">Game EXE File</param>
        public static GameInfo GetGameInfo(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                //The string we want to search in the AGS Game File or Executable
                String searchString = "Adventure Creator Game File v2";

                // Gameinfo class to hold the information
                GameInfo info = new GameInfo();

                const int blockSize = 1024;
                long fileSize = fs.Length;
                long position = 0;

                //Read AGS EXE and search for string, should actually never reach the end 
                BinaryReader br = new BinaryReader(fs);
                while (position < fileSize)
                {
                    byte[] data = br.ReadBytes(blockSize);
                    string tempData = EncodingData.gameDataEncoding.GetString(data);

                    //If the search string is found get the game info
                    if (tempData.Contains(searchString))
                    {
                        int startPosition = tempData.IndexOf(searchString, 0, StringComparison.Ordinal);
                        //Calculate and set the position to start reading
                        startPosition = startPosition + 0x1E + (int)position;
                        fs.Position = startPosition;

                        //Obtain the following 4 bytes with the Game data version. Skip if the first one is empty
                        byte[] versionBytes = br.ReadBytes(4);
                        if (versionBytes[0] == 0x00)
                        {
                            position = startPosition + 1;
                            fs.Position = position;
                            continue;
                        }
                        GameDataVersion dataVersion = (GameDataVersion)BitConverter.ToInt32(versionBytes, 0);
                        info.DataVersion = dataVersion;

                        //If the data version is equal or grater that 230 we can retrieve the compilation version
                        if (dataVersion >= GameDataVersion.V230)
                        {
                            //Get the AGS version the game was compiled with
                            info.CompiledWith = StringUtils.ReadString(br);
                        }

                        //If the data version is equal or grater than 341, we can skip the following 4 bytes
                        if (dataVersion >= GameDataVersion.V341)
                            br.ReadInt32();

                        //Calculate and save GameUID position for later use
                        long gameUIDPosition = fs.Position + 0x6f4;

                        //Get the game title
                        string gameTitle = new string(br.ReadChars(0x40));
                        info.GameTitle = gameTitle.Substring(0, gameTitle.IndexOf("\0", StringComparison.Ordinal));

                        //Read the GameUID
                        fs.Position = gameUIDPosition;
                        int GameUID = br.ReadInt32();
                        GameUID = SwapEndianness(GameUID);
                        info.GameUID = GameUID.ToString("X");

                        //return the Game information
                        return info;
                    }
                    //Calculate new postiton
                    position = position + blockSize;
                }
            }

            //if nothing found return just null
            return null;
        }
    }
}
