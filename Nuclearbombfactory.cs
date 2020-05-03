using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;

namespace ConsoleApp1
{
    public class Nuclearbombfactory : AGIExtension
    {
        public Nuclearbombfactory(double lv, Dictionary<double, string> SC, List<Nuclearbomb> NB):base(lv,SC,true) { }
        new public void timestep()
        {
            base.timestep();
            if (productisready())
            {
                for (int i = 0; i < bombsready.Count; i++)
                {
                    NB.Add(bombsready[i]);
                }
                bombsready = List<Nuclearbomb>();
            }
            if (isfree())
            {
                produce();
            }
        }
        public void produce()
        {   
            int n;
            for (int i = 0; i < n; n++)
            {
                bombsonthemaking.Add(make_nuclearbomb(fissionfuel));
            }
        }
        public Nuclearbomb make_nuclearbomb(List<string> fissionfuelperstage, List<List<string>> fusionfuelsperstage,
            List<string> mainTamperperstage, List<bool> useDTBoostingperstage, double bombmass, List<string> shapeperstage)
        {
            Nuclearbomb bomb = new Nuclearbomb();
            for (int i = 0; i < shapeperstage.Count; i++)
            {
                if (i == 0) { bomb.KT += ; }
                else
                {

                }
            }
            return bomb;
        }
    }
}
