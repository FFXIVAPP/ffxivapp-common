// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageUtilities.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ImageUtilities.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Utilities {
    using System.IO;
    using System.Windows.Media.Imaging;

    public static class ImageUtilities {
        public static BitmapImage LoadImageFromStream(string location) {
            BitmapImage result = null;
            if (location != null) {
                var bitmapImage = new BitmapImage();
                using (FileStream stream = File.OpenRead(location)) {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                }

                result = bitmapImage;
            }

            return result;
        }
    }
}