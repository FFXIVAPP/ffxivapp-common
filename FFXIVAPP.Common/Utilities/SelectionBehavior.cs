// FFXIVAPP.Common
// SelectionBehavior.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace FFXIVAPP.Common.Utilities
{
    public class SelectionBehavior
    {
        public static readonly DependencyProperty SelectionChangedProperty = DependencyProperty.RegisterAttached("SelectionChanged", typeof (ICommand), typeof (SelectionBehavior), new UIPropertyMetadata(SelectedItemChanged));

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
