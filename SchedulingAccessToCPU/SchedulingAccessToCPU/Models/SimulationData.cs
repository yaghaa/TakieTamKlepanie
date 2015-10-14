using System.Collections.Generic;

namespace SchedulingAccessToCPU
{
    public class SimulationData
    {
        public Queue<Process> QueueProcess { get; set; }
        public List<Process> ListProcess { get; set; }
    }
}