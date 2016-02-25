// FFXIVAPP.Common ~ ScreenCapture.cs
// 
// Copyright © 2007 - 2016 Ryan Wilson - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FFXIVAPP.Common.Utilities
{
    public static class ScreenCapture
    {
        /// <summary>
        /// </summary>
        /// <param name="source"> </param>
        /// <param name="scale"> </param>
        /// <param name="quality"> </param>
        /// <returns> </returns>
        public static byte[] GetJpgImage(UIElement source, double scale, int quality)
        {
            var actualHeight = source.RenderSize.Height;
            var actualWidth = source.RenderSize.Width;
            var renderHeight = actualHeight * scale;
            var renderWidth = actualWidth * scale;
            var renderTarget = new RenderTargetBitmap((int) renderWidth, (int) renderHeight, 96, 96, PixelFormats.Pbgra32);
            var sourceBrush = new VisualBrush(source);
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();
            using (drawingContext)
            {
                drawingContext.PushTransform(new ScaleTransform(scale, scale));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
            }
            renderTarget.Render(drawingVisual);
            var jpgEncoder = new JpegBitmapEncoder
            {
                QualityLevel = quality
            };
            jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
            Byte[] imageArray;
            using (var outputStream = new MemoryStream())
            {
                jpgEncoder.Save(outputStream);
                imageArray = outputStream.ToArray();
            }
            return imageArray;
        }
    }
}
