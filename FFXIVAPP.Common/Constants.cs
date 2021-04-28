// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Constants.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common {
    using System;
    using System.IO;

    using FFXIVAPP.Common.Helpers;

    public static class Constants {
        public static readonly FlowDocHelper FD = new FlowDocHelper();

        public static string CachePath {
            get {
                try {
                    var location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    return Path.Combine(location, "FFXIVAPP");
                }
                catch {
                    return "./";
                }
            }
        }

        public static string ConfigurationsPath {
            get {
                return Path.Combine(CachePath, "Configurations");
            }
        }

        public static Guid DefaultAudioDevice { get; set; }

        public static bool EnableNetworkReading { get; set; }

        public static bool EnableNLog { get; set; }

        public static string LogsPath {
            get {
                return Path.Combine(CachePath, "Logs");
            }
        }

        public static string PluginsSettingsPath {
            get {
                return Path.Combine(CachePath, "Settings", "Plugins");
            }
        }

        public static string ScreenShotsPath {
            get {
                return Path.Combine(CachePath, "ScreenShots");
            }
        }

        public static string SettingsPath {
            get {
                return Path.Combine(CachePath, "Settings");
            }
        }

        public static string SoundsPath {
            get {
                return Path.Combine(CachePath, "Sounds");
            }
        }
    }
}