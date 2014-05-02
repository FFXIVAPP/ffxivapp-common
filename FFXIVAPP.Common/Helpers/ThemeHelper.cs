// FFXIVAPP.Common
// ThemeHelper.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MahApps.Metro;
using MahApps.Metro.Controls;
using NLog;

namespace FFXIVAPP.Common.Helpers
{
    public static class ThemeHelper
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="theme"> </param>
        /// <param name="window"></param>
        public static void ChangeTheme(string theme, List<MetroWindow> window)
        {
            try
            {
                if (window == null || !window.Any())
                {
                    Apply(theme, Application.Current.MainWindow);
                    return;
                }
                foreach (var metroWindow in window.Where(metroWindow => metroWindow != null))
                {
                    Apply(theme, metroWindow);
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="t"></param>
        /// <param name="window"></param>
        private static void Apply(string theme, Window window)
        {
            var split = theme.Split('|');
            var accent = split[0];
            var shade = split[1];
            switch (shade)
            {
                case "Dark":
                    ThemeManager.ChangeTheme(window, ThemeManager.DefaultAccents.First(a => a.Name == accent), Theme.Dark);
                    break;
                case "Light":
                    ThemeManager.ChangeTheme(window, ThemeManager.DefaultAccents.First(a => a.Name == accent), Theme.Light);
                    break;
            }
        }
    }
}
