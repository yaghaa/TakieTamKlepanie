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
            return odwolania.Select(item => (int) (((decimal) item.Count/(decimal) count)*100*iloscRamek)).ToList();
        }
    }
}