using System;
using System.Linq;

namespace ConsoleApplication1
{
    public abstract class Slowo
    {
        public void Zamien(int[] A)
        {
            if (A.Length % 2 != 0)
            {
                var B = new int[A.Length + 1];
                int k = 0;
                foreach (var i in A)
                {
                    B[k] = i;
                    k++;
                }
                B[A.Length] = 0;
                A = B;
            }

            int j = A.Length - 1;

            for (int i = 0; i < A.Length / 2; i++)
            {
                Console.WriteLine("Suma {0} i {1} jest {2}", i, j, (A[i] + A[j]));
                j--;
            }


        }

        public abstract int krjzi();
        public abstract string kupa();


    }

    public abstract class slowko:Slowo
    {
        public override int krjzi()
        {
            throw new NotImplementedException();
        }

      
    }

}