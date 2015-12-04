// FFXIVAPP.Common ~ SoundPlayerHelper.cs
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using FFXIVAPP.Common.Audio;
using FFXIVAPP.Common.RegularExpressions;
using FFXIVAPP.Common.Utilities;
using NLog;

namespace FFXIVAPP.Common.Helpers
{
    public static class SoundPlayerHelper
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        public static bool PlayCached(string soundFile, int volume = 100)
        {
            var success = true;
            var fileName = Regex.Replace(soundFile, @"[\\/]+", "\\", SharedRegEx.DefaultOptions);
            try
            {
                CachedSound value;
                if (!SoundFiles.TryGetValue(fileName, out value))
                {
                    value = TryGetSetSoundFile(fileName, volume);
                }
                AudioPlaybackEngine.Instance.PlaySound(value, volume);
            }
            catch (Exception ex)
            {
                Logging.Log(Logger, "", ex);
                success = false;
            }
            return success;
        }

        /// <summary>
        /// </summary>
        public static void CacheSoundFiles()
        {
            try
            {
                if (!Directory.Exists(Constants.SoundsPath))
                {
                    Directory.CreateDirectory(Constants.SoundsPath);
                }
                var soundFiles = new List<FileInfo>();
                var filters = new List<string>
                {
                    "*.wav",
                    "*.mp3"
                };
                foreach (var filter in filters)
                {
                    var files = Directory.GetFiles(Constants.SoundsPath, filter, SearchOption.AllDirectories)
                                         .Select(file => new FileInfo(file));
                    soundFiles.AddRange(files);
                }
                Func<bool> cacheSoundsFunc = delegate
                {
                    foreach (var soundFile in soundFiles)
                    {
                        if (soundFile.DirectoryName == null)
                        {
                            continue;
                        }
                        var baseKey = soundFile.DirectoryName.Replace(Constants.SoundsPath, "");
                        var key = String.IsNullOrWhiteSpace(baseKey) ? soundFile.Name : String.Format("{0}\\{1}", baseKey.Substring(1), soundFile.Name);
                        if (SoundFileKeys(false)
                            .Contains(key))
                        {
                            continue;
                        }
                        TryGetSetSoundFile(key);
                    }
                    return true;
                };
                cacheSoundsFunc.BeginInvoke(null, null);
            }
            catch (Exception ex)
            {
                Logging.Log(Logger, "", ex);
            }
        }

        #region SoundFiles Storage - Getters & Setters

        private static readonly Dictionary<string, CachedSound> SoundFiles = new Dictionary<string, CachedSound>();

        /// <summary>
        /// </summary>
        /// <param name="refreshCache"></param>
        /// <returns></returns>
        public static List<string> SoundFileKeys(bool refreshCache = true)
        {
            if (refreshCache)
            {
                CacheSoundFiles();
            }
            lock (SoundFiles)
            {
                if (SoundFiles.Any())
                {
                    return SoundFiles.Select(soundFile => soundFile.Key)
                                     .OrderBy(key => key)
                                     .ToList();
                }
                return new List<string>();
            }
        }

        public static CachedSound TryGetSetSoundFile(string soundFile, int volume = 100)
        {
            var fileName = Regex.Replace(soundFile, @"[\\/]+", "\\", SharedRegEx.DefaultOptions);
            lock (SoundFiles)
            {
                try
                {
                    CachedSound value;
                    if (SoundFiles.TryGetValue(fileName, out value))
                    {
                        return value;
                    }
                    value = new CachedSound(Path.Combine(Constants.SoundsPath, fileName));
                    SoundFiles.Add(fileName, value);
                    return value;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        #endregion
    }
}
