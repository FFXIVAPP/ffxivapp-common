// FFXIVAPP.Common ~ ResourceHelper.cs
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
using System.Windows;
using System.Windows.Resources;
using System.Xml.Linq;

namespace FFXIVAPP.Common.Helpers
{
    public static class ResourceHelper
    {
        /// <summary>
        /// </summary>
        /// <param name="key"> </param>
        /// <returns> </returns>
        public static string StringResource(string key)
        {
            return (string) Application.Current.FindResource(key);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"> </param>
        /// <param name="field"> </param>
        /// <returns> </returns>
        public static string StringResource(object source, string field)
        {
            return (string) source.GetType()
                                  .GetField(field)
                                  .GetValue(null);
        }

        /// <summary>
        /// </summary>
        /// <param name="path"> </param>
        /// <returns> </returns>
        public static StreamResourceInfo StreamResource(string path)
        {
            return Application.GetResourceStream(new Uri(path));
        }

        /// <summary>
        /// </summary>
        /// <param name="path"> </param>
        /// <returns> </returns>
        public static XDocument XDocResource(string path)
        {
            var resource = StreamResource(path);
            return (resource == null) ? null : new XDocument(XElement.Load(resource.Stream));
        }
    }
}
