// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScreenCapture.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ScreenCapture.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------
/* TODO: ScreenCapture
namespace FFXIVAPP.Common.Utilities {
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public static class ScreenCapture {
        /// <summary>
        /// </summary>
        /// <param name="source"> </param>
        /// <param name="scale"> </param>
        /// <param name="quality"> </param>
        /// <returns> </returns>
        public static byte[] GetJpgImage(UIElement source, double scale, int quality) {
            var actualHeight = source.RenderSize.Height;
            var actualWidth = source.RenderSize.Width;
            var renderHeight = actualHeight * scale;
            var renderWidth = actualWidth * scale;
            var renderTarget = new RenderTargetBitmap((int) renderWidth, (int) renderHeight, 96, 96, PixelFormats.Pbgra32);
            var sourceBrush = new VisualBrush(source);
            var drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            using (drawingContext) {
                drawingContext.PushTransform(new ScaleTransform(scale, scale));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(actualWidth, actualHeight)));
            }

            renderTarget.Render(drawingVisual);
            var jpgEncoder = new JpegBitmapEncoder {
                QualityLevel = quality
            };
            jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));
            byte[] imageArray;
            using (var outputStream = new MemoryStream()) {
                jpgEncoder.Save(outputStream);
                imageArray = outputStream.ToArray();
            }

            return imageArray;
        }
    }
}
*/