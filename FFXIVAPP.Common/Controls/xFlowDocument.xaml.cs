// FFXIVAPP.Common ~ xFlowDocument.xaml.cs
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

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FFXIVAPP.Common.Controls
{
    /// <summary>
    ///     Interaction logic for xFlowDocument.xaml
    /// </summary>
    public partial class xFlowDocument : INotifyPropertyChanged
    {
        public xFlowDocument()
        {
            InitializeComponent();
            ZoomLevel = "100";
        }

        #region Property Bindings

        private string _zoomLevel;

        public string ZoomLevel
        {
            get { return _zoomLevel; }
            set
            {
                _zoomLevel = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion
    }
}
