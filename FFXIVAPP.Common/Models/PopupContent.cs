// FFXIVAPP.Common ~ PopupContent.cs
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

using System;

namespace FFXIVAPP.Common.Models
{
    public class PopupContent
    {
        private string _message;
        private string _pluginName;
        private string _title;

        public string PluginName
        {
            get { return (String.IsNullOrWhiteSpace(_pluginName) ? "UnknownPlugin" : _pluginName); }
            set { _pluginName = value; }
        }

        public string Title
        {
            get
            {
                const string title = "Undefined!";
                return (String.IsNullOrWhiteSpace(_title) ? title : _title);
            }
            set { _title = value; }
        }

        public string Message
        {
            get
            {
                const string message = "This message was not set by the developer.";
                return (String.IsNullOrWhiteSpace(_message) ? message : _message);
            }
            set { _message = value; }
        }

        public bool CanCancel { get; set; }
    }
}
