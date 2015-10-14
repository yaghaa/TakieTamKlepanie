using System;
using System.Collections.Generic;
using SchedulingAccessToCPU.Interfaces;

namespace SchedulingAccessToCPU
{
    public class SchedulingAlgorithmSRTF : ISchedulingAlgorithm
    {
        private List<Process> _completeProcessList;
        private int _time = 0;
        private double _averageWaitingTimeResult = 0;
        private double _waitingTimeResult = 0;
        private int _processCounter = 0;
        private int _expropriationCounter = 0;

        public SimulationResult Simulation(Queue<Process> queueProcesses, List<Process> listProcesses)
        {
            int peekToGoTime = 0;
            // SchedulingAlgorithmHelper.ShowQueue(queueProcesses); // !!!
            _completeProcessList = new List<Process>();

            queueProcesses = SchedulingAlgorithmHelper.SortQueue(queueProcesses);  // sortowanie kolejki początkowych procesów
            // SchedulingAlgorithmHelper.ShowQueue(queueProcesses); // !!!

            do
            {
                if (queueProcesses.Count != 0)
                {
                    if (peekToGoTime == queueProcesses.Peek().CpuPhaseLength) // zdjęcie procesu z kolejki
                    {
                        _completeProcessList.Add(queueProcesses.Peek());
                        _processCounter++;
                        _waitingTimeResult += queueProcesses.Peek().WaitingTime;
                        queueProcesses.Dequeue();
                        peekToGoTime = 0;
                    }

                    foreach (var process in queueProcesses) // zwiększenie czasu oczekiwania wszystkim oprócz Peeka
                    {
                        if (process == queueProcesses.Peek())
                            continue;

                        process.WaitingTime++;
                    }
                }

                if (listProcesses.Count != 0 && listProcesses[0].EntryTime == _time) // dodanie do kolejki
                {
                    queueProcesses.Enqueue(listProcesses[0]);

                    if (listProcesses[0].CpuPhaseLength >= (queueProcesses.Peek().CpuPhaseLength - peekToGoTime))
                    {
                        queueProcesses = SchedulingAlgorithmHelper.SortQueueWithoutPeek(queueProcesses); // sortowanie kolejki po dodaniu nowego procesu
                    }
                    else
                    {
                       // SchedulingAlgorithmHelper.ShowQueue(_queueProcess); // !!!
                       // Console.WriteLine("Czas pozostały do wykonania procesu Peek: " + (_queueProcess.Peek().CpuPhaseLength - peekToGoTime));
                        queueProcesses = SchedulingAlgorithmHelper.SortQueueWithExpropriation(queueProcesses, peekToGoTime); // sortowanie kolejki po dodaniu nowego procesu Z WYWLASZCZENIEM
                        peekToGoTime = 0;
                        _expropriationCounter++;
                       // SchedulingAlgorithmHelper.ShowQueue(_queueProcess); // !!!
                    }
                    listProcesses.Remove(listProcesses[0]);
                }
                _time++;
                peekToGoTime++;

            } while (queueProcesses.Count != 0 || listProcesses.Count != 0);

            _averageWaitingTimeResult = _waitingTimeResult / _processCounter;

            Console.WriteLine("Ilość wywłaszczeń: " + _expropriationCounter);

            return new SimulationResult()
            {
                AverageWaitingTime = _averageWaitingTimeResult,
                CompleteProcessList = _completeProcessList
            };
        }
    }
}