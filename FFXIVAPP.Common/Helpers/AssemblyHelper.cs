// FFXIVAPP.Common ~ AssemblyHelper.cs
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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace FFXIVAPP.Common.Helpers
{
    public static class AssemblyHelper
    {
        #region Assembly Property Bindings

        public static string Name
        {
            get
            {
                var att = Assembly.GetCallingAssembly()
                                  .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                return att.Length == 0 ? "" : ((AssemblyTitleAttribute) att[0]).Title;
            }
        }

        public static string Description
        {
            get
            {
                var att = Assembly.GetCallingAssembly()
                                  .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return att.Length == 0 ? "" : ((AssemblyDescriptionAttribute) att[0]).Description;
            }
        }

        public static string Copyright
        {
            get
            {
                var att = Assembly.GetCallingAssembly()
                                  .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return att.Length == 0 ? "" : ((AssemblyCopyrightAttribute) att[0]).Copyright;
            }
        }

        public static Version Version
        {
            get
            {
                return Assembly.GetCallingAssembly()
                               .GetName()
                               .Version;
            }
        }

        public static string Guid
        {
            get
            {
                var att = Assembly.GetCallingAssembly()
                                  .GetCustomAttributes(typeof(GuidAttribute), true);
                return att.Length == 0 ? "" : ((GuidAttribute) att[0]).Value;
            }
        }

        public static string Hash(string prefix, string salt, string suffix)
        {
            var ue = new UnicodeEncoding();
            var message = ue.GetBytes(prefix + salt + suffix);
            var hashString = new SHA512Managed();
            var hashValue = hashString.ComputeHash(message);
            return hashValue.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));
        }

        #endregion
    }
}
