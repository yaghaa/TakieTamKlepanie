using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SchedulingAccessToDisc.Models
{
    public class SimulationData
    {
        public List<Commission>[] CreateArrayOfCommissionList(int sizeOfList)
        {
            List<Commission> commissionList = new List<Commission>();
            List<Commission> waitingCommissionList = new List<Commission>();
            Random commissionNumber = new Random();
            Random entryTime = new Random();
            var entrySum = 0;

            for (int i = 0; i < sizeOfList / 2; i++)
            {
                commissionList.Add(new Commission(commissionNumber.Next(1, 100), 0));
            }

            for (int i = 0; i < sizeOfList/2; i++)
            {
                waitingCommissionList.Add(new Commission(commissionNumber.Next(1, 100), entrySum += entryTime.Next(1, 10)));
            }

            var temp = new List<Commission>[2];
            temp[0] = commissionList;
            temp[1] = waitingCommissionList;
            return temp;
        }

        public List<Commission>[] CopyArrayOfCommissionList(List<Commission>[] arrayOfCommissionList)
        {
            var newArrayOfCommissionList = new List<Commission>[arrayOfCommissionList.Length];
            var i = 0;

            foreach (var list in arrayOfCommissionList)
            {
                var listOfCommission = new List<Commission>();
                foreach (var element in list)
                {
                    listOfCommission.Add(new Commission(element.CommissionNumber, element.EntryTime));
                }
                newArrayOfCommissionList[i] = listOfCommission;
                i++;
            }
            return newArrayOfCommissionList;
        }
    }
}