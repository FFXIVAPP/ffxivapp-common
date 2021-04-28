// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopupResultEvent.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   PopupResultEvent.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Events {
    using System;

    public class PopupResultEvent : EventArgs {
        public PopupResultEvent(object newValue) {
            this.NewValue = newValue;
        }

        public object NewValue { get; private set; }
    }
}