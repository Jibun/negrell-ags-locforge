/* 
   Copyright 2022-2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/

namespace NegrellAGSLocForge {
    public class SearchOptions {

        private bool wrapAround;
        private bool forward;
        private bool caseSensitive;

        public bool WrapAround { get => wrapAround; set => wrapAround = value; }
        public bool Forward { get => forward; set => forward = value; }
        public bool CaseSensitive { get => caseSensitive; set => caseSensitive = value; }
    }
}
