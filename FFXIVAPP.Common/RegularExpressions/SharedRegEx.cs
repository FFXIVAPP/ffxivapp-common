// FFXIVAPP.Common ~ SharedRegEx.cs
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
using System.Text.RegularExpressions;

namespace FFXIVAPP.Common.RegularExpressions
{
    public static class SharedRegEx
    {
        public const RegexOptions DefaultOptions = RegexOptions.Compiled | RegexOptions.ExplicitCapture;

        /// <summary>
        /// </summary>
        /// <param name="pattern"> </param>
        /// <returns> </returns>
        public static bool IsValidRegex(string pattern)
        {
            var result = true;
            if (String.IsNullOrWhiteSpace(pattern))
            {
                return false;
            }
            try
            {
                result = Regex.IsMatch("", pattern);
            }
            catch (Exception)
            {
                return result;
            }
            return true;
        }
    }
}
