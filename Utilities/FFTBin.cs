using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class FFTBin
    {
        public FFTBin(int Size)
        {
            Frequency = new double[Size];
            ResponseVal = new double[Size];
            Scanned = new bool[Size];

            for (int i = 0; i < Size; i++)
            {
                ResponseVal[i] = -1000;
                Scanned[i] = false;
            }
        }

        public double[] Frequency;
        public double[] ResponseVal;
        public bool[] Scanned;
    }
}
