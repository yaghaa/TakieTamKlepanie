using System.Collections.Generic;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm
{
    public class LruAproxPRA : IPageReplacementAlgorithm
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
            int tmp = 0;
            List<int> tablicaBitowOdniesienia = new List<int>();
            List<int> pamiecHelp = new List<int>();

            ClearMemory();

            for (i = 0; i < _odwolania.Count && _pamiec[_pamiec.Length - 1] == -1; i++)
            {
                if (!IsInMemory(_odwolania[i]))
                {
                    _pamiec[id] = _odwolania[i];
                    pamiecHelp.Add(_pamiec[id]);
                    id++;
                    iloscBledowStrony++;
                    tablicaBitowOdniesienia.Add(0);
                }
                else
                {
                    tmp = pamiecHelp.IndexOf(_odwolania[i]);
                    tablicaBitowOdniesienia[tmp] = 1; /** jak już znamy pozycję tej strony, to zmieniamy jej bit na 1. */
                }
            }

            for (i = 1; i < _odwolania.Count; i++)
            {
                tmp = 0;
                id = 0;
                if (!IsInMemory(_odwolania[i]))
                {
                    for (int j = 0; j < pamiecHelp.Count; j++)
                    {
                        if (tablicaBitowOdniesienia[j] == 0)
                        {
                            tmp = j;
                            break;
                        }
                        tablicaBitowOdniesienia[j] = 0;
                    }

                    //id = (pamiecHelp.IndexOf(tmp)) > _pamiec.Length -1 || (pamiecHelp.IndexOf(tmp)) < 0
                    //    ? 0
                    //    : pamiecHelp.IndexOf(tmp);

                    id = IndeksOf(pamiecHelp[tmp]);
                    /** szuka w tablicy pamiec tej strony, co wybrał przy przeszukiwaniu FIFO pamiecHelp. Pod id zapisuje jej pozycje */

                    pamiecHelp.Remove(pamiecHelp[tmp]);
                    tablicaBitowOdniesienia.Remove(tablicaBitowOdniesienia[tmp]);
                    pamiecHelp.Add(_odwolania[i]);
                    tablicaBitowOdniesienia.Add(0);
                    _pamiec[id] = _odwolania[i];
                    iloscBledowStrony++;
                }
                else
                {
                    tmp = pamiecHelp.IndexOf(_odwolania[i]); /** pozycja tej strony w pamiecHelp */
                    tablicaBitowOdniesienia[tmp] = 0;
                    /** jak już znamy pozycję tej strony, to zmieniamy jej bit na 1. */
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

        private int IndeksOf(int wart)
        {
            for (int i = 0; i < _pamiec.Length; i++)
            {
                if (wart == _pamiec[i])
                {
                    return i;
                }
            }
            return -1;
        }

    }
}