using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Mine : AGIExtension
    {
        string target;
        Mine(string target, double level, Dictionary<double, string> SC) : base(level, SC)
        {
            this.target = target;
        }
        new public void timestep()
        {
            base.timestep();
            produce();
        }
        public void produce()
        {
            base.SC[target] += GetMiningCapacity();
        }
        double GetMiningCapacity()
        {
            double r = base.getlevel() * conf.MiningKGPerLevelPerTurn[target];
            return r;
        }
    }
}
