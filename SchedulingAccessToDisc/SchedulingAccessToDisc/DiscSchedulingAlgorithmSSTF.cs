using System;
using System.Collections.Generic;
using System.Linq;
using SchedulingAccessToDisc.Interfaces;
using SchedulingAccessToDisc.Models;

namespace SchedulingAccessToDisc
{
    public class DiscSchedulingAlgorithmSSTF : IDiscSchedulingAlgorithm
    {
        private int _displacementHeadSum = 0;
        private List<Commission> _completeCommissionList = new List<Commission>();
        private int _presentPosition = 0;


        public SimulationResult Simulation(List<Commission>[] commissionArray, int discSize)
        {
            var commissionList = commissionArray[0];
            var waitingCommissionList = commissionArray[1];

            CommissionBubbleSortByDistanceFromHead(commissionList, _presentPosition);       // SORTOWANIE LISTY PROCESÓW WZGLĘDEM ODLEGŁOŚCI OD GŁOWICY
            //Show(commissionList);

            do
            {
                _presentPosition = MoveHead(_presentPosition, commissionList);  // przesunięcie głowicy
                _displacementHeadSum++;                                         // licznik przemieszczeń ++


                if (commissionList.Count != 0)
                {
                    if (_presentPosition == commissionList[0].CommissionNumber) // zdjęcie procesu z listy
                    {
                        _completeCommissionList.Add(commissionList[0]);
                        commissionList.Remove(commissionList.First());
                    }
                }

                if (commissionList.Count != 0 && waitingCommissionList.Count != 0 && waitingCommissionList[0].EntryTime == _displacementHeadSum) // dodanie do listy
                {
                    commissionList.Add(waitingCommissionList[0]);
                    waitingCommissionList.Remove(waitingCommissionList[0]);
                    CommissionBubbleSortByDistanceFromHead(commissionList, _presentPosition);   // SORTOWANIE LISTY PROCESÓW WZGLĘDEM ODLEGŁOŚCI OD GŁOWICY
                }


            } while (commissionList.Count != 0 || waitingCommissionList.Count != 0);

            return new SimulationResult()
            {
                DisplacementHeadSum = _displacementHeadSum,
                CompleteCommissionList = _completeCommissionList
            };
        }


        private int MoveHead(int presentPosition, List<Commission> commissionList)
        {
            if (presentPosition <= commissionList[0].CommissionNumber) return ++presentPosition;
            if (presentPosition > commissionList[0].CommissionNumber) return --presentPosition;
            return presentPosition;
        }

        private void CommissionBubbleSortByDistanceFromHead(List<Commission> lista, int presentPosition)
        {
            int n = lista.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (Math.Abs(presentPosition - lista[i].CommissionNumber) > Math.Abs(presentPosition - lista[i + 1].CommissionNumber))
                    {
                        Commission tmp = lista[i];
                        lista[i] = lista[i + 1];
                        lista[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
        }

        private void Show(List<Commission> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }

    }
}