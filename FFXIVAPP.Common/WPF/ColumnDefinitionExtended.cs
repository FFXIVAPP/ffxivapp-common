// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnDefinitionExtended.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ColumnDefinitionExtended.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.WPF {
    using System.Windows;
    using System.Windows.Controls;

    public class ColumnDefinitionExtended : ColumnDefinition {
        // Variables
        public static DependencyProperty VisibleProperty;

        // Properties

        // Constructors
        static ColumnDefinitionExtended() {
            VisibleProperty = DependencyProperty.Register("Visible", typeof(bool), typeof(ColumnDefinitionExtended), new PropertyMetadata(true, OnVisibleChanged));

            WidthProperty.OverrideMetadata(typeof(ColumnDefinitionExtended), new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star), null, CoerceWidth));

            MinWidthProperty.OverrideMetadata(typeof(ColumnDefinitionExtended), new FrameworkPropertyMetadata((double) 0, null, CoerceMinWidth));
        }

        public bool Visible {
            get {
                return (bool) this.GetValue(VisibleProperty);
            }

            set {
                this.SetValue(VisibleProperty, value);
            }
        }

        public static bool GetVisible(DependencyObject obj) {
            return (bool) obj.GetValue(VisibleProperty);
        }

        // Get/Set
        public static void SetVisible(DependencyObject obj, bool nVisible) {
            obj.SetValue(VisibleProperty, nVisible);
        }

        private static object CoerceMinWidth(DependencyObject obj, object nValue) {
            return ((ColumnDefinitionExtended) obj).Visible
                       ? nValue
                       : (double) 0;
        }

        private static object CoerceWidth(DependencyObject obj, object nValue) {
            return ((ColumnDefinitionExtended) obj).Visible
                       ? nValue
                       : new GridLength(0);
        }

        private static void OnVisibleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e) {
            obj.CoerceValue(WidthProperty);
            obj.CoerceValue(MinWidthProperty);
        }
    }
}