using System.Globalization;

namespace SchedulingAccessToCPU
{
    public class Process
    {
        public string ProcessNumber { get; set; }
        public int CpuPhaseLength { get; set; }
        public int EntryTime { get; set; }
        public int WaitingTime { get; set; }
        

        public Process(string processNumber, int cpuPhaseLength, int entryTime, int waitingTime)
        {
            ProcessNumber = processNumber;
            CpuPhaseLength = cpuPhaseLength;
            EntryTime = entryTime;
            WaitingTime = waitingTime;
        }

        public override string ToString()
        {
            return ProcessNumber + " \n" + CpuPhaseLength + " \n" + EntryTime + " \n" + WaitingTime + " \n";
        }
    }
}