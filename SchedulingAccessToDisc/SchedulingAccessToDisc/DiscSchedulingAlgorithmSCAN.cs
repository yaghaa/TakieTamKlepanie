using System.Collections.Generic;
using System.Linq;
using SchedulingAccessToDisc.Interfaces;
using SchedulingAccessToDisc.Models;

namespace SchedulingAccessToDisc
{
    public class DiscSchedulingAlgorithmSCAN : IDiscSchedulingAlgorithm
    {
        private int _displacementHeadSum = 0;
        private List<Commission> _completeCommissionList = new List<Commission>();
        private int _presentPosition = 0;

        public SimulationResult Simulation(List<Commission>[] commissionArray, int discSize)
        {
            var commissionList = commissionArray[0];
            var waitingCommissionList = commissionArray[1];
            bool ifAscending = true;
            int counterHelper = 0;

            do
            {
                if (counterHelper == discSize)
                {
                    ifAscending = !ifAscending;
                    counterHelper = 0;
                }
                
                _presentPosition = MoveHead(_presentPosition, ifAscending); // przesunięcie głowicy
                _displacementHeadSum++; // licznik przemieszczeń ++
                counterHelper++;

                if (commissionList.Count != 0)
                {
                    var tempCommissionListToRemve = new List<Commission>();
                    foreach (var commission in commissionList)                  // PRZEJRZENIE LISTY PROCESÓW - ZDJĘCIE PROCESÓW NA DANEJ POZYCJI !!!  
                    {
                        if (_presentPosition == commission.CommissionNumber)
                        {
                            _completeCommissionList.Add(commission);
                            tempCommissionListToRemve.Add(commission);          //  tymczasowa lista procesów
                        }
                    }
                    foreach (var commission in tempCommissionListToRemve)       // USUNIECIE PROCESOW Z LISTY PROCESÓW
                    {
                        commissionList.Remove(commission);
                    }
                }

                if (waitingCommissionList.Count != 0 &&
                    waitingCommissionList[0].EntryTime == _displacementHeadSum) // dodanie do kolejki
                {
                    commissionList.Add(waitingCommissionList[0]);
                    waitingCommissionList.Remove(waitingCommissionList[0]);
                }
            } while (commissionList.Count != 0 || waitingCommissionList.Count != 0);

            return new SimulationResult()
            {
                DisplacementHeadSum = _displacementHeadSum,
                CompleteCommissionList = _completeCommissionList
            };
        }

        private int MoveHead(int presentPosition, bool ifAscending)
        {
            if (ifAscending) 
                return ++presentPosition;
             
             return --presentPosition;
        }
    }
}