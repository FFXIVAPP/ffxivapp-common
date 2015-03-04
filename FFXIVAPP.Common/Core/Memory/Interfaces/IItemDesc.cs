using System;
namespace FFXIVAPP.Common.Core.Memory.Interfaces
{
    public interface IItemDesc
    {
        uint ID { get; set; }
        uint Offset { get; set; }
        String Name { get; set; }
        String Description { get; set; }
    }
}
