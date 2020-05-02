// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedRegEx.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   SharedRegEx.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.RegularExpressions {
    using System;
    using System.Text.RegularExpressions;

    public static class SharedRegEx {
        public const RegexOptions DefaultOptions = RegexOptions.Compiled | RegexOptions.ExplicitCapture;

        /// <summary>
        /// </summary>
        /// <param name="pattern"> </param>
        /// <returns> </returns>
        public static bool IsValidRegex(string pattern) {
            var result = true;
            if (string.IsNullOrWhiteSpace(pattern)) {
                return false;
            }

            try {
                result = Regex.IsMatch(string.Empty, pattern);
            }
            catch (Exception) {
                return result;
            }

            return true;
        }
    }
}