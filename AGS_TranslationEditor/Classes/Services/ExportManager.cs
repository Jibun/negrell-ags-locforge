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
using System.Xml;

namespace NegrellAGSLocForge.Services
{
    public static class ExportManager
    {
        public static void ExportXml(string filename, TranslationDocument document)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = document.CurrentEncoding;
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("AGSTranslationScript");

                int counter = 0;
                foreach (TranslationEntry entry in document.Entries)
                {
                    writer.WriteStartElement("Entry" + counter);
                    writer.WriteElementString("SourceText", entry.Source);
                    writer.WriteElementString("TranslatedText", entry.Translation);
                    writer.WriteEndElement();
                    counter++;
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static void ExportCsv(string filename, TranslationDocument document)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (TranslationEntry entry in document.Entries)
                {
                    sw.Write("{0};{1}\n", entry.Source, entry.Translation);
                }
            }
        }
    }
}
