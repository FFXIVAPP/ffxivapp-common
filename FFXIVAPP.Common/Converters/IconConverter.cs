// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IconConverter.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   IconConverter.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Converters {
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Data;

    using FFXIVAPP.Common.Utilities;
    using FFXIVAPP.ResourceFiles;

    public class IconConverter : IMultiValueConverter {
        private const string IconPath = "/Plugins/{0}/{1}";

        /// <summary>
        /// </summary>
        /// <param name="values"> </param>
        /// <param name="targetType"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            object folder = values[1];
            object name = values[2];
            var location = string.Format(AppDomain.CurrentDomain.BaseDirectory + IconPath, folder, name);
            return File.Exists(location)
                       ? ImageUtilities.LoadImageFromStream(location)
                       : Theme.DefaultPluginLogo;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <param name="targetTypes"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}