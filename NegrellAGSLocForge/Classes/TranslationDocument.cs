/* 
   Copyright 2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/
using NegrellAGSLocForge.Data.TRA;
using NegrellAGSLocForge.Data.TRS;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace NegrellAGSLocForge
{
    public class TranslationDocument
    {
        public string FileName { get; set; } = string.Empty;
        private bool _modified;
        public bool Modified
        {
            get => _modified;
            set
            {
                if (_modified == value)
                    return;

                _modified = value;
                OnModifiedChanged();
            }
        }
        private bool _loaded;
        public bool Loaded
        {
            get => _loaded;
            set
            {
                /*if (_loaded == value)
                    return;*/

                _loaded = value;
                OnLoadedChanged();
            }
        }
        public bool EncodingIsAuto { get; set; }
        public Encoding CurrentEncoding { get; set; } = Encoding.GetEncoding(1252);
        public BindingList<TranslationEntry> Entries { get; set; } = null;

        public event EventHandler ModifiedChanged;
        protected virtual void OnModifiedChanged()
        {
            ModifiedChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler LoadedChanged;
        protected virtual void OnLoadedChanged()
        {
            LoadedChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler EncodingChanged;
        protected virtual void OnEncodingChanged()
        {
            EncodingChanged?.Invoke(this, EventArgs.Empty);
        }

        public TranslationDocument() {}

        public void Initialize()
        {
            OnLoadedChanged();
        }

        public int CountUntranslatedEntries()
        {
            int untranslatedCount = 0;
            foreach (TranslationEntry entry in Entries)
            {
                if (entry.Source.Equals(""))
                    continue;

                if (entry.Translation.Equals(""))
                    untranslatedCount++;
            }
            return untranslatedCount;
        }

        public void UpdateEncoding(Encoding encoding)
        {
            if (CurrentEncoding == encoding)
                    return;

            CurrentEncoding = encoding;

            if (Entries == null)
                return;

            foreach (var e in Entries)
            {
                e.DecodeEntry(encoding);
            }

            OnEncodingChanged();
        }

        public void UpdateTranslation(int entityIdx, string newText)
        {
            if (entityIdx < 0 || entityIdx >= Entries.Count)
                return;

            if (Entries[entityIdx].RawTranslation != null)
                Entries[entityIdx].RawTranslation = CurrentEncoding.GetBytes(newText + '\0');
            Entries[entityIdx].Translation = newText;

            Modified = true;
        }

        public bool LoadFromFile(string fileName)
        {
            BindingList<TranslationEntry> entryList = null;
            Encoding enc = Encoding.GetEncoding(1252);
            FileName = fileName;
            if (Path.GetExtension(fileName).Equals(".tra", StringComparison.OrdinalIgnoreCase))
            {

                TraReader traReader = new TraReader();
                TraFile traFile = traReader.ParseTraTranslation(fileName);

                entryList = new BindingList<TranslationEntry>(traFile.translationEntries);

                EncodingIsAuto = !string.IsNullOrEmpty(traFile.options.EncodingHint);
                if (EncodingIsAuto)
                    enc = Encoding.GetEncoding(traFile.options.EncodingHint);

            }
            else if (Path.GetExtension(fileName).Equals(".trs", StringComparison.OrdinalIgnoreCase))
            {
                TrsFile trsFile = TrsReaderWriter.ParseTrsTranslation(fileName);
                entryList = new BindingList<TranslationEntry>(trsFile.translationEntries);

                EncodingIsAuto = !string.IsNullOrEmpty(trsFile.EncodingHint);
                if (EncodingIsAuto)
                    enc = Encoding.GetEncoding(trsFile.EncodingHint);
            } 
            else
            {
                return false;
            }

            Entries = entryList;

            CurrentEncoding = null;
            UpdateEncoding(enc);

            Loaded = true;
            Modified = false;

            return true;
        }

    }
}
