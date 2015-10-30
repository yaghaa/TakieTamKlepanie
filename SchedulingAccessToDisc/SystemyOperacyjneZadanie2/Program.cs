using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingAccessToDisc;

namespace SystemyOperacyjneZadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            var simulationDataCreator = new SchedulingAccessToDisc.Models.SimulationData();
            var simulationData = simulationDataCreator.CreateArrayOfCommissionList(100);

            
           // var simulationData2 = simulationDataCreator.CopyArrayOfCommissionList(simulationData);
            var simulationData3 = simulationDataCreator.CopyArrayOfCommissionList(simulationData);
            var simulationData4 = simulationDataCreator.CopyArrayOfCommissionList(simulationData);

            // ---------- FCFS dla danych testList1 ----------
            DiscSchedulingAlgorithmFCFS FCFS = new DiscSchedulingAlgorithmFCFS();
            var resultFCFS = FCFS.Simulation(simulationData);
            Console.WriteLine("FCFS");
            Console.WriteLine("Ilość przemieszczeń głowicy:   " + resultFCFS.DisplacementHeadSum);
            Console.WriteLine("Ilość przetworzonych procesów: " + resultFCFS.CompleteCommissionList.Count);
            Console.WriteLine();

            // ---------- SCAN dla danych testList1 ----------
            DiscSchedulingAlgorithmSCAN SCAN = new DiscSchedulingAlgorithmSCAN();
            var resultSCAN = SCAN.Simulation(simulationData3);
            Console.WriteLine("SCAN");
            Console.WriteLine("Ilość przemieszczeń głowicy:   " + resultSCAN.DisplacementHeadSum);
            Console.WriteLine("Ilość przetworzonych procesów: " + resultSCAN.CompleteCommissionList.Count);
            Console.WriteLine();

            // ---------- C-SCAN dla danych testList1 ----------
            DiscSchedulingAlgorithmSCAN CSCAN = new DiscSchedulingAlgorithmSCAN();
            var resultCSCAN = CSCAN.Simulation(simulationData4);
            Console.WriteLine("C-SCAN");
            Console.WriteLine("Ilość przemieszczeń głowicy:   " + resultCSCAN.DisplacementHeadSum);
            Console.WriteLine("Ilość przetworzonych procesów: " + resultCSCAN.CompleteCommissionList.Count);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
