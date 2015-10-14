using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingAccessToCPU;

namespace SystemyOperacyjneZadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var simulationData = SchedulingAlgorithmHelper.PrepareSimulationData();
            var queueProcess = simulationData.QueueProcess;
            var listProcess = simulationData.ListProcess;

            var queueProcess2 = SchedulingAlgorithmHelper.copyProcessQueue(queueProcess);
            var listProcess2 = listProcess.ToList();

            var queueProcess3 = SchedulingAlgorithmHelper.copyProcessQueue(queueProcess);
            var listProcess3 = listProcess.ToList();
            
            // ---------- FCFS dla danych testList1 ----------
            SchedulingAlgorithmFCFS FCDS = new SchedulingAlgorithmFCFS();
            var resultFCDS = FCDS.Simulation(queueProcess, listProcess);
            Console.WriteLine("FCDS");
            Console.WriteLine("Średni czas oczekiwania:       " + resultFCDS.AverageWaitingTime);
            Console.WriteLine("Ilość przetworzonych procesów: " + resultFCDS.CompleteProcessList.Count);
            Console.WriteLine();
            //resultFCDS.ShowAllCompleteProcesses();

            // ---------- SJF dla danych testList1 ----------
            SchedulingAlgorithmSJF SJF = new SchedulingAlgorithmSJF();
            var resultSJF = SJF.Simulation(queueProcess2, listProcess2);
            Console.WriteLine("SJF");
            Console.WriteLine("Średni czas oczekiwania:       " + resultSJF.AverageWaitingTime);
            Console.WriteLine("Ilość przetworzonych procesów: " + resultSJF.CompleteProcessList.Count);
            Console.WriteLine();
            //resultSJF.ShowAllCompleteProcesses();

            // ---------- SRTF dla danych testList1 ----------
            SchedulingAlgorithmSRTF SRTF = new SchedulingAlgorithmSRTF();
            var resultSRTF = SRTF.Simulation(queueProcess3, listProcess3);
            Console.WriteLine("SRTF");
            Console.WriteLine("Średni czas oczekiwania:       " + resultSRTF.AverageWaitingTime);
            Console.WriteLine("Ilość przetworzonych procesów: " + resultSRTF.CompleteProcessList.Count);
            Console.WriteLine();
            //resultSRTF.ShowAllCompleteProcesses();

            Console.ReadKey();
        }
    }
}
