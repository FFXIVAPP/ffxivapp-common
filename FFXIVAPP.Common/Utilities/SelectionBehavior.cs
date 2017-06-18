// FFXIVAPP.Common ~ SelectionBehavior.cs
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace FFXIVAPP.Common.Utilities
{
    public class SelectionBehavior
    {
        public static readonly DependencyProperty SelectionChangedProperty = DependencyProperty.RegisterAttached("SelectionChanged", typeof(ICommand), typeof(SelectionBehavior), new UIPropertyMetadata(SelectedItemChanged));

        /// <summary>
        /// </summary>
        /// <param name="target"> </param>
        /// <param name="value"> </param>
        public static void SetSelectionChanged(DependencyObject target, ICommand value)
        {
            target.SetValue(SelectionChangedProperty, value);
        }

        /// <summary>
        /// </summary>
        /// <param name="target"> </param>
        /// <param name="e"> </param>
        private static void SelectedItemChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var element = target as Selector;
            if (element == null)
            {
                throw new InvalidOperationException("This behavior can be attached to Selector item only.");
            }
            if ((e.NewValue != null) && (e.OldValue == null))
            {
                element.SelectionChanged += SelectionChanged;
            }
            else if ((e.NewValue == null) && (e.OldValue != null))
            {
                element.SelectionChanged -= SelectionChanged;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private static void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var element = (UIElement) sender;
            var command = (ICommand) element.GetValue(SelectionChangedProperty);
            command.Execute(((Selector) sender).SelectedValue);
        }
    }
}
