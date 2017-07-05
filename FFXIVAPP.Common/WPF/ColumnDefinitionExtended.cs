// FFXIVAPP.Common ~ ColumnDefinitionExtended.cs
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

namespace FFXIVAPP.Common.WPF
{
    public class ColumnDefinitionExtended : ColumnDefinition
    {
        // Variables
        public static DependencyProperty VisibleProperty;
        // Properties

        // Constructors
        static ColumnDefinitionExtended()
        {
            VisibleProperty = DependencyProperty.Register("Visible", typeof(Boolean), typeof(ColumnDefinitionExtended), new PropertyMetadata(true, OnVisibleChanged));

            WidthProperty.OverrideMetadata(typeof(ColumnDefinitionExtended), new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star), null, CoerceWidth));

            MinWidthProperty.OverrideMetadata(typeof(ColumnDefinitionExtended), new FrameworkPropertyMetadata((Double) 0, null, CoerceMinWidth));
        }

        public Boolean Visible
        {
            get { return (Boolean) GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        // Get/Set
        public static void SetVisible(DependencyObject obj, Boolean nVisible)
        {
            obj.SetValue(VisibleProperty, nVisible);
        }

        public static Boolean GetVisible(DependencyObject obj)
        {
            return (Boolean) obj.GetValue(VisibleProperty);
        }

        private static void OnVisibleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            obj.CoerceValue(WidthProperty);
            obj.CoerceValue(MinWidthProperty);
        }

        private static Object CoerceWidth(DependencyObject obj, Object nValue)
        {
            return ((ColumnDefinitionExtended) obj).Visible ? nValue : new GridLength(0);
        }

        private static Object CoerceMinWidth(DependencyObject obj, Object nValue)
        {
            return ((ColumnDefinitionExtended) obj).Visible ? nValue : (Double) 0;
        }
    }
}
