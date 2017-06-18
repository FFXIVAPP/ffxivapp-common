// FFXIVAPP.Common ~ BindingHelper.cs
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

using System.Windows;
using System.Windows.Data;
using FFXIVAPP.Common.Converters;

namespace FFXIVAPP.Common.Helpers
{
    public static class BindingHelper
    {
        /// <summary>
        /// </summary>
        /// <param name="source"> </param>
        /// <param name="path"> </param>
        /// <returns> </returns>
        public static Binding VisibilityBinding(object source, string path)
        {
            var binding = new Binding("Visibility");
            binding.Converter = new VisibilityConverter();
            binding.Source = source;
            binding.Path = new PropertyPath(path);
            binding.Mode = BindingMode.TwoWay;
            return binding;
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static Binding ZoomBinding(object source, string path)
        {
            var binding = new Binding();
            binding.Source = source;
            binding.Path = new PropertyPath(path);
            binding.Mode = BindingMode.TwoWay;
            return binding;
        }
    }
}
