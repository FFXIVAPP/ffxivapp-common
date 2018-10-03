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
    using System.IO;
    using System.Reflection;
    using System.Xml.Linq;

    public static class ResourceHelper {
        private static Stream GetResource(Assembly assembly, string path) => assembly.GetManifestResourceStream(path);

        /// <summary>
        /// </summary>
        /// <param name="path"> </param>
        /// <returns> </returns>
        public static Stream StreamResource(string path) {
            return StreamResource(System.Reflection.Assembly.GetCallingAssembly(), path);
        }

        public static Stream StreamResource(Assembly assembly, string path) {
            return GetResource(assembly, path);
        }

        /* TODO: StringResource
        /// <summary>
        /// </summary>
        /// <param name="key"> </param>
        /// <returns> </returns>
        public static string StringResource(string key) {
            return (string) Application.Current.FindResource(key);
        }
        */

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
            var resource = GetResource(System.Reflection.Assembly.GetCallingAssembly(), path);
            return resource == null
                       ? null
                       : new XDocument(XElement.Load(resource));
        }
    }
}
