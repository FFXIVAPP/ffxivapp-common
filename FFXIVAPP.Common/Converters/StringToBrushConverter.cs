// FFXIVAPP.Common ~ StringToBrushConverter.cs
// 
// Copyright © 2007 - 2017 Ryan Wilson - All Rights Reserved
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
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using FFXIVAPP.Common.Models;
using FFXIVAPP.Common.Utilities;
using NLog;

namespace FFXIVAPP.Common.Converters
{
    public class StringToBrushConverter : IValueConverter
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <param name="targetType"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brushConverter = new BrushConverter();
            value = value.ToString()
                         .StartsWith("#") ? value : "#" + value;
            var result = (Brush) brushConverter.ConvertFrom("#FFFFFFFF");
            try
            {
                result = (Brush) brushConverter.ConvertFrom(value);
            }
            catch (Exception ex)
            {
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
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new BrushConverter().ConvertFrom("#FFFFFFFF");
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <returns> </returns>
        public object Convert(object value)
        {
            var brushConverter = new BrushConverter();
            value = value.ToString()
                         .Substring(0, 1) == "#" ? value : "#" + value;
            var result = (Brush) brushConverter.ConvertFrom("#FFFFFFFF");
            try
            {
                result = (Brush) brushConverter.ConvertFrom(value);
            }
            catch (Exception ex)
            {
                Logging.Log(Logger, new LogItem(ex, true));
            }
            return result;
        }
    }
}
