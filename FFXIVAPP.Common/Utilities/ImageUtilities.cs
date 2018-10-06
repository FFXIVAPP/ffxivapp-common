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
    using Avalonia.Media.Imaging;

    public static class ImageUtilities {
        /// <summary>
        /// Loads an image from a filepath
        /// </summary>
        /// <param name="location">Path to image</param>
        /// <returns>Image as an Bitmap object. Null if not found</returns>
        public static Bitmap LoadImageFromStream(string location) {
            Bitmap result = null;
            if (File.Exists(location)) {
                result = new Bitmap(location);
            }

            return result;
        }
    }
}