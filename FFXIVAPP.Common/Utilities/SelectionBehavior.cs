﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectionBehavior.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   SelectionBehavior.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/* TODO: SelectionBehavior
namespace FFXIVAPP.Common.Utilities {
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;

    public class SelectionBehavior {
        public static readonly DependencyProperty SelectionChangedProperty = DependencyProperty.RegisterAttached("SelectionChanged", typeof(ICommand), typeof(SelectionBehavior), new UIPropertyMetadata(SelectedItemChanged));

        /// <summary>
        /// </summary>
        /// <param name="target"> </param>
        /// <param name="value"> </param>
        public static void SetSelectionChanged(DependencyObject target, ICommand value) {
            target.SetValue(SelectionChangedProperty, value);
        }

        /// <summary>
        /// </summary>
        /// <param name="target"> </param>
        /// <param name="e"> </param>
        private static void SelectedItemChanged(DependencyObject target, DependencyPropertyChangedEventArgs e) {
            var element = target as Selector;
            if (element == null) {
                throw new InvalidOperationException("This behavior can be attached to Selector item only.");
            }

            if (e.NewValue != null && e.OldValue == null) {
                element.SelectionChanged += SelectionChanged;
            }
            else if (e.NewValue == null && e.OldValue != null) {
                element.SelectionChanged -= SelectionChanged;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private static void SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var element = (UIElement) sender;
            var command = (ICommand) element.GetValue(SelectionChangedProperty);
            command.Execute(((Selector) sender).SelectedValue);
        }
    }
}
*/