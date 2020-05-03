using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bugkiller
    {
        public void inrange(ref double x, double xl)
        {
            if (x < 0) x = 0.0;
            else if (x > xl-1) x = xl - 1;
        }
    }
}
