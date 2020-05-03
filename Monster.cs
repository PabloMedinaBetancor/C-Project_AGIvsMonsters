using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Monster : Entity
    {   double maxlevel;
        public Monster(double level) : base(level)
        {
            __init__(conf.MonsterDefaultMaxlevel);
        }
        public Monster(double level,double maxlevel) : base(level)
        {
            __init__(maxlevel);
        }
        public void __init__(double maxlevel) {
            name = "Monster";
            calcstats();
            HP = mxHP;
            this.maxlevel = maxlevel;
        }
        new public void timestep()
        {
            calcstats();
            base.timestep();
            if (canGrow())
            {
                grow();
            }
        }
        public bool canGrow()
        {
            bool r = false;
            if (lv < maxlevel)
            {
                r = true;
            }
            return r;
        }
        public virtual void grow()
        {
            lv += 1.0f;
            calcstats();
        }
        public void calcstats()
        {
            double r = HP / mxHP;
            mxHP = lv;
            HP = r * mxHP;
            AP = lv * 0.1;
            regHP = lv * 0.02;
        }
    }
}
