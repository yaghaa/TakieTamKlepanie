using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    public class Solution2
    {
        private const int joe = 1;
        private readonly int jk;

        public Solution2()
        {
            jk = 1;
        }
        public int solution2(int[] A)
        {
               
            //int K = A.Sum(i => i*(8 ^ i));
            int K = 0;
            
            for (int i = 0; i < A.Length; i++)
            {
                K += A[i] * (int)Math.Pow(8, i);
            }

            Console.WriteLine(K);

            List<int> liczbaBin = new List<int>();
            int wynik = K;

            while (wynik!=0)
            {
                if (wynik % 2 == 0) liczbaBin.Add(0); else liczbaBin.Add(1);
                wynik = wynik / 2;
            }

            //liczbaBin.Reverse();
            int result = liczbaBin.Count(i => i == 1);
            return result;
        }
    }
}