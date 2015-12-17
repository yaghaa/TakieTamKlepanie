using System.Collections.Generic;

namespace FramesDispenser.Interfaces
{
    public interface IDispenser
    {
        List<int> CreateOperationMemory(List<List<int>> odwolania,int rameczki);
    }
}