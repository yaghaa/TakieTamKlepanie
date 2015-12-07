using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Solution
    {
        
        public virtual int solution(int[] A)
        {
           
            int jumps = 0;
            int position = 0;
            List<int> list = new List<int>();

            do
            {
                list.Add(position);
                position += A[position];
                if (position >= A.Length) return jumps;
                jumps++;
            } while (!list.Contains(position));
            return -1;
        }

        public int solution(int[] A, int K)
        {
            return K-1;
        }

        public string solution(int[] A, int K, string s)
        {
            return "df"+s;
        }

        public IEnumerable<int> test(bool first, bool second, bool third)
        {
            if(first)
            yield return 1;

            if(second)
            yield return 2;
            if(third)
            yield return 3;
        }
    }

  
}