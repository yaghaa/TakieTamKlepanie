using System.Collections.Generic;
using System.Linq;
using FramesDispenser.Interfaces;

namespace FramesDispenser
{
    public class ProportionalAlocation : IDispenser
    {
        public List<int> CreateOperationMemory(List<List<int>> odwolania,int iloscRamek)
        {
            var count = odwolania.Sum(item => item.Count);
            var i = 0;
            var result = new List<int>();
            foreach (var item in odwolania)
            {
                var percent = (decimal)item.Count/(decimal)count;
                var frames = (int)(percent*iloscRamek);
                result.Add(frames);
            }
            return result;
        }
    }
}