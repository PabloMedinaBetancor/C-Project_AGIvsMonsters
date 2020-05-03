using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Mortarmonster : Entity
    {
        Mortarmonster(double level) : base(level)
        {
            name = "Mortarmonster";
            calcstats();
            HP = mxHP;
        }

        new public void timestep()
        {
            Sidewriter.write(name);
            string i = " ";
            while (!(i == "m" || i == "g" || i=="f"))
            {
                SideWriter.write("elige m: para colocar mina de baja calidad, g para crecer, f para usar mortero");
                i = Console.ReadLine();
                if (i == "m")
                {
                    placelandmine();
                }
                else if (i == "g")
                {
                    grow();
                }
                else if (i == "f")
                {
                    mortarfire();
                }
            }
            base.timestep();
        }
        public void placelandmine()
        {
            base.B.E.Add(new Landmine(lv*conf.Mortarmonsterlandminemult));
            base.B.E[base.B.E.Count - 1].setasfriend();
            base.B.E[base.B.E.Count - 1].setposition(px, py);
        }
        public void grow()
        {
            lv += conf.Mortarmonstergrowthspeed;
            calcstats();
        }
        public void mortarfire()
        {
            base.longrangeattack(lv*conf.Mortarfiremult,conf.Mortarfirerange);
        }
        public void calcstats()
        {
            
        }
    }
}
