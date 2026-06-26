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
using System.Drawing;
using System.Windows.Forms;

namespace NegrellAGSLocForge
{
    public class TranslationGridRenderer
    {
        private readonly TranslationGridUtils _gridUtils;

        public TranslationGridRenderer(TranslationGridUtils gridUtils)
        {
            _gridUtils = gridUtils;
        }

        public void RowNumbering(DataGridView grid, DataGridViewRowPostPaintEventArgs paintArgs)
        {
            var rowIdx = (paintArgs.RowIndex + 1).ToString();

            var rightFormat = new StringFormat()
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(paintArgs.RowBounds.Left, paintArgs.RowBounds.Top, grid.RowHeadersWidth - 5, paintArgs.RowBounds.Height);
            paintArgs.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, rightFormat);
        }

        public void CellPainting(DataGridViewCellPaintingEventArgs paintArgs)
        {
            if (paintArgs.FormattedValue == null)
                return;
            if (paintArgs.RowIndex == -1 || paintArgs.ColumnIndex == -1)
            {
                return;
            }

            if (_gridUtils.Search.IsEnabled())
            {
                String gridCellValue = paintArgs.FormattedValue.ToString();
                String text = _gridUtils.Search.SearchedText;

                //check the index of text in the cell

                bool backgroundPainted = false;
                int startIndexInCellValue = -1;
                do
                {
                    int startLookingAt = 0;
                    if (startIndexInCellValue >= 0)
                    {
                        startLookingAt = startIndexInCellValue + text.Length;
                    }
                    startIndexInCellValue = gridCellValue.IndexOf(text, startLookingAt, _gridUtils.Search.ComparisonOption);

                    if (startIndexInCellValue >= 0)
                    {

                        if (!backgroundPainted)
                        {
                            paintArgs.Handled = true;
                            paintArgs.PaintBackground(paintArgs.CellBounds, true);
                            backgroundPainted = true;
                        }

                        //the highlite rectangle  
                        Rectangle hl_rect = new Rectangle();
                        hl_rect.Y = paintArgs.CellBounds.Y + 2;
                        hl_rect.Height = paintArgs.CellBounds.Height - 5;

                        //find size of text preceding searched text
                        String sBeforeSearchword = gridCellValue.Substring(0, startIndexInCellValue);
                        Size sBefore = TextRenderer.MeasureText(paintArgs.Graphics, sBeforeSearchword, paintArgs.CellStyle.Font, paintArgs.CellBounds.Size);

                        //find size of searched text
                        Size sText = TextRenderer.MeasureText(paintArgs.Graphics, text, paintArgs.CellStyle.Font, paintArgs.CellBounds.Size);

                        if (sBefore.Width > 5)
                        {
                            hl_rect.X = paintArgs.CellBounds.X + sBefore.Width - 5;
                            hl_rect.Width = sText.Width - 6;
                        }
                        else
                        {
                            hl_rect.X = paintArgs.CellBounds.X + 2;
                            hl_rect.Width = sText.Width - 6;
                        }

                        //pick color  
                        SolidBrush hl_brush = new SolidBrush(Color.LightYellow);
                        if (_gridUtils.Search.CurrentRow == paintArgs.RowIndex)
                        {
                            if (_gridUtils.Search.CurrentCell == paintArgs.ColumnIndex &&
                                    _gridUtils.Search.CurrentIndex == startIndexInCellValue)
                            {
                                hl_brush = new SolidBrush(Color.Red);
                            }
                            else
                            {
                                hl_brush = new SolidBrush(Color.DarkSalmon);
                            }
                        }

                        //paint background behind searched text  
                        paintArgs.Graphics.FillRectangle(hl_brush, hl_rect);
                        hl_brush.Dispose();

                    }

                } while (startIndexInCellValue != -1);

                //Print cell text
                paintArgs.PaintContent(paintArgs.CellBounds);
            }
        }
    }
}
