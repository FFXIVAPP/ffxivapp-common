// FFXIVAPP.Common
// Constants.cs
// 
// Copyright © 2007 - 2014 Ryan Wilson - All Rights Reserved
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
using System.IO;
using FFXIVAPP.Common.Helpers;

namespace FFXIVAPP.Common
{
    public static class Constants
    {
        public const string AppPack = "pack://application:,,,/FFXIVAPP.Client;component/";
        public const string DefaultIcon = AppPack + "Resources/Media/Images/DefaultIcon.jpg";
        public const string DefaultAvatar = AppPack + "Resources/Media/Images/DefaultAvatar.jpg";

        public static readonly FlowDocHelper FD = new FlowDocHelper();

        public static string CachePath
        {
            get
            {
                try
                {
                    var location = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    return Path.Combine(location, "FFXIVAPP");
                }
                catch
                {
                    return "./";
                }
            }
        }

        #region Directories

        public static string ConfigurationsPath
        {
            get { return Path.Combine(CachePath, "Configurations"); }
        }

        public static string LogsPath
        {
            get { return Path.Combine(CachePath, "Logs"); }
        }

        public static string ScreenShotsPath
        {
            get { return Path.Combine(CachePath, "ScreenShots"); }
        }

        public static string SoundsPath
        {
            get { return Path.Combine(CachePath, "Sounds"); }
        }

        public static string SettingsPath
        {
            get { return Path.Combine(CachePath, "Settings"); }
        }

        public static string PluginsSettingsPath
        {
            get { return Path.Combine(CachePath, "Settings", "Plugins"); }
        }

        #endregion

        #region Auto-Properties MAIN APPLICATION

        public static bool EnableNLog { get; set; }

        public static Guid DefaultAudioDevice { get; set; }

        #endregion
    }
}
