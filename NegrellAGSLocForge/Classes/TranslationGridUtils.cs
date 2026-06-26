/* 
   Copyright 2022-2026 Ivan L. Negrell

   This file is part of AGS Localization Studio.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   See the LICENSE.md file for details.
*/
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace NegrellAGSLocForge {

    public class TranslationGridUtils {

        private DataGridView translationGrid;

        public class SearchInfo {
            TranslationGridUtils parent;
            private bool active;
            private bool sameSearch;
            private String searchedText;
            private int currentRow;
            private int currentCell;
            private int currentIndex;

            private StringComparison comparisonOption;

            public SearchInfo(TranslationGridUtils parent) {
                this.parent = parent;
                active = false;
                SameSearch = false;
                searchedText = null;
                currentRow = 0;
                currentCell = 0;
                currentIndex = -1;

                ComparisonOption = StringComparison.Ordinal;
            }

            public string SearchedText { get => searchedText; set => searchedText = value; }
            public int CurrentRow { get => currentRow; set => currentRow = value; }
            public int CurrentCell { get => currentCell; set => currentCell = value; }
            public int CurrentIndex { get => currentIndex; set => currentIndex = value; }
            public StringComparison ComparisonOption { get => comparisonOption; set => comparisonOption = value; }
            public bool SameSearch { get => sameSearch; set => sameSearch = value; }

            public void ResetPosition() {
                sameSearch = false;
                currentRow = parent.translationGrid.SelectedRows[0].Index;
                currentCell = 0;
                currentIndex = -1;
            }

            public void Disable() {
                active = false;
                searchedText = null;
                ResetPosition();
                parent.translationGrid.Invalidate();
            }

            public void Enable(String text, int row, int cell, int index) {
                active = true;
                sameSearch = true;
                searchedText = text;
                currentRow = row;
                currentCell = cell;
                currentIndex = index;
                parent.translationGrid.Invalidate();
            }

            public bool IsEnabled() {
                return active;
            }
        }

        private SearchInfo search;
        public SearchInfo Search { get => search; set => search = value; }

        public TranslationGridUtils(DataGridView translationGrid) {
            this.translationGrid = translationGrid;
            search = new SearchInfo(this);
        }

        public void BindDataSource(BindingList<TranslationEntry> entriesSource)
        {
            translationGrid.DataSource = entriesSource;
        }

        public void SearchText(String text, SearchOptions options) {
            //THIS METHOD HAS A LOT OF ROOM FOR IMPROVEMENT!

            StringComparison comparison = StringComparison.Ordinal;
            if (!options.CaseSensitive) {
                comparison = StringComparison.OrdinalIgnoreCase;
            } 
            search.ComparisonOption = comparison;

            int currentRow = translationGrid.CurrentRow.Index;
            int currentCell = search.CurrentCell;
            int currentIndex = search.CurrentIndex;

            bool found = false;
            if (options.Forward) {
                for (; currentRow < translationGrid.Rows.Count; currentRow++) {
                    DataGridViewRow row = translationGrid.Rows[currentRow];
                    for (; currentCell < row.Cells.Count; currentCell++) {
                        String cellText = row.Cells[currentCell].Value.ToString();

                        int searchIndex = 0;
                        if (currentIndex > -1) {
                            searchIndex = currentIndex + text.Length;
                        }
                        do {
                            currentIndex = cellText.IndexOf(text, searchIndex, comparison);
                            if (currentIndex >= 0) {
                                SelectRow(row);
                                Search.Enable(text, currentRow, currentCell, currentIndex);
                                found = true;
                                break;
                            }
                        } while (currentIndex > 0);

                        if (found)
                            break;
                    }
                    if (found) {
                        break;
                    } else {
                        currentCell = 0;
                    }
                }

            } else {
                if (!Search.SameSearch) {
                    currentCell = 1;
                }
                for (; currentRow >= 0; currentRow--) {
                    DataGridViewRow row = translationGrid.Rows[currentRow];
                    for (; currentCell >= 0; currentCell--) {
                        String cellText = row.Cells[currentCell].Value.ToString();

                        int searchIndex = cellText.Length - 1;
                        if (currentIndex > -1) {
                            if(currentIndex == 0) {
                                currentIndex = -1;
                                continue;
                            }
                            searchIndex = currentIndex - 1;
                        }
                        do {
                            currentIndex = cellText.LastIndexOf(text, searchIndex, comparison);
                            if (currentIndex >= 0) {
                                SelectRow(row);
                                Search.Enable(text, currentRow, currentCell, currentIndex);
                                found = true;
                                break;
                            }
                        } while (currentIndex > 0);

                        if (found)
                            break;
                    }
                    if (found) {
                        break;
                    } else {
                        currentCell = 1;
                    }
                }
            }

            if (!found) {
                AudioManager.getInstance().audio.PlaySystemSound(System.Media.SystemSounds.Exclamation);
                MessageBox.Show("The text you were looking for was not found in the document.", "Text not found");
            }
            
        }

        public void GoToRow(int rowNum) {
            int rowCount = translationGrid.Rows.Count;
            if (rowNum >= 0 && rowNum < rowCount) {
                DataGridViewRow row = translationGrid.Rows[rowNum];
                SelectRow(row);

            } else {
                AudioManager.getInstance().audio.PlaySystemSound(System.Media.SystemSounds.Exclamation);
                String message = "Please, select a row between 1 and " + rowCount;
                if (rowCount == 0) {
                    message = "There are no rows in the document.";
                }
                MessageBox.Show(message, "Row out of range");
            }
        }

        public void SelectRow(DataGridViewRow row) {
            translationGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Clear all previous selections
            translationGrid.ClearSelection();

            //Select and go to given row
            translationGrid.CurrentCell = row.Cells[0];
            row.Selected = true;

            Search.CurrentRow = row.Index;
        }

    }
    
}
