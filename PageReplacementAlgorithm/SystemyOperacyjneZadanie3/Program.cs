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
        private static int[] _pamiec;
        private readonly Random _random = new Random();

        static void Main(string[] args)
        {
            var program = new Program();
            var fifo = new FifoPRA();
            var opt = new OptPRA();
            var lru = new LruPRA();
            var lruAprox = new LruAproxPRA();
            var rand = new RandPRA();

            Console.WriteLine("Podaj ilość Stron");
            var numberOfPages = Console.ReadLine();
            var iloscStron = Int32.Parse(numberOfPages);

            Console.WriteLine("Podaj ilość ramek:");
            var numberOfFrames = Console.ReadLine();
            var iloscRamek = Int32.Parse(numberOfFrames);
           
            
            Console.WriteLine("Podaj ilość odwołań:");
            var numberOfRecalls = Console.ReadLine();
            var iloscOdwolan = Int32.Parse(numberOfRecalls);

            program.losujOdwolania(iloscRamek, iloscStron, iloscOdwolan);
            
            Console.WriteLine("algorytm FIFO: " + fifo.Simulation(_odwolania, _pamiec));
            Console.WriteLine("algorytm OPT: " + opt.Simulation(_odwolania, _pamiec));
            Console.WriteLine("algorytm LRU: " + lru.Simulation(_odwolania, _pamiec));
            Console.WriteLine("algorytm LRU Aproksymowany: " + lruAprox.Simulation(_odwolania, _pamiec));
            Console.WriteLine("algorytm RND: " + rand.Simulation(_odwolania, _pamiec));
          
            
            Console.ReadKey();
        }


        private void Initialize(int n)
        {
            _odwolania = new List<int>();
            _pamiec = new int[n];
            for (var i = 0; i < _pamiec.Length; i++)
            {
                _pamiec[i]=-1;
            }
        }

        private  void losujOdwolania(int n, int m, int k)
        {
            Initialize(n);
            var tmp = -1;
            _odwolania.Add(_random.Next(m)+1);
            for (int i = 1; i < k; i++)
            {
                tmp = _random.Next(101);
                tmp = tmp < 40 ? _odwolania[_odwolania.Count - 1] : _random.Next(m) + 1;
                _odwolania.Add(tmp);
            }
        }

    }
}
