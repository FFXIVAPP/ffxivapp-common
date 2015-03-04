using System;
using FFXIVAPP.Common.Core.Memory.Interfaces;

namespace FFXIVAPP.Common.Core.Memory
{
    public class ItemDesc
    {
       
        public uint ID { get; set; }
        public uint Offset { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

    }
}
