using System.Collections.Generic;
using System.Security.Policy;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm
{
    public class LruPRA : IPageReplacementAlgorithm
    {
        private static List<int> _odwolania;
        private int[] _pamiecOp;

        public int Simulation(List<int> odwolania, int[] pamiecOp)
        {
            _odwolania = odwolania;
            _pamiecOp = pamiecOp;

            int numberOfPagesFaults = 0;
            int id = 0;
            int i = 0;
            ClearMemory();

            for (i = 0; i < _odwolania.Count && _pamiecOp[_pamiecOp.Length - 1] == -1; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    _pamiecOp[id] = _odwolania[i];
                    id++;
                    numberOfPagesFaults++;
                }
            }

            for (i = i + 1; i < _odwolania.Count; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    id = 0;
                    int czasNieuzywania = 0;
                    for (int j = 0; j < _pamiecOp.Length; j++)
                    {
                        int tmp = 0;

                        for (int k = i; k > -1 && !_odwolania[k].Equals(_pamiecOp[j]); k--)
                        {
                            tmp++;
                        }
                        id = tmp > czasNieuzywania ? j : id;
                        czasNieuzywania = tmp > czasNieuzywania ? tmp : czasNieuzywania;
                    }

                    _pamiecOp[id] = _odwolania[i];
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