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

        public SimulationResult Simulation(List<Commission>[] commissionArray)
        {
            var commissionList = commissionArray[0];
            var waitingCommissionList = commissionArray[1];
            bool ifAscending = true;
            int counterHelper = 0;

            do
            {
                if (counterHelper == 100 && ifAscending) { ifAscending = false; counterHelper = 0; }
                if (counterHelper == 100 && !ifAscending) { ifAscending = true; counterHelper = 0; }

                _presentPosition = MoveHead(_presentPosition, ifAscending);  // przesunięcie głowicy
                _displacementHeadSum++;                                         // licznik przemieszczeń ++
                counterHelper++;

                if (commissionList.Count != 0)
                {
                    for (int i = 0; i < commissionList.Count; i++)                  // NIEEFEKTYWNE !!!     
                    {
                        if (_presentPosition == commissionList[i].CommissionNumber) // zdjęcie procesu z kolejki 
                        {
                            _completeCommissionList.Add(commissionList[i]);
                            commissionList.Remove(commissionList[i]);
                        }
                    }   
                }

                if (commissionList.Count != 0 && waitingCommissionList.Count != 0 && waitingCommissionList[0].EntryTime == _presentPosition) // dodanie do kolejki
                {
                    commissionList.Add(waitingCommissionList[0]);
                    waitingCommissionList.Remove(waitingCommissionList[0]);
                }


            } while (commissionList.Count != 0);

            return new SimulationResult()
            {
                DisplacementHeadSum = _displacementHeadSum,
                CompleteCommissionList = _completeCommissionList
            };
        }

        private int MoveHead(int presentPosition, bool ifAscending)
        {
            if (ifAscending) return ++presentPosition;
            if (!ifAscending) return --presentPosition;
            return presentPosition;
        }
    }
}