// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopupContent.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   PopupContent.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Models {
    public class PopupContent {
        private string _message;

        private string _pluginName;

        private string _title;

        public bool CanCancel { get; set; }

        public string Message {
            get {
                const string message = "This message was not set by the developer.";
                return string.IsNullOrWhiteSpace(this._message)
                           ? message
                           : this._message;
            }

            set {
                this._message = value;
            }
        }

        public string PluginName {
            get {
                return string.IsNullOrWhiteSpace(this._pluginName)
                           ? "UnknownPlugin"
                           : this._pluginName;
            }

            set {
                this._pluginName = value;
            }
        }

        public string Title {
            get {
                const string title = "Undefined!";
                return string.IsNullOrWhiteSpace(this._title)
                           ? title
                           : this._title;
            }

            set {
                this._title = value;
            }
        }
    }
}