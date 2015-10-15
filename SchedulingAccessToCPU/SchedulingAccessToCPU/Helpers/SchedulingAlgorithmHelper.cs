using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulingAccessToCPU
{
    public class SchedulingAlgorithmHelper
    {
        public static SimulationData PrepareSimulationData()
        {
            ProcessList testData = new ProcessList();
            var listProcess = testData.CreateProcessList(40);

            Queue<Process> queueProcess = new Queue<Process>();

            for (int i = 0; i < listProcess.Count / 2; i++)
            {
                queueProcess.Enqueue(listProcess[i]);
            }
            listProcess = listProcess.GetRange(listProcess.Count / 2, listProcess.Count / 2);

            var time = 0;
            Random timeRandom = new Random();
            foreach (var process in listProcess)
            {
                process.EntryTime = timeRandom.Next(1, 10)+time;
                time = process.EntryTime;
            }

            return new SimulationData() { QueueProcess = queueProcess, ListProcess = listProcess };
        }

        public static Queue<Process> SortQueue(Queue<Process> queueProcess)
        {
            var tempList = queueProcess.ToList();
            var tempList2 = tempList.OrderBy(process => process.CpuPhaseLength);

            var queueResult = new Queue<Process>();
            foreach (var process in tempList2)
            {
                queueResult.Enqueue(process);
            }
            return queueResult;
        }

        public static Queue<Process> SortQueueWithoutPeek(Queue<Process> queueProcess)
        {
            var tempPeek = queueProcess.Dequeue();
            var tempList = queueProcess.ToList();
            var tempList2 = tempList.OrderBy(process => process.CpuPhaseLength);

            var queueResult = new Queue<Process>();
            queueResult.Enqueue(tempPeek);
            foreach (var process in tempList2)
            {
                queueResult.Enqueue(process);
            }
            return queueResult;
        }

        public static Queue<Process> SortQueueWithExpropriation(Queue<Process> queueProcess, int peekToGoTime)
        {
            queueProcess.Peek().CpuPhaseLength -= peekToGoTime;
            var tempList = queueProcess.ToList();
            var tempList2 = tempList.OrderBy(process => process.CpuPhaseLength);

            var queueResult = new Queue<Process>();
            foreach (var process in tempList2)
            {
                queueResult.Enqueue(process);
            }
            return queueResult;
        }

        public static void ShowQueue(Queue<Process> queueProcesses)
        {
            Console.WriteLine("\n----------------KOLEJKA-----------------");
            foreach (var proces in queueProcesses)
            {
                Console.WriteLine("Numer procesu:               " + proces.ProcessNumber);
                Console.WriteLine("Długość fazy procesora:      " + proces.CpuPhaseLength);
                Console.WriteLine("Czas zgłoszenia się procesu: " + proces.EntryTime);
                Console.WriteLine("Czas oczekiwania procesu:    " + proces.WaitingTime);
                Console.WriteLine("---------------------------------");
            }
        }

        public static Queue<Process> CopyProcessQueue(Queue<Process> queueProcess)
        {
            var queueResult = new Queue<Process>();
            foreach (var proces in queueProcess)
            {
                queueResult.Enqueue(new Process(proces.ProcessNumber, proces.CpuPhaseLength, proces.EntryTime, proces.WaitingTime));
            }
            return queueResult;
        }

        public static List<Process> CopyProcessList(List<Process> listProcess)
        {
            var listResult = new List<Process>();
            foreach (var proces in listProcess)
            {
                listResult.Add(new Process(proces.ProcessNumber, proces.CpuPhaseLength, proces.EntryTime, proces.WaitingTime));
            }
            return listResult;
        }
    }
}