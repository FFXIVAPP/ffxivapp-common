// FFXIVAPP.Common ~ ActionInfo.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
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

using FFXIVAPP.Common.Core.Constant.Interfaces;

namespace FFXIVAPP.Common.Core.Constant
{
    public class ActionInfo : IActionInfo
    {
        public string KO { get; set; }
        public string KO_HelpLabel { get; set; }
        public string ZH { get; set; }
        public string JA { get; set; }
        public string EN { get; set; }
        public string FR { get; set; }
        public string DE { get; set; }
        public string ZH_HelpLabel { get; set; }
        public string JA_HelpLabel { get; set; }
        public string EN_HelpLabel { get; set; }
        public string FR_HelpLabel { get; set; }
        public string DE_HelpLabel { get; set; }
    }
}
