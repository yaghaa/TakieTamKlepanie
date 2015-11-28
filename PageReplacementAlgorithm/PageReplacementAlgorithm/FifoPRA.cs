using System;
using System.Collections.Generic;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm
{
    public class FifoPRA : IPageReplacementAlgorithm
    {
        private static List<int> _odwolania;
        private int[] _pamiec;
 
        public int Simulation(List<int> odwolania, int[] pamiec)
        {
            _odwolania = odwolania;
            _pamiec = pamiec;

            int iloscBledowStrony = 0;
            int id = 0;
            ClearMemory();

            _pamiec[0] = _odwolania[0];
            iloscBledowStrony = id = 1;

            for (int i = 1; i < _odwolania.Count; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    _pamiec[id] = _odwolania[i];
                    id = (id == _pamiec.Length - 1) ? 0 : id + 1;
                    iloscBledowStrony++;
                }
            }
            return iloscBledowStrony;
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