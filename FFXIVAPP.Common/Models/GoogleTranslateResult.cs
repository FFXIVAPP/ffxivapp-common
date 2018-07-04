// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleTranslateResult.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   GoogleTranslateResult.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Models {
    public class GoogleTranslateResult {
        public string Original { get; set; }

        public string Romanization { get; set; }

        public string Translated { get; set; }
    }
}