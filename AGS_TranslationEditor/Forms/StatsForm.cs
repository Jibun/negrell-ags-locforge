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
using System.Windows.Forms;

namespace NegrellAGSLocForge.Forms
{
    public partial class StatsForm : Form
    {
        public StatsForm()
        {
            InitializeComponent();
        }

        internal void LoadData(int countEntries, int NotTranslatedCount)
        {
            if (countEntries > 0)
            {
                int translatedCount = countEntries - NotTranslatedCount;
                float progressValue = (translatedCount*100)/countEntries;
                ProgressBar.Value = Convert.ToInt32(progressValue);

                TranslatedCountLabel.Text = translatedCount.ToString() + " (" + progressValue + "%)";
                NotTranslatedCountLabel.Text = NotTranslatedCount.ToString();
            }
        }

    }
}
