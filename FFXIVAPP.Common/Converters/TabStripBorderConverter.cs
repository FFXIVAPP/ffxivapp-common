// FFXIVAPP.Common
// FFXIVAPP & Related Plugins/Modules
// Copyright � 2007 - 2015 Ryan Wilson - All Rights Reserved
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
using System.Windows;
using System.Windows.Data;

namespace FFXIVAPP.Common.Converters
{
    public class TabStripBorderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var thickness = new Thickness();
            switch (value.ToString())
            {
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
