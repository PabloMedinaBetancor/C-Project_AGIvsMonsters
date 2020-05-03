using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract public class Entity
    {
        public double px, py,pz, movspeed, attackdist = 1,ID;
        public int targetID = -1;
        public double HP, regHP, mxHP, lv, AP;
        public Bugkiller BK;
        public bool isplayer = false, alive = true, isfoe = true;
        public Board B;
        public string name = "Entity";
        List<double> movingTowards;
        public Entity(double level,Board B,bool isplayer,bool isfoe,double px, double py, double pz)
        {
            Init(level);
            this.B = B;
            this.isplayer = isplayer;
            this.isfoe = isfoe;
            if (isplayer)
            {
                this.isfoe = false;
            }
            this.px = px;
            this.py = py;
            this.pz = pz;
        }
        public Entity(double level)
        {
            Init(level);
        }
        void Init(double level) {
            movingTowards = new List<double> {-1.0,-1.0,-1.0};
            lv = level;
            BK = new Bugkiller();
            Random r = new Random();
            ID = r.NextDouble();
        }
        public void randpos()
        {
            Random r = new Random();
            px = r.Next(0, B.BZ - 1);
            py = r.Next(0, B.BZ - 1);
        }
        public void timestep()
        {
            checkdeath();
            if (alive)
            {
                HP += regHP;
                if (HP > mxHP) HP = mxHP;
                if (movspeed > 0)
                {
                    Move();
                }
            }
        }
        public void Move()
        {
            if (alive)
            {
                if (isplayer) { PlayerMove(); }
                else if (movingTowards[0] > -1) { AutoMove(movingTowards); }
                else if (targetID != -1) { AutoMove(B.E[targetID]); }
            }
        }
        void AutoMove(Entity T)
        {
            _AutoMove(T.px,T.py);
        }
        void AutoMove(List<double> movingTowards)
        {
            _AutoMove(movingTowards[0], movingTowards[1]);
            if((int) (movingTowards[0])==(int) (px) && (int)(movingTowards[1]) == (int)(py))
            {
                PositionHasBeenReached();
            }
        }
        void PositionHasBeenReached()
        {
            movingTowards[0] = -1;
        }
        void _AutoMove(double px,double py) {
            double mxmov = movspeed, moved = 0.0, movstep = 0.1;
            while (mxmov < moved)
            {
                double[] m = new double[2];
                if (px > this.px) m[0] += movstep;
                if (px < this.px) m[0] -= movstep;
                if (py > this.py) m[1] += movstep;
                if (py < this.py) m[1] -= movstep;
                if (AutoMovIsValid(m))
                {
                    Mov(m);
                }
                moved += movstep;
            }
        }
        public void MoveTowards(List<double> movingTowards)
        {
            this.movingTowards=movingTowards;
        }
        private void PlayerMove()
        {
            double[] m = GetMove();
            InRangeCheck(m);
            Mov(m);
        }
        void InRangeCheck(double [] m)
        {
            BK.inrange(ref m[0], B.BZ - 1);
            BK.inrange(ref m[1], B.BZ - 1);
        }
        private double[] GetMove()
        {
            double[] m = new double[2];
            ConsoleKey k = ConsoleKey.A;
            while (!(k == ConsoleKey.Enter || Math.Abs(m[0]) > movspeed || Math.Abs(m[1]) > movspeed))
            {
                k = Console.ReadKey().Key;
                if (k == ConsoleKey.UpArrow) { m[1] += 1; }
                if (k == ConsoleKey.DownArrow) { m[1] -= 1; }
                if (k == ConsoleKey.RightArrow) { m[0] += 1; }
                if (k == ConsoleKey.LeftArrow) { m[0] -= 1; }
            }
            for (int i = 0; i < 2; i++)
            {
                if (m[i] > movspeed) { m[i] = movspeed; }
                else if (m[i] < -movspeed) { m[i] = -movspeed; }
            }
            return m;
        }
        private double [] AddToPos(double [] m)
        {
            double[] p = new double[3];
            p[0] = m[0] + px;
            p[1] = m[1] + py;
            p[2] = m[2] + pz;
            InRangeCheck(p);
            return p;
        }
        bool AutoMovIsValid(double [] m)
        {
            double[] p = AddToPos(m);
            bool r = true;
            if (CheckForFoesInRange(p))
            {
                r = false;
                attack(ClosestFoe());
            }
            return r;
        }
        bool CheckForFoesInRange(double [] p)
        {
            bool r = false;
            
            return r;
        }
        private void Mov( double[] m)
        {
            px += m[0];
            py += m[1];
            if (m.Length > 2)
            {
                pz += m[2];
            }
        }
        public void attack(Entity a)
        {
            a.attacked(AP);
        }
        public void attacked(double AP)
        {
            HP -= AP;
            checkdeath();
        }
        public void checkdeath()
        {
            if (HP <= 0.0) alive = false;
        }
        public bool isalive()
        {
            return alive;
        }
        public void setasfoe()
        {
            isfoe = true;
        }
        public void setasfriend()
        {
            isfoe = false;
        }
        public bool isfriend()
        {
            if (isfoe == false) { return true; }
            return false;
        }
        public void settarget(int T)
        {
            targetID = T;
        }
        public void setasplayer()
        {
            setasfriend();
            isplayer = true;
        }
        public string getgenericname()
        {
            return name;
        }
        public void mapdisplay()
        {
            if (isfriend()) { Console.Write('a'); }
            else { Console.Write("h"); }
        }
    }
}
