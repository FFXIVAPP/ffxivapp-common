// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyHelper.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   AssemblyHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Helpers {
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;

    public static class AssemblyHelper {
        public static string Copyright {
            get {
                object[] att = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return att.Length == 0
                           ? string.Empty
                           : ((AssemblyCopyrightAttribute) att[0]).Copyright;
            }
        }

        public static string Description {
            get {
                object[] att = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return att.Length == 0
                           ? string.Empty
                           : ((AssemblyDescriptionAttribute) att[0]).Description;
            }
        }

        public static string Guid {
            get {
                object[] att = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(GuidAttribute), true);
                return att.Length == 0
                           ? string.Empty
                           : ((GuidAttribute) att[0]).Value;
            }
        }

        public static string Name {
            get {
                object[] att = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                return att.Length == 0
                           ? string.Empty
                           : ((AssemblyTitleAttribute) att[0]).Title;
            }
        }

        public static Version Version {
            get {
                return Assembly.GetCallingAssembly().GetName().Version;
            }
        }

        public static string Hash(string prefix, string salt, string suffix) {
            var ue = new UnicodeEncoding();
            byte[] message = ue.GetBytes(prefix + salt + suffix);
            var hashString = new SHA512Managed();
            byte[] hashValue = hashString.ComputeHash(message);
            return hashValue.Aggregate(string.Empty, (current, x) => current + $"{x:x2}");
        }
    }
}