// FFXIVAPP.Common
// SoundPlayerHelper.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
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
    }
}
