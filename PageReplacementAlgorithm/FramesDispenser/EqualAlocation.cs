using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FramesDispenser.Interfaces;

namespace FramesDispenser
{
  public class EqualAlocation:IDispenser
  {
    public List<int> CreateOperationMemory(List<List<int>> odwolania, int rameczki)
    {
      var i = 0;
      return odwolania.Select(item => (int)(((double)rameczki/odwolania.Count))).ToList();
      
    }
  }
}
