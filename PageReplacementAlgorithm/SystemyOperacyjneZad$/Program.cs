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
        private static List<int[]> _pamiecOp2 = new List<int[]>();
        private static List<int> _ramekLista2;

        private static void Main(string[] args)
        {
            var program = new Program();

            for (int i = 0; i < 10; i++)
            {
                var lru = new LruPRA();
                _listaProcesow.Add(lru);
                _odwolania.Add(new List<int>());
            }

            

            Console.WriteLine("Podaj ilość ramek:");
            var numberOfRecalls = Console.ReadLine();
            var iloscRameczek = Int32.Parse(numberOfRecalls);

            var proportional = new ProportionalAlocation();
            var equal = new EqualAlocation();

            program.LosujOdwolania();
            _ramekLista = proportional.CreateOperationMemory(_odwolania,iloscRameczek);
            _ramekLista2 = equal.CreateOperationMemory(_odwolania,iloscRameczek);

            var k = 0;
            foreach (var ramka in _ramekLista)
            {
                program.Initialize(ramka, k);
                k++;
            }
            k=0;
            foreach (var ramka in _ramekLista2)
            {
                program.Initialize2(ramka, k);
                k++;
            }

            var agregat = new LruAgregate();
            var agregat2 = new LruAgregate();
            var equalOdwolania = new List<List<int>>();
            var j = 0;
            foreach (var item in _odwolania)
            {
                equalOdwolania.Add(new List<int>(_odwolania[j]));
                j++;
            }
          var equalProcessList = new List<LruPRA>();
            for (int i = 0; i < 10; i++)
            {
                var lru = new LruPRA();
                equalProcessList.Add(lru);
             }



          var results = agregat.SimulateAll(_odwolania, _pamiecOp, _listaProcesow, 3);
          var results2 = agregat2.SimulateAll(equalOdwolania, _pamiecOp2, equalProcessList, 3);
          Console.WriteLine();
          Console.WriteLine("Proporcjonalny");
            foreach (var result in results)
          {
            Console.WriteLine(result);   
          }
            Console.WriteLine();
            Console.WriteLine("Equal");
            foreach (var result2 in results2)
          {
            Console.WriteLine(result2);   
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

        private void Initialize2(int n, int pozycja)
        {
            _pamiecOp2.Add(new int[n]);
            for (var i = 0; i < _pamiecOp2[pozycja].Length; i++)
            {
                _pamiecOp2[pozycja][i] = -1;
            }
        }

        private void LosujOdwolania()
        {
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("{0} Proces",j+1);
                
                var m =_random.Next(11)*4;
                Console.WriteLine("ilość stron " + m);
                
                var k =_random.Next(100)*100;
                Console.WriteLine("ilość odwołań " + k);
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