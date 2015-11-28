using System.Collections.Generic;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm
{
    public class OptPRA : IPageReplacementAlgorithm
    {
        private static List<int> _odwolania;
        private int[] _pamiec;

        public int Simulation(List<int> odwolania, int[] pamiec)
        {
            _odwolania = odwolania;
            _pamiec = pamiec;
            int iloscBledowStrony = 0;
            int id = 0;
            int i = 0;
            ClearMemory();

            for (i = 0; i < _odwolania.Count && _pamiec[_pamiec.Length - 1] == -1; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    _pamiec[id] = _odwolania[i];
                    id++;
                    iloscBledowStrony++;
                }
            }


            for (i = i + 1; i < _odwolania.Count; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    id = 0;

                    int czasNieuzywania = 0;
                    for (int j = 0; j < _pamiec.Length; j++)
                    {
                        int tmp = 0;

                        for (int k = i; k < _odwolania.Count && !_odwolania[k].Equals(_pamiec[j]); k++)
                        {
                            tmp++;
                        }
                        id = tmp > czasNieuzywania ? j : id;
                        czasNieuzywania = tmp > czasNieuzywania ? tmp : czasNieuzywania;
                    }

                    _pamiec[id] = _odwolania[i];
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