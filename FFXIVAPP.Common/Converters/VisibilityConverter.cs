// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisibilityConverter.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   VisibilityConverter.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Converters {
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Data;

    public class VisibilityConverter : IValueConverter {
        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <param name="targetType"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                return (bool) value
                           ? Visibility.Visible
                           : Visibility.Collapsed;
            }
            catch {
                return Regex.IsMatch(value.ToString(), "([Tt]rue|1)")
                           ? Visibility.Visible
                           : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <param name="targetType"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (Visibility) value == Visibility.Visible;
        }
    }
}