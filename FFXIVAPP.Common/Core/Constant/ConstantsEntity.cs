// FFXIVAPP.Common ~ ConstantsEntity.cs
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

using System.Collections.Generic;
using System.Globalization;
using FFXIVAPP.Common.Core.Constant.Interfaces;

namespace FFXIVAPP.Common.Core.Constant
{
    public class ConstantsEntity : IConstantsEntity
    {
        public string Theme { get; set; }
        public string UIScale { get; set; }
        public Dictionary<string, string> AutoTranslate { get; set; }
        public Dictionary<string, string> ChatCodes { get; set; }
        public Dictionary<string, ActionInfo> Actions { get; set; }
        public string ChatCodesXml { get; set; }
        public Dictionary<string, string[]> Colors { get; set; }
        public CultureInfo CultureInfo { get; set; }
        public string CharacterName { get; set; }
        public string ServerName { get; set; }
        public string GameLanguage { get; set; }
        public bool EnableHelpLabels { get; set; }
        public bool EnableNLog { get; set; }
        public bool EnableNetworkReading { get; set; }
    }
}
