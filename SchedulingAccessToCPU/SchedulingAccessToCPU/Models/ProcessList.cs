using System;
using System.Collections.Generic;

namespace SchedulingAccessToCPU
{
    public class ProcessList
    {
        public List<Process> CreateProcessList(int sizeOfList)
        {
            List<Process> processList = new List<Process>();
            Random phaseLength = new Random();

            for (int i = 0; i < sizeOfList; i++)
            {
                processList.Add(new Process('p' + (i + 1).ToString(), phaseLength.Next(1, 20), 0, 0));
            }
            return processList;
        }
    }
}