// FFXIVAPP.Common
// SharedRegEx.cs
// 
// Copyright � 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

using System;
using System.Text.RegularExpressions;
using NLog;

namespace FFXIVAPP.Common.RegularExpressions
{
    public static class SharedRegEx
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        public const RegexOptions DefaultOptions = RegexOptions.Compiled | RegexOptions.ExplicitCapture;

        public static readonly Regex Romans = new Regex(@"(?<roman>\b[IVXLCDM]+\b)", DefaultOptions);

        public static readonly Regex Titles = new Regex(@"(?<num>\d+)(?<designator>\w+)", DefaultOptions | RegexOptions.IgnoreCase);

        public static readonly Regex CleanSpaces = new Regex(@"[ ]+", RegexOptions.Compiled);

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
            catch (Exception ex)
            {
                return result;
            }
            return true;
        }
    }
}
