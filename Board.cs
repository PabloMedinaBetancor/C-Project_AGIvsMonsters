using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Board
    {
        Bugkiller BK = new Bugkiller();
        public List<Entity> E;
        public int BZ, WS = 30;
        public double dif;
        public CellGrid cells;
        public Board(int boardsize, float dif)
        {
            this.dif = dif;
            BZ = boardsize;
            initmap(dif);
            cells = new CellGrid(BZ,BZ);
        }
        public void FullEntityMapping()
        {
            cells.InitEntityMap();
            foreach(Entity e in E)
            {   
                cells.AddEntity(e);
            }
        }
        public void EntityMappingMove(Entity e)
        {
            cells.MoveEntityMap(e,e.px,e.py,e.ppx,e.ppy);
        }
        public void DelEntity(Entity e)
        {
            cells.DelEntityMap(e,e.px,e.py);
        } 
        public void initmap(double dif)
        {
            E = new List<Entity>();
            E.Add(new AGI(conf.AGIStartLv));
            E[0].setasplayer();
            Console.WriteLine(E[0].name);
            for (int n = 0; n < Math.Sqrt(BZ); n++)
            {
                E.Add(new Portal(dif));
                E[E.Count - 1].settarget(0);
            }
            E.Add(new DeathOverlord(conf.DeathOverlordStartLv));
            E[E.Count - 1].setasplayer();
            FullEntityMapping();
        }
        public void timestep()
        {
            FullEntityMapping();
            for (int n = 0; n < E.Count; n++)
            {
                System.Threading.Thread.Sleep(5000);
                displayliving();
                E[n].timestep();
                displayliving();
            }
            DelTheDead();
        }
        void DelTheDead()
        {
            int i = 0;
            while (!(i > E.Count-1))
            {
                if (E[i].alive == false) { E.RemoveAt(i); i--; }
                i++;
            }
        }
        void displayliving()
        {
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].alive)
                {
                    E[i].mapdisplay();
                }
            }
        }
        public bool iswin()
        {
            string r = winlossnull();
            if (r == "win") {return true; }
            return false;

        }
        public bool isloss()
        {
            string r = winlossnull();
            Console.WriteLine(r);
            if (r == "loss") { return true; }
            return false;
        }
        public string winlossnull()
        {
            bool theresAGI = false, theresfoes = false;
            for (int i=0;i<E.Count;i++)
            {
                Console.WriteLine(E[i].name);
                if (E[i].name=="AGI") { theresAGI = true; }
                else if (E[i].isfoe)
                {
                    theresfoes = true;
                }
            }

            if (theresAGI && (theresfoes == false))
            {
                return "win";
            }
            if (theresAGI == false) { return "loss"; }
            return "null";
        }
    }
}
