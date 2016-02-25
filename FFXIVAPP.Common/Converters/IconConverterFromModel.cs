// FFXIVAPP.Common ~ IconConverterFromModel.cs
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
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using FFXIVAPP.Common.Utilities;

namespace FFXIVAPP.Common.Converters
{
    public class IconConverterFromModel : IMultiValueConverter
    {
        private const string IconPath = "/Plugins/{0}/{1}";

        /// <summary>
        /// </summary>
        /// <param name="values"> </param>
        /// <param name="targetType"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var source = new BitmapImage(new Uri(Constants.DefaultIcon));
            var folder = values[1];
            var name = values[2];
            var location = String.Format(AppDomain.CurrentDomain.BaseDirectory + IconPath, folder, name);
            return File.Exists(location) ? ImageUtilities.LoadImageFromStream(location) : source;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        /// <param name="targetTypes"> </param>
        /// <param name="parameter"> </param>
        /// <param name="culture"> </param>
        /// <returns> </returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
