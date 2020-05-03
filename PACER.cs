using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class PACER: NuclearReactor
    {
        public PACER(double lv, Dictionary<string, double> SC, Dictionary<string, List<Dictionary<double, double>>> IS) :base(lv,SC,IS) {
        
            
        
        }
    }
}
