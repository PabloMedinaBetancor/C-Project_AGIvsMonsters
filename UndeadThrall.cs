using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class UndeadThrall:Entity
    {
        string name;
        double XP;
        public UndeadThrall(double lv,Board B,double px, double py, string name) :base(lv, B, false, false, px, py, 0.0) {
            this.name = name;
            initstats();
        }
        new public void timestep()
        {
            base.timestep();
        }
        void initstats()
        {
            calcstats();
            HP = mxHP;
        }
        public void calcstats()
        {  
           mxHP = lv * conf.UndeadThrall["mxHP"][name];
           regHP= lv * conf.UndeadThrall["regHP"][name];
           movspeed=(int) (Math.Sqrt(lv)* conf.UndeadThrall["movspeed"][name]);
        }
    }
}
