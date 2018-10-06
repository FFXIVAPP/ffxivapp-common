// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringToBrushConverter.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   StringToBrushConverter.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Converters {
    using System;
    using System.Globalization;
    using Avalonia.Data.Converters;
    using Avalonia.Media;
    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;

    using NLog;

    public class StringToBrushConverter : IValueConverter {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <param name="targetType"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var brushConverter = new BrushConverter();
            value = value.ToString().StartsWith("#")
                        ? value
                        : "#" + value;
            var result = (Brush) brushConverter.ConvertFrom("#FFFFFFFF");
            try {
                result = (Brush) brushConverter.ConvertFrom(value);
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <returns> </returns>
        public object Convert(object value) {
            var brushConverter = new BrushConverter();
            value = value.ToString().Substring(0, 1) == "#"
                        ? value
                        : "#" + value;
            var result = (Brush) brushConverter.ConvertFrom("#FFFFFFFF");
            try {
                result = (Brush) brushConverter.ConvertFrom(value);
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <param name="targetType"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return new BrushConverter().ConvertFrom("#FFFFFFFF");
        }
    }
}