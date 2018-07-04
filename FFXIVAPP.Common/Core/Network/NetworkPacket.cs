// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkPacket.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   NetworkPacket.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Core.Network {
    using System;

    using FFXIVAPP.Common.Core.Network.Interfaces;

    public class NetworkPacket : INetworkPacket {
        public byte[] Buffer { get; set; }

        public int CurrentPosition { get; set; }

        public uint Key { get; set; }

        public int MessageSize { get; set; }

        public DateTime PacketDate { get; set; }
    }
}