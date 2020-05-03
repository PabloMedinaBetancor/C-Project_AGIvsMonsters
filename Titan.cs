using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Titan : Entity
    {
        bool feed = true;
        public Titan(double lv) : base(lv)
        {
            name = "Titan";
            calcstats();
            HP = mxHP / 10.0;
        }
        new public void timestep()
        {
            base.timestep();
            Sidewriter.write("¿Alimentarse de monstruos?");
            feed = Reader.readBool();
            attack();
        }
        public void calcstats()
        {
            mxHP = lv * lv;
            AP = lv * 1000.0;
            attackdist = (int)(Math.Sqrt(lv) + 1);
            movspeed = (int)(Math.Sqrt(lv) + 1);
        }
        new public void attack()
        {
            if (feed) { eat(randomclosesthostile()); }
            else
            {
                List<Entity> e = hostilesinrange();
                for (int i = 0; i < e.Count; i++) { base.attack(e[i]); }
            }
        }
        public void eat(Entity meal)
        {
            if (meal.name == "Monster")
            {
                lv += 0.001 * meal.lv;
                HP = HP * 1.05 * meal.lv;
            }
            else { base.attack(meal); }
            calcstats();
        }
    }
}
