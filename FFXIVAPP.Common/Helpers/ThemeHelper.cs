// FFXIVAPP.Common ~ ThemeHelper.cs
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FFXIVAPP.Common.Models;
using FFXIVAPP.Common.Utilities;
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
                Logging.Log(Logger, new LogItem(ex, true));
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
            ThemeManager.ChangeAppStyle(window, ThemeManager.Accents.First(a => a.Name == accent), ThemeManager.AppThemes.First(t => t.Name == "Base" + shade));
        }
    }
}
