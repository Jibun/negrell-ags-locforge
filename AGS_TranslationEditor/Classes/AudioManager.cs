/* 
   Copyright 2022-2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/
using Microsoft.VisualBasic.Devices;

namespace NegrellAGSLocForge {
    public class AudioManager {

        private static AudioManager instance = null;

        public Audio audio;

        private AudioManager() {
            audio = new Audio();
    }

        public static AudioManager getInstance() {
            if (instance == null) {
                instance = new AudioManager();
            }
            return instance;
        }
    }
}
