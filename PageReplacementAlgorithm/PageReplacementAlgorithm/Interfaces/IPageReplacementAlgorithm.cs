using System.Collections.Generic;

namespace PageReplacementAlgorithm.Interfaces
{
    public interface IPageReplacementAlgorithm
    {
        int Simulation(List<int> odwolania, int[] pamiec );
    }
}