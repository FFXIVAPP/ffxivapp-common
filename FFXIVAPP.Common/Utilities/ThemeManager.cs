// FFXIVAPP.Common
// ThemeManager.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MahApps.Metro;

namespace FFXIVAPP.Common.Utilities
{
    public static class ThemeManager
    {
        private static readonly ResourceDictionary LightResource = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml")
        };

        private static readonly ResourceDictionary DarkResource = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseDark.xaml")
        };

        private static IEnumerable<Accent> _defaultAccents;

        public static IEnumerable<Accent> DefaultAccents
        {
            get
            {
                if (_defaultAccents == null)
                {
                    var accents = new[]
                    {
                        "Red", "Green", "Blue", "Purple", "Orange", "Brown", "Cobalt", "Crimson", "Cyan", "Emerald", "Indigo", "Magenta", "Mauve", "Olive", "Sienna", "Steel", "Teal", "Violet", "Amber", "Yellow", "Lime", "Pink"
                    };
                    const string path = "pack://application:,,,/MahApps.Metro;component/Styles/Accents/{0}.xaml";
                    _defaultAccents = accents.Select(accent => new Accent(accent, new Uri(String.Format(path, accent))))
                                             .ToList();
                }
                return _defaultAccents;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="application"> </param>
        /// <param name="accent"> </param>
        /// <param name="theme"> </param>
        public static void ChangeTheme(Application application, Accent accent, Theme theme)
        {
            ChangeTheme(application.Resources, accent, theme);
        }

        /// <summary>
        /// </summary>
        /// <param name="window"> </param>
        /// <param name="accent"> </param>
        /// <param name="theme"> </param>
        public static void ChangeTheme(Window window, Accent accent, Theme theme)
        {
            ChangeTheme(window.Resources, accent, theme);
        }

        /// <summary>
        /// </summary>
        /// <param name="dictionary"> </param>
        /// <param name="accent"> </param>
        /// <param name="theme"> </param>
        public static void ChangeTheme(ResourceDictionary dictionary, Accent accent, Theme theme)
        {
            var themeResource = (theme == Theme.Light) ? LightResource : DarkResource;
            ApplyResourceDictionary(themeResource, dictionary);
            ApplyResourceDictionary(accent.Resources, dictionary);
        }

        /// <summary>
        /// </summary>
        /// <param name="newDictionary"> </param>
        /// <param name="oldDictionary"> </param>
        private static void ApplyResourceDictionary(IEnumerable newDictionary, IDictionary oldDictionary)
        {
            foreach (DictionaryEntry entry in newDictionary)
            {
                if (oldDictionary.Contains(entry.Key))
                {
                    oldDictionary.Remove(entry.Key);
                }
                oldDictionary.Add(entry.Key, entry.Value);
            }
        }
    }
}
