// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantsEntity.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ConstantsEntity.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Core.Constant {
    using System.Collections.Generic;
    using System.Globalization;

    using FFXIVAPP.Common.Core.Constant.Interfaces;

    public class ConstantsEntity : IConstantsEntity {
        public Dictionary<string, string> AutoTranslate { get; set; }

        public string CharacterName { get; set; }

        public Dictionary<string, string> ChatCodes { get; set; }

        public string ChatCodesXML { get; set; }

        public Dictionary<string, string[]> Colors { get; set; }

        public CultureInfo CultureInfo { get; set; }

        public bool EnableHelpLabels { get; set; }

        public bool EnableNetworkReading { get; set; }

        public bool EnableNLog { get; set; }

        public string GameLanguage { get; set; }

        public string GameRegion { get; set; }

        public string ServerName { get; set; }

        public string Theme { get; set; }

        public string UIScale { get; set; }
    }
}