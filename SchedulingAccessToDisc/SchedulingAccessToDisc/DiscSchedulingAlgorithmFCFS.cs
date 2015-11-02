using System.Collections.Generic;
using System.Linq;
using SchedulingAccessToDisc.Interfaces;
using SchedulingAccessToDisc.Models;

namespace SchedulingAccessToDisc
{
    public class DiscSchedulingAlgorithmFCFS : IDiscSchedulingAlgorithm
    {
        private int _displacementHeadSum = 0;
        private List<Commission> _completeCommissionList = new List<Commission>();
        private int _presentPosition = 0;
        

        public SimulationResult Simulation(List<Commission>[] commissionArray)
        {
            var commissionList = commissionArray[0];
            var waitingCommissionList = commissionArray[1];
            
            do
            {
                _presentPosition = MoveHead(_presentPosition, commissionList);  // przesunięcie głowicy
                _displacementHeadSum++;                                         // licznik przemieszczeń ++
                

                if (commissionList.Count != 0)
                {
                    if (_presentPosition == commissionList[0].CommissionNumber) // zdjęcie procesu z kolejki
                    {
                        _completeCommissionList.Add(commissionList[0]);
                        commissionList.Remove(commissionList.First());
                    }
                }

                if (commissionList.Count != 0 && waitingCommissionList.Count != 0 && waitingCommissionList[0].EntryTime == _displacementHeadSum) // dodanie do kolejki
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



        private int MoveHead (int presentPosition, List<Commission> commissionList)
        {
            if (presentPosition < commissionList[0].CommissionNumber) return ++presentPosition;
            if (presentPosition > commissionList[0].CommissionNumber) return --presentPosition;
            return presentPosition;
        }
    }
}