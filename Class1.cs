using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class SMR:NuclearReactor
    {
        public SMR(double lv, Dictionary<string, double> SC, Dictionary<string, List<Dictionary<double, double>>> IS) : base(lv, SC, IS) { }
    }
}
