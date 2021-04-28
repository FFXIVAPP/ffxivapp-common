// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThemeHelper.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ThemeHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Helpers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;

    using MahApps.Metro;
    using MahApps.Metro.Controls;

    using NLog;

    public static class ThemeHelper {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// </summary>
        /// <param name="theme"> </param>
        /// <param name="window"></param>
        public static void ChangeTheme(string theme, List<MetroWindow> window) {
            try {
                if (window == null || !window.Any()) {
                    Apply(theme, Application.Current.MainWindow);
                    return;
                }

                foreach (MetroWindow metroWindow in window.Where(metroWindow => metroWindow != null)) {
                    Apply(theme, metroWindow);
                }
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="t"></param>
        /// <param name="window"></param>
        private static void Apply(string theme, Window window) {
            string[] split = theme.Split('|');
            var accent = split[0];
            var shade = split[1];
            ThemeManager.ChangeAppStyle(window, ThemeManager.Accents.First(a => a.Name == accent), ThemeManager.AppThemes.First(t => t.Name == "Base" + shade));
        }
    }
}