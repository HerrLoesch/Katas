// -----------------------------------------------------------------------
// <copyright file="GameCanvas.cs" company="Saxonia Systems AG">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GameOfLifeUi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GameCanvas : Canvas
    {
        internal bool[,] playground;

        internal void PlayNewRound(bool [,] playground)
        {
            this.playground = playground;
            this.InvalidateVisual();
        }

        protected override void OnRender(System.Windows.Media.DrawingContext dc)
        {
            base.OnRender(dc);


            if (this.playground == null)
            {
                return;
            }

            var xlength = this.playground.GetLength(1);
            var ylength = this.playground.GetLength(0);


            if (ylength == 0 || xlength == 0)
            {
                return;
            }

            double cellHeight = ActualHeight / xlength;
            double cellWidth = ActualWidth / ylength;


            cellHeight = Math.Floor(cellHeight);
            cellWidth = Math.Floor(cellWidth);

            if (cellHeight == 0 || cellWidth == 0)
            {
                FormattedText text = new FormattedText("Auflösung falsch gewählt", CultureInfo.InvariantCulture,FlowDirection.LeftToRight, new Typeface("Arial"),12,Brushes.Black);
                dc.DrawText(text,new Point(25, 25));
                return;
            }

            for (int x = 0; x < ylength; x++)
            {
                for (int y = 0; y < xlength; y++)
                {
                    var rect = new Rect(x*cellWidth, y*cellHeight, cellWidth, cellHeight);
                    if (this.playground[x, y] == true)
                    {
                        dc.DrawRectangle(Brushes.Blue, new Pen(), rect);
                    }
                }
            }

            for (int x = 0; x <= ylength; x++)
            {
                var drawingWidth = ylength*cellWidth;
                dc.DrawLine(new Pen(Brushes.LightGray, 1), new Point(0, x * cellHeight), new Point(drawingWidth, x * cellHeight));
            }

            for (int y = 0; y <= xlength; y++)
            {
                var drawingLength = xlength * cellHeight;
                dc.DrawLine(new Pen(Brushes.LightGray, 1), new Point(y * cellWidth, 0), new Point(y * cellWidth, drawingLength));
            }
        }



    }
}
