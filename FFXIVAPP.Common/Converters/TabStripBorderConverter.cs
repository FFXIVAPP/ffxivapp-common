// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TabStripBorderConverter.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   TabStripBorderConverter.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Converters {
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class TabStripBorderConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var thickness = new Thickness();
            switch (value.ToString()) {
                case "Left":
                    thickness.Left = 1;
                    break;
                case "Right":
                    thickness.Right = 1;
                    break;
                case "Top":
                    thickness.Top = 1;
                    break;
                case "Bottom":
                    thickness.Bottom = 1;
                    break;
            }

            return thickness;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}