using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Portal : Entity
    {
        public Portal(float level) : base(level)
        {
            base.name = "Portal";
        }
        new public void timestep()
        {
            lv += conf.Portalgrowthrate;
            if (lv > conf.Portalmaxlevel) { lv = conf.Portalmaxlevel; }
            Random r = new Random();
            if (r.NextDouble() > 0.5)
            {
                spawnmonster();
            }
            else { spawnwyvern(); }
        }
        public void spawnmonster()
        {
            base.B.E.Add(new Monster(lv));
            base.B.E[base.B.E.Count - 1].B = base.B;
            base.B.E[base.B.E.Count - 1].setasfoe();
            base.B.E[base.B.E.Count - 1].settarget(base.targetID);
            base.B.E[base.B.E.Count - 1].px = base.px;
            base.B.E[base.B.E.Count - 1].py = base.py;
        }
        new public void mapdisplay()
        {
            base.display();
            Console.Write('P');
        }
    }
}
