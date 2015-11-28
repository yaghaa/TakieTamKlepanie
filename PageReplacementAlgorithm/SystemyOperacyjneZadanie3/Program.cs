using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageReplacementAlgorithm;

namespace SystemyOperacyjneZadanie3
{
    class Program
    {
        
        private static List<int> _odwolania;
        private int[] _pamiec;
        private Random _random = new Random();

        static void Main(string[] args)
        {
            var program = new Program();
              int flaga = -1;
        
        
                    Console.WriteLine("Podaj ilość odwołań:");

                    var number1 = Console.ReadLine();
                    int iloscOdwolan = Int32.Parse(number1);

                    Console.WriteLine("Podaj ilość ramek:");

                    var number2 = Console.ReadLine();
                    int iloscRamek = Int32.Parse(number2);

                    Console.WriteLine("Podaj ilość Stron");

                    var number3 = Console.ReadLine();
                    int iloscStron = Int32.Parse(number3);
                    ;
                    program.losujOdwolania(iloscRamek, iloscStron, iloscOdwolan);
                    Console.WriteLine("zakończono skukcesem. Uwzględniono zasadę lokalności odwołań.");
                    
                    Console.WriteLine("alg. OPT: " + program.opt());

                    Console.WriteLine("alg. FCFS: " + program.FCFS());

                    Console.WriteLine("alg. LRU: " + program.lru());

                    Console.WriteLine("alg. LRU Aproksymowany: " + program.lruAproks());

                    Console.WriteLine("alg. RND: " + program.rnd());

            
            Console.ReadKey();
        }







        private void Initialize(int n)
        {
            _odwolania = new List<int>();
            _pamiec = new int[n];
            for (int i = 0; i < _pamiec.Length; i++)
            {
                _pamiec[i]=-1;
            }
        }

        private  void losujOdwolania(int n, int m, int k)
        {
            Initialize(n);
            int tmp = -1;
            _odwolania.Add(_random.Next(m)+1);
            for (int i = 1; i < k; i++)
            {
                tmp = _random.Next(101);
                tmp = tmp < 40 ? _odwolania[_odwolania.Count - 1] : _random.Next(m) + 1;
                _odwolania.Add(tmp);
            }
        }

        private void czyscPamiec()
        {
            for (int a = 0; a < _pamiec.Length; a++)
            {
                _pamiec[a] = -1;
            }
        }

        private bool czyJestWPamieci(int odwolanie)
        {
            int i = 0;
            while (i<_pamiec.Length && !_pamiec[i].Equals(odwolanie))
            {
                i++;
            }
            return i != _pamiec.Length;
        }

        private int indeksOf(int wart)
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

        private  int FCFS()
        {
            int iloscBledowStrony = 0;
            int id = 0;
            czyscPamiec();

            _pamiec[0] = _odwolania[0];
            iloscBledowStrony = id = 1;

            for (int i = 1; i < _odwolania.Count; i++)
            {
                if (!czyJestWPamieci(_odwolania[i]))
                {
                    _pamiec[id] = _odwolania[i];
                    id = (id == _pamiec.Length - 1) ? 0 : id + 1;
                    iloscBledowStrony++;
                }
            }
            return iloscBledowStrony;
        }

        private int opt()
        {
            int iloscBledowStrony = 0;
            int id = 0; 
            int i = 0;
            czyscPamiec();

            for (i = 0; i < _odwolania.Count && _pamiec[_pamiec.Length - 1] == -1; i++) 
            {
                if (!czyJestWPamieci(_odwolania[i])) 
                {
                    _pamiec[id] = _odwolania[i]; 
                    id++; 
                    iloscBledowStrony++; 
                }
            }

           
            for (i = i + 1; i < _odwolania.Count; i++) 
            {
                if (!czyJestWPamieci(_odwolania[i]))
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

        public int lru()
        {
            int iloscBledowStrony = 0;
            int id = 0;
            int i = 0;
            czyscPamiec();

            for (i = 0; i < _odwolania.Count && _pamiec[_pamiec.Length - 1] == -1; i++)
            {
                if (!czyJestWPamieci(_odwolania[i]))
                {
                    _pamiec[id] = _odwolania[i];
                    id++;
                    iloscBledowStrony++;
                }
            }

            for (i = i + 1; i < _odwolania.Count; i++)
            {
                if (!czyJestWPamieci(_odwolania[i]))
                {
                    id = 0;
                    int czasNieuzywania = 0;
                    for (int j = 0; j < _pamiec.Length; j++)
                    {
                        int tmp = 0;
                        
                        for (int k = i; k > -1 && !_odwolania[k].Equals(_pamiec[j]); k--)
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

        public int lruAproks()
        {
            int iloscBledowStrony = 0;
            int id = 0;
            int i = 0;
            int tmp = 0;
            List<int> tablicaBitowOdniesienia = new List<int>();
            List<int> pamiecHelp = new List<int>();

            czyscPamiec();

            for (i = 0; i < _odwolania.Count && _pamiec[_pamiec.Length - 1] == -1; i++)
            {
                if (!czyJestWPamieci(_odwolania[i]))
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
                    tablicaBitowOdniesienia[tmp]= 0; /** jak już znamy pozycję tej strony, to zmieniamy jej bit na 1. */
                }
            }

            for (i = i + 1; i < _odwolania.Count-1; i++)
            {
                tmp = 0;
                id = 0;
                if (!czyJestWPamieci(_odwolania[i]))
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

                    id = pamiecHelp[tmp];
                    /** szuka w tablicy pamiec tej strony, co wybrał przy przeszukiwaniu FIFO pamiecHelp. Pod id zapisuje jej pozycje */

                    pamiecHelp.Remove(tmp);
                    tablicaBitowOdniesienia.Remove(tmp);
                    pamiecHelp.Add(_odwolania[i]);
                    tablicaBitowOdniesienia.Add(0);
                    _pamiec[id] = _odwolania[i];
                    iloscBledowStrony++;
                }
                else
                {
                    tmp = pamiecHelp.IndexOf(_odwolania[i]); /** pozycja tej strony w pamiecHelp */
                    tablicaBitowOdniesienia[tmp] = 1;
                        /** jak już znamy pozycję tej strony, to zmieniamy jej bit na 1. */
                }
            }
            return iloscBledowStrony;
        }

        public int rnd()
        {
            int iloscBledowStrony = 0;
            int id = 0;
            int i = 0;
            Random random = new Random();

            czyscPamiec();

            /**
             * znowu zapełnianie wolnych ramek pamięci na początku.
             */
            for (i = 0; i < _odwolania.Count && _pamiec[_pamiec.Length - 1] == -1; i++)
            {
                if (!czyJestWPamieci(_odwolania[i]))
                {
                    _pamiec[id] = _odwolania[i];
                    id++;
                    iloscBledowStrony++;
                }
            }

            /**
             * jak nie ma juz wolnych ramek, to alg. random przy kolejnych odwołaniach do stron.
             */
            for (i = i + 1; i < _odwolania.Count; i++)
            {
                /**
                 * jeśli nie ma potrzebnej ramki w pamięci, to trzeba usunąć jedną z tych, co w niej akurat są.
                 * ktorą ramkę opróżnić? Byle którą. :) Wybierz losowo.
                 */
                if (!czyJestWPamieci(_odwolania[i]))
                {
                    id = random.Next(_pamiec.Length);
                    _pamiec[id] = _odwolania[i];
                    iloscBledowStrony++;
                }
            }

            return iloscBledowStrony;
        }

    }
}
