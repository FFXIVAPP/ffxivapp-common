// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConstantsEntity.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   IConstantsEntity.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Core.Constant.Interfaces {
    using System.Collections.Generic;
    using System.Globalization;

    public interface IConstantsEntity {
        Dictionary<string, string> AutoTranslate { get; set; }

        string CharacterName { get; set; }

        Dictionary<string, string> ChatCodes { get; set; }

        string ChatCodesXML { get; set; }

        Dictionary<string, string[]> Colors { get; set; }

        CultureInfo CultureInfo { get; set; }

        bool EnableHelpLabels { get; set; }

        bool EnableNetworkReading { get; set; }

        bool EnableNLog { get; set; }

        string GameLanguage { get; set; }

        string ServerName { get; set; }

        string Theme { get; set; }

        string UIScale { get; set; }
    }
}