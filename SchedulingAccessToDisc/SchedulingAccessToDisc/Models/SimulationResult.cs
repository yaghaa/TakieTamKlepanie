using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace SchedulingAccessToDisc.Models
{
    public class SimulationResult
    {
        public int DisplacementHeadSum { get; set; }
        public List<Commission> CompleteCommissionList { get; set; }

        public void ShowCompleteCommissionList()
        {
            foreach (var commission in CompleteCommissionList)
            {
                Console.WriteLine("Numer procesu: " + commission.CommissionNumber);
                Console.WriteLine("Czas wejścia:  " + commission.EntryTime);
                Console.WriteLine("----------------------");
            }
        }
    }
}