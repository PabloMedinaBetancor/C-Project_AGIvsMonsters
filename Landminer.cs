using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Landminer : Entity
    {
        Landminer(float level) : base(level)
        {
            name = "Landminer";
        }

        new public void timestep()
        {  
            Sidewriter.write(name);
            string i = " ";
            while (!(i == "m" || i == "g"))
            {
                SideWriter.write("elige m: para colocar mina, g: para crecer");
                i = Console.ReadLine();
                if (i == "m")
                {
                    placelandmine();
                }
                else if (i == "g")
                {
                    grow();
                }
            }
            base.timestep();
            
        }
        public void placelandmine(string type)
        {
            base.B.E.Add(new Landmine(new Bomb(lv)));
            base.B.E[base.B.E.Count - 1].setasfriend();
            base.B.E[base.B.E.Count - 1].setposition(px, py);
            lv += conf.landminemonsterbasegrowthspeed;
        }
        public void grow()
        {
            lv += conf.landminemonsterfocusedgrowthspeed;
        }
        public void calcstats()
        {
            float r = HP / mxHP;
            mxHP = lv * conf.calcstats[name]["mxHPmult"];
            HP = r * mxHP;
            AP = lv * conf.calcstats[name]["APmult"];
            regHP = lv * conf.calcstats[name]["regHPmult"];
        }
    }
}
