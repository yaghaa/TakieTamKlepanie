using System.Collections.Generic;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm
{
    public class LruAproxPRA : IPageReplacementAlgorithm
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
            int tmp = 0;
            List<int> referenceBitsArray = new List<int>();
            List<int> pamiecHelp = new List<int>();

            ClearMemory();

            for (i = 0; i < _odwolania.Count && _pamiecOp[_pamiecOp.Length - 1] == -1; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    _pamiecOp[id] = _odwolania[i];
                    pamiecHelp.Add(_pamiecOp[id]);
                    id++;
                    numberOfPagesFaults++;
                    referenceBitsArray.Add(0);
                }
                else
                {
                    tmp = pamiecHelp.IndexOf(_odwolania[i]);
                    referenceBitsArray[tmp] = 1; 
                }
            }

            for (i = i+1; i < _odwolania.Count; i++)
            {
                tmp = 0;
                id = 0;
                if (!IsInMemory(_odwolania[i]))
                {
                    for (int j = 0; j < pamiecHelp.Count; j++)
                    {
                        if (referenceBitsArray[j] == 0)
                        {
                            tmp = j;
                            break;
                        }
                        referenceBitsArray[j] = 0;
                    }

                    //id = (pamiecHelp.IndexOf(tmp)) > _pamiec.Length -1 || (pamiecHelp.IndexOf(tmp)) < 0
                    //    ? 0
                    //    : pamiecHelp.IndexOf(tmp);

                    id = IndeksOf(pamiecHelp[tmp]);
                    
                    pamiecHelp.Remove(pamiecHelp[tmp]);
                    referenceBitsArray.Remove(referenceBitsArray[tmp]);
                    pamiecHelp.Add(_odwolania[i]);
                    referenceBitsArray.Add(0);
                    _pamiecOp[id] = _odwolania[i];
                    numberOfPagesFaults++;
                }
                else
                {
                    tmp = pamiecHelp.IndexOf(_odwolania[i]); 
                    referenceBitsArray[tmp] = 1; // jak znamy pozycję tej strony, to zmieniamy jej bit na 1.
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

        private int IndeksOf(int wart)
        {
            for (int i = 0; i < _pamiecOp.Length; i++)
            {
                if (wart == _pamiecOp[i])
                {
                    return i;
                }
            }
            return -1;
        }

    }
}