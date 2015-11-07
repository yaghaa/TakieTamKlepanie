using System.Collections.Generic;
using SchedulingAccessToDisc.Models;

namespace SchedulingAccessToDisc.Interfaces
{
    public interface IDiscSchedulingAlgorithm
    {
        SimulationResult Simulation(List<Commission>[] commissionArray, int discSize); 
    }
}