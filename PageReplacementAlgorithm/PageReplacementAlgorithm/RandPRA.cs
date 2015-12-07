using System;
using System.Collections.Generic;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm
{
    public class RandPRA : IPageReplacementAlgorithm
    {
        private static List<int> _odwolania;
        private int[] _pamiec;

        public int Simulation(List<int> odwolania, int[] pamiecOp)
        {
            _odwolania = odwolania;
            _pamiec = pamiecOp;
            int numberOfPagesFaults = 0;
            int id = 0;
            int i = 0;
            Random random = new Random();

            ClearMemory();

            for (i = 0; i < _odwolania.Count && _pamiec[_pamiec.Length - 1] == -1; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    _pamiec[id] = _odwolania[i];
                    id++;
                    numberOfPagesFaults++;
                }
            }

            for (i = i + 1; i < _odwolania.Count; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    id = random.Next(_pamiec.Length);
                    _pamiec[id] = _odwolania[i];
                    numberOfPagesFaults++;
                }
            }

            return numberOfPagesFaults;
        }


        private void ClearMemory()
        {
            for (int a = 0; a < _pamiec.Length; a++)
            {
                _pamiec[a] = -1;
            }
        }

        private bool IsInMemory(int odwolanie)
        {
            int i = 0;
            while (i < _pamiec.Length && !_pamiec[i].Equals(odwolanie))
            {
                i++;
            }
            return i != _pamiec.Length;
        }
    }
}