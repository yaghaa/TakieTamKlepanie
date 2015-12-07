namespace ConsoleApplication1
{
    public class Solution3
    {
        public int solution(int[] A)
        {
            int N = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (N>=1000000000) return -1;

                for (int j = i+1; j < A.Length; j++)
                {
                    if ((A[i]+A[j]) % 2 == 0) N++;
                }
            }

            return N;
        }
    }
}