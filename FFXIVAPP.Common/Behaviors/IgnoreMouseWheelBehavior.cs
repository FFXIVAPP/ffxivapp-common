// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IgnoreMouseWheelBehavior.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   IgnoreMouseWheelBehavior.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Behaviors {
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interactivity;

    public class IgnoreMouseWheelBehavior : Behavior<UIElement> {
        protected override void OnAttached() {
            base.OnAttached();
            this.AssociatedObject.PreviewMouseWheel += this.AssociatedObjectPreviewMouseWheel;
        }

        protected override void OnDetaching() {
            this.AssociatedObject.PreviewMouseWheel -= this.AssociatedObjectPreviewMouseWheel;
            base.OnDetaching();
        }

        private void AssociatedObjectPreviewMouseWheel(object sender, MouseWheelEventArgs e) {
            e.Handled = true;

            var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            e2.RoutedEvent = UIElement.MouseWheelEvent;

            this.AssociatedObject.RaiseEvent(e2);
        }
    }
}