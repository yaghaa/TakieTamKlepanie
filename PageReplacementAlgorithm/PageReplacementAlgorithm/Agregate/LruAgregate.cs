using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm.Agregate
{
 
  public class LruAgregate
  {
    private List<List<int>> _odwolania;
    private int _commonFrames;
    private List<LruPRA> _processList;
    private List<int[]> _pamiecOp; 
    public int[] SimulateAll(List<List<int>> odwolania, List<int[]> pamiecOp, List<LruPRA> listaProcesow,int commonFrames)
    {
      _odwolania = odwolania;
      _processList = listaProcesow;
      
      var left = 0;
      var results = new int[listaProcesow.Count];
      _pamiecOp = pamiecOp.Select(x => AdaptMemory(x, commonFrames)).ToList();
      for (int i = 0; i < listaProcesow.Count; i++)
      {
        results[i] = 0;
      }
      do
      {
        var i = 0;
        foreach (var odwolanie in odwolania)
        {
          var listOfRecalls = odwolanie.Take(10).ToList();
          odwolanie.RemoveRange(0,listOfRecalls.Count);
          results[i] += _processList[i].Simulation(listOfRecalls, _pamiecOp[i]);
          i++;
        }
        
        left = _odwolania.Sum(c => c.Count);
      } while (left > 0);
      return results;
    }

    private int[] AdaptMemory(int[] pamiecOp,int commonframes)
    {
      var result = new int[pamiecOp.Length + commonframes];
      for (int i = 0; i < pamiecOp.Length; i++)
      {
        result[i] = pamiecOp[i];
      }
      for (int i = pamiecOp.Length; i < result.Length; i++)
      {
        result[i] = -1;
      }
      return result;
    }
  }
}