using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsProject
{
    class Globals
    {
        public static int NumberOfSimulations = 0;

        private readonly static Random rnd = new Random();

        public static double GenerateRandomDouble(double min, double max)
        {
            double returnVal = min + rnd.NextDouble() * (max - min);
            return returnVal;
        }
    }
}
