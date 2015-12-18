using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FramesDispenser;
using PageReplacementAlgorithm;
using PageReplacementAlgorithm.Agregate;

namespace SystemyOperacyjneZadanie4
{
    internal class Program
    {
        private static List<List<int>> _odwolania = new List<List<int>>();
        private static List<int[]> _pamiecOp = new List<int[]>();
        private static List<int> _ramekLista = new List<int>();
        private static List<LruPRA> _listaProcesow = new List<LruPRA>();
        private readonly Random _random = new Random();

        private static void Main(string[] args)
        {
            var program = new Program();

            for (int i = 0; i < 10; i++)
            {
                var lru = new LruPRA();
                _listaProcesow.Add(lru);
                _odwolania.Add(new List<int>());
            }

            Console.WriteLine("Podaj ilość Stron");
            var numberOfPages = Console.ReadLine();
            var iloscStron = Int32.Parse(numberOfPages);

            Console.WriteLine("Podaj ilość odwołań:");
            var numberOfRecalls = Console.ReadLine();
            var iloscOdwolan = Int32.Parse(numberOfRecalls);

            var proportional = new ProportionalAlocation();

            program.LosujOdwolania(iloscStron, iloscOdwolan);
            int iloscRameczek = 100;
            _ramekLista = proportional.CreateOperationMemory(_odwolania,iloscRameczek);

            var k = 0;
            foreach (var ramka in _ramekLista)
            {
                program.Initialize(ramka, k);
                k++;
            }


          var agregat = new LruAgregate();
          var results = agregat.SimulateAll(_odwolania, _pamiecOp, _listaProcesow, 10);
          Console.WriteLine("PP");
          foreach (var result in results)
          {
            Console.WriteLine(result);   
          }  
            Console.ReadKey();
        }


        private void Initialize(int n, int pozycja)
        {
            _pamiecOp.Add(new int[n]);
            for (var i = 0; i < _pamiecOp[pozycja].Length; i++)
            {
                _pamiecOp[pozycja][i] = -1;
            }
        }

        private void LosujOdwolania(int m, int k)
        {
            for (int j = 0; j < 10; j++)
            {
                var tmp = -1;
                _odwolania[j].Add(_random.Next(m) + 1);
                for (int i = 1; i < k; i++)
                {
                    tmp = _random.Next(101);
                    tmp = tmp < 40 ? _odwolania[j][_odwolania[j].Count - 1] : _random.Next(m) + 1;
                    tmp += _random.Next(2);
                    _odwolania[j].Add(tmp);
                }
            }
        }
    }
}