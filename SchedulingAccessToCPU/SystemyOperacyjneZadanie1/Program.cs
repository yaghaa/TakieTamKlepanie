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

            var queueProcess2 = SchedulingAlgorithmHelper.CopyProcessQueue(queueProcess);
            var listProcess2 = SchedulingAlgorithmHelper.CopyProcessList(listProcess);

            var queueProcess3 = SchedulingAlgorithmHelper.CopyProcessQueue(queueProcess);
            var listProcess3 = SchedulingAlgorithmHelper.CopyProcessList(listProcess);

            var queueProcess4 = SchedulingAlgorithmHelper.CopyProcessQueue(queueProcess);
            var listProcess4 = SchedulingAlgorithmHelper.CopyProcessList(listProcess);

          //  SchedulingAlgorithmHelper.ShowQueue(queueProcess);
          //  SchedulingAlgorithmHelper.ShowQueue(queueProcess2);
          //  SchedulingAlgorithmHelper.ShowQueue(queueProcess3);
            
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

            // ---------- RR dla danych testList1 ----------
            SchedulingAlgorithmRR RR = new SchedulingAlgorithmRR();
            var resultRR = RR.Simulation(queueProcess4, listProcess4);
            Console.WriteLine("RR");
            Console.WriteLine("Średni czas oczekiwania:       " + resultRR.AverageWaitingTime);
            Console.WriteLine("Ilość przetworzonych procesów: " + resultRR.CompleteProcessList.Count);
            Console.WriteLine();
            //resultRR.ShowAllCompleteProcesses();


            Console.ReadKey();
        }
    }
}
