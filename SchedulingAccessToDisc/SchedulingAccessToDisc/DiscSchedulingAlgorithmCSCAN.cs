using System.Collections.Generic;
using SchedulingAccessToDisc.Interfaces;
using SchedulingAccessToDisc.Models;

namespace SchedulingAccessToDisc
{
    public class DiscSchedulingAlgorithmCSCAN : IDiscSchedulingAlgorithm
    {
        private int _displacementHeadSum = 0;
        private List<Commission> _completeCommissionList = new List<Commission>();
        private int _presentPosition = 0;

        public SimulationResult Simulation(List<Commission>[] commissionArray, int discSize)
        {
            var commissionList = commissionArray[0];
            var waitingCommissionList = commissionArray[1];
            
            do
            {
                _presentPosition = MoveHead(_presentPosition, _displacementHeadSum, discSize);  // przesunięcie głowicy
                _displacementHeadSum++;                                               // licznik przemieszczeń ++
                
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

                if (waitingCommissionList.Count != 0 && waitingCommissionList[0].EntryTime == _displacementHeadSum)   // dodanie do kolejki
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

        private int MoveHead(int presentPosition, int displacementHeadSum, int discSize)
        {
            if ((displacementHeadSum % discSize) == 0) return 0;
            return ++presentPosition;
        }
    }
}