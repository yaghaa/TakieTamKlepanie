using System.Collections.Generic;

namespace SchedulingAccessToCPU.Interfaces
{
    public interface ISchedulingAlgorithm
    {
        SimulationResult Simulation(Queue<Process> queueProcesses , List<Process> listProcesses);

    }
}