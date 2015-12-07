using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] A = new[] {2, 3, -1, 1, 3};
            //int[] B = new[] {1,1,-1,1};
            //var sol = new Solution();
            //var jumps = sol.solution(A);
            //Console.WriteLine(jumps);
            //Console.ReadKey();

            //try
            //{

            //}
            //catch (AccessViolationException)
            //{

            //    throw;
            //}
            //catch (NullReferenceException)
            //{
                
            //}

            

            //int[] A = new[] {1, 5, 6};
            //var sol2 = new Solution2();
            //var numberOfOnes = sol2.solution2(A);

            //Console.WriteLine(numberOfOnes);

            //string mojString = "mojaWartosc";
            //mojString = Zmien(mojString);

            //var sol1 = new Solution();
            //sol1.solution(A);
            //sol1.solution(A, 2);
            //sol1.solution(A, 1, "sjkdn");
            //var sol = (object) sol1;
            //var sol4 = sol as Solution;


            //var it = sol1.test(true,false,true);
            //Console.WriteLine(mojString);

            //var sol33 = new Solution3();
            //int N = sol33.solution(new[] {2, 1, 5, -6, 9});
            //Console.WriteLine(N);

            //var duzyDIC = new dic();
            //Console.WriteLine(duzyDIC.Jezyki("niemiecki"));
            //Console.WriteLine(duzyDIC.Jezyki("angielski"));
            //Console.WriteLine(duzyDIC.Jezyki("buc"));
            
            var sumka = new Slowo();
            sumka.Zamien(new[] {1,2,6,8,3});

            Console.ReadKey();
        }

        private static string Zmien(string mojstring)
        {
           return mojstring = "tr";
        }
    }
}
