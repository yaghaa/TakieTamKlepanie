using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PageReplacementAlgorithm.Interfaces;

namespace PageReplacementAlgorithm
{
    public class KlasaDoTestowania
    {

        private IPageReplacementAlgorithm _algorithm;

        public KlasaDoTestowania(IPageReplacementAlgorithm alg)
        {
            _algorithm = alg;
        }

        public OperationResult MetodaDoTestów(int a, int b)
        {
            try
            {
                _algorithm.Simulation(new List<int>(), new int[] { 1 });
                if (a + b == 1)
                {
                    return new OperationResult(){Result = true,HasException = false};
                }
                return new OperationResult(){HasException = false,Result = false};
            }
            catch (Exception ex)
            {
                return new OperationResult() { HasException = true,exception = ex};
                
            }

            
            
        }
    }

    public class OperationResult
    {
        public bool HasException;
        public bool Result;
        public Exception exception;



    }
}
