// FFXIVAPP.Common ~ IConstantsEntity.cs
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

namespace FFXIVAPP.Common.Core.Constant.Interfaces
{
    public interface IConstantsEntity
    {
        string Theme { get; set; }
        string UIScale { get; set; }
        Dictionary<string, string> AutoTranslate { get; set; }
        Dictionary<string, string> ChatCodes { get; set; }
        string ChatCodesXML { get; set; }
        Dictionary<string, string[]> Colors { get; set; }
        CultureInfo CultureInfo { get; set; }
        string CharacterName { get; set; }
        string ServerName { get; set; }
        string GameLanguage { get; set; }
        bool EnableHelpLabels { get; set; }
        bool EnableNLog { get; set; }
        bool EnableNetworkReading { get; set; }
    }
}
