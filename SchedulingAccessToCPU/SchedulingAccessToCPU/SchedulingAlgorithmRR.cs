using System.Collections.Generic;
using SchedulingAccessToCPU.Interfaces;

namespace SchedulingAccessToCPU
{
    public class SchedulingAlgorithmRR : ISchedulingAlgorithm
    {
        private List<Process> _completeProcessList;
        private int _time = 0;
        private double _averageWaitingTimeResult = 0;
        private double _waitingTimeResult = 0;
        private int _processCounter = 0;
        private const int QuantumOfTime = 15;     // kwant czasu

        public SimulationResult Simulation(Queue<Process> queueProcesses, List<Process> listProcesses)
        {
            int peekProcessingTime = 0;
            _completeProcessList = new List<Process>();

            do
            {
                if (queueProcesses.Count != 0)
                {
                    if (peekProcessingTime == queueProcesses.Peek().CpuPhaseLength) // zdjęcie procesu z kolejki
                    {
                        _completeProcessList.Add(queueProcesses.Peek());
                        _processCounter++;
                        _waitingTimeResult += queueProcesses.Peek().WaitingTime;
                        queueProcesses.Dequeue();
                        peekProcessingTime = 0;
                    }

                    foreach (var process in queueProcesses) // zwiększenie czasu oczekiwania wszystkim oprócz Peeka
                    {
                        if (process == queueProcesses.Peek())
                            continue;

                        process.WaitingTime++;
                    }

                    if (peekProcessingTime == QuantumOfTime)   // przesunięcie procesu na koniec kolejki po upływie kwantu czasu     RRRRRRRRRRRRR
                    {
                        queueProcesses.Peek().CpuPhaseLength -= peekProcessingTime; 
                        var tempProcess = queueProcesses.Dequeue();
                        queueProcesses.Enqueue(tempProcess);
                        peekProcessingTime = 0;
                    }
                }

                if (listProcesses.Count != 0 && listProcesses[0].EntryTime == _time) // dodanie do kolejki
                {
                    queueProcesses.Enqueue(listProcesses[0]);
                    listProcesses.Remove(listProcesses[0]);
                }
                _time++;
                peekProcessingTime++;

                

            } while (queueProcesses.Count != 0 || listProcesses.Count != 0);

            _averageWaitingTimeResult = _waitingTimeResult / _processCounter;

            var filePath = "C:\\aga\\06_Robocze\\SchedulingAccesToCpuRR.txt";
            var saveToTextFile = new TextFileSchedulingAccessToCPU();
            saveToTextFile.SaveFile(_completeProcessList, filePath);

            return new SimulationResult()
            {
                AverageWaitingTime = _averageWaitingTimeResult,
                CompleteProcessList = _completeProcessList
            };
        }
    }
}