using System;
using System.Collections.Generic;

namespace SchedulingAccessToCPU
{
    public class SimulationResult
    {
        public double AverageWaitingTime { get; set; } 
        public List<Process> CompleteProcessList { get; set; }

        public void ShowAllCompleteProcesses()
        {
            foreach (var proces in CompleteProcessList)
            {
                Console.WriteLine("Numer procesu:               "+ proces.ProcessNumber);
                Console.WriteLine("Długość fazy procesora:      "+ proces.CpuPhaseLength);
                Console.WriteLine("Czas zgłoszenia się procesu: "+ proces.EntryTime);
                Console.WriteLine("Czas oczekiwania procesu:    "+ proces.WaitingTime);
                Console.WriteLine("---------------------------------");
            }
        }
    }
}