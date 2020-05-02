// --------------------------------------------------------------------------------------------------------------------
// <copyright file="xFlowDocument.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   xFlowDocument.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Controls {
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    ///     Interaction logic for xFlowDocument.xaml
    /// </summary>
    public partial class xFlowDocument : INotifyPropertyChanged {
        private string _zoomLevel;

        public xFlowDocument() {
            this.InitializeComponent();
            this.ZoomLevel = "100";
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string ZoomLevel {
            get {
                return this._zoomLevel;
            }

            set {
                this._zoomLevel = value;
                this.RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName,] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}