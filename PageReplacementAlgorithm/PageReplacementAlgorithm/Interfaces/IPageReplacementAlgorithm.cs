using System.Collections.Generic;

namespace PageReplacementAlgorithm.Interfaces
{
    public interface IPageReplacementAlgorithm
    {
        int Simulation(int physicalMemorySize, int logicalMemorySize, List<int> pageReferenceSequence);
    }
}