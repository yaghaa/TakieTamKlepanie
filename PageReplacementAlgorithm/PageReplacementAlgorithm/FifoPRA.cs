using System;
using System.Collections.Generic;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm
{
    public class FifoPRA : IPageReplacementAlgorithm
    {
        private static List<int> _odwolania;
        private int[] _pamiecOp;
 
        public int Simulation(List<int> odwolania, int[] pamiecOp)
        {
            _odwolania = odwolania;
            _pamiecOp = pamiecOp;

            int numberOfPagesFaults = 0;
            int id = 0;
            ClearMemory();

            _pamiecOp[0] = _odwolania[0];
            numberOfPagesFaults = id = 1;

            for (int i = 1; i < _odwolania.Count; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    _pamiecOp[id] = _odwolania[i];
                    id = (id == _pamiecOp.Length - 1) ? 0 : id + 1;
                    numberOfPagesFaults++;
                }
            }
            return numberOfPagesFaults;
        }


        private void ClearMemory()
        {
            for (int a = 0; a < _pamiecOp.Length; a++)
            {
                _pamiecOp[a] = -1;
            }
        }

        private bool IsInMemory(int odwolanie)
        {
            int i = 0;
            while (i < _pamiecOp.Length && !_pamiecOp[i].Equals(odwolanie))
            {
                i++;
            }
            return i != _pamiecOp.Length;
        }

    }
}