using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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

            var completeProcessList = queueProcess.ToList();
            completeProcessList.AddRange(listProcess);
            var filePath = "C:\\aga\\06_Robocze\\SchedulingAccesToCpuStartList.txt";
            var saveToTextFile = new TextFileSchedulingAccessToCPU();
            saveToTextFile.SaveFile(completeProcessList, filePath);

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

        public static Queue<Process> CreateMyQueue()
        {
            Queue<Process> processQueue = new Queue<Process>();

            processQueue.Enqueue(new Process('p' + 1.ToString(), 80, 0, 0));
            processQueue.Enqueue(new Process('p' + 2.ToString(), 72, 0, 0));
            processQueue.Enqueue(new Process('p' + 3.ToString(), 84, 0, 0));
            processQueue.Enqueue(new Process('p' + 4.ToString(), 7, 0, 0));
            processQueue.Enqueue(new Process('p' + 5.ToString(), 24, 0, 0));
            processQueue.Enqueue(new Process('p' + 6.ToString(), 2, 0, 0));
            processQueue.Enqueue(new Process('p' + 7.ToString(), 3, 0, 0));
            processQueue.Enqueue(new Process('p' + 8.ToString(), 20, 0, 0));
            processQueue.Enqueue(new Process('p' + 9.ToString(), 19, 0, 0));
            processQueue.Enqueue(new Process('p' + 10.ToString(), 16, 0, 0));
            processQueue.Enqueue(new Process('p' + 11.ToString(), 18, 0, 0));
            processQueue.Enqueue(new Process('p' + 12.ToString(), 10, 0, 0));
            processQueue.Enqueue(new Process('p' + 13.ToString(), 14, 0, 0));
            processQueue.Enqueue(new Process('p' + 14.ToString(), 13, 0, 0));
            processQueue.Enqueue(new Process('p' + 15.ToString(), 12, 0, 0));
            processQueue.Enqueue(new Process('p' + 16.ToString(), 10, 0, 0));
            processQueue.Enqueue(new Process('p' + 17.ToString(), 3, 0, 0));
            processQueue.Enqueue(new Process('p' + 18.ToString(), 7, 0, 0));
            processQueue.Enqueue(new Process('p' + 19.ToString(), 5, 0, 0));
            processQueue.Enqueue(new Process('p' + 20.ToString(), 8, 0, 0));
           
            return processQueue;
        }

        public static Queue<Process> CreateMyQueue2()
        {
            Queue<Process> processQueue = new Queue<Process>();

            processQueue.Enqueue(new Process('p' + 1.ToString(), 21, 0, 0));
            processQueue.Enqueue(new Process('p' + 2.ToString(), 6, 0, 0));
            processQueue.Enqueue(new Process('p' + 3.ToString(), 3, 0, 0));
            
            return processQueue;
        }
    }
}