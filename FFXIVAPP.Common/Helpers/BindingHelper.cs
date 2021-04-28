// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BindingHelper.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   BindingHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Helpers {
    using System.Windows;
    using System.Windows.Data;

    using FFXIVAPP.Common.Converters;

    public static class BindingHelper {
        /// <summary>
        /// </summary>
        /// <param name="source"> </param>
        /// <param name="path"> </param>
        /// <returns> </returns>
        public static Binding VisibilityBinding(object source, string path) {
            var binding = new Binding("Visibility");
            binding.Converter = new VisibilityConverter();
            binding.Source = source;
            binding.Path = new PropertyPath(path);
            binding.Mode = BindingMode.TwoWay;
            return binding;
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static Binding ZoomBinding(object source, string path) {
            var binding = new Binding();
            binding.Source = source;
            binding.Path = new PropertyPath(path);
            binding.Mode = BindingMode.TwoWay;
            return binding;
        }
    }
}