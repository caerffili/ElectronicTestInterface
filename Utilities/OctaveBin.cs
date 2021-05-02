using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class OctaveBin
    {
        public OctaveBin(int Size)
        {
            FrequencyOct = new double[Size];
            ResponseValOct = new double[Size];

            for (int i = 0; i < Size; i++)
            {
                ResponseValOct[i] = -1000;
            }
        }

        public double[] FrequencyOct;
        public double[] ResponseValOct;
    }
}
