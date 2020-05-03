using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class Landmine : Entity
    {
        float mass;
        public Landmine(float mass) : base(1.0f)
        {
            this.mass = mass;
            movspeed = 0;
            calcstats();
        }
        new public void timestep()
        {
            base.timestep();
            if (thereshostiles(0))
            {
                attack(gethostile(0));
                HP = 0.0f;
                checkdeath();
            }
        }
        new public void calcstats()
        {
            HP = mass;
            mxHP = HP;
            AP = HP*100.0f;
        }
        public void mapdisplay() {
            base.display();
            Console.Write('l');
        }
    }
}
