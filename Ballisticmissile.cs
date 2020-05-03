using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ballisticmissile:Entity
    {
        int TTA = 0;
        bool launched = false;
        Bomb warhead;
        public Ballisticmissile(Board B,Bomb warhead):base(1.0f){
            base.B = B;
            this.warhead = warhead;
            movspeed = 120;
        }
        public void launch(int PX, int PY)
        {   
            TTA = (int)(DIST.calcdist(px, py, PX, PY) / movspeed);
            px = PX;
            py = PY;
            launched = true;
        }
        new public void timestep() {
            if (launched && TTA < 1)
            {
                detonation();
            }
            else if (TTA > 0) { TTA--;}
        }
        void detonation()
        {
            warhead.attack(px, py);
        }
    }
}
