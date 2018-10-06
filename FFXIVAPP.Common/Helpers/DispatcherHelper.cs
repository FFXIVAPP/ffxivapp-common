// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DispatcherHelper.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   DispatcherHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Helpers {
    using System;
    using System.Threading;
    using System.Windows;
    using Avalonia.Threading;

    public static class DispatcherHelper {
        public static void Invoke(Action action, DispatcherPriority dispatcherPriority = DispatcherPriority.Background) {
            DispatcherTimer.RunOnce(() => { action(); }, new TimeSpan(0), dispatcherPriority);
        }
    }
}
