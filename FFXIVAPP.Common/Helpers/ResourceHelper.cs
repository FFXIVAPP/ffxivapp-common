// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceHelper.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ResourceHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Helpers {
    using System;
    using System.Windows;
    using System.Windows.Resources;
    using System.Xml.Linq;

    public static class ResourceHelper {
        /// <summary>
        /// </summary>
        /// <param name="path"> </param>
        /// <returns> </returns>
        public static StreamResourceInfo StreamResource(string path) {
            return Application.GetResourceStream(new Uri(path));
        }

        /// <summary>
        /// </summary>
        /// <param name="key"> </param>
        /// <returns> </returns>
        public static string StringResource(string key) {
            return (string) Application.Current.FindResource(key);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"> </param>
        /// <param name="field"> </param>
        /// <returns> </returns>
        public static string StringResource(object source, string field) {
            return (string) source.GetType().GetField(field).GetValue(null);
        }

        /// <summary>
        /// </summary>
        /// <param name="path"> </param>
        /// <returns> </returns>
        public static XDocument XDocResource(string path) {
            StreamResourceInfo resource = StreamResource(path);
            return resource == null
                       ? null
                       : new XDocument(XElement.Load(resource.Stream));
        }
    }
}