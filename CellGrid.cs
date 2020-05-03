using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class CellGrid
    {
        double X, Y;
        List<List<List<Entity>>> E;
        List<List<string>> CT;
        public CellGrid(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
            InitCellTypes();
            InitEntityMap();
        }
        public void InitCellTypes()
        {
            CT = List<List<string>>();
            for (int x = 0; x < X; x++)
            {
                CT.Add(new List<string>());
                for (int y = 0; y < Y; y++)
                {
                    CT[x].Add();
                }
            }
        }
        public void InitEntityMap()
        {
            E = new List<List<List<Entity>>>();
            for (int x = 0; x < X; x++)
            {
                E.Add(new List<List<Entity>>());
                for (int y = 0; y < Y; y++)
                {
                    E[x].Add(new List<Entity>());
                }
            }
        }
        public void AddEntity(Entity e)
        {
            E[(int)(e.px)][(int)(e.py)].Add(e);
        }
        public void MoveEntityMap(Entity e,double px,double py,double ppx,double ppy)
        {
            DelEntityMap(e,ppx,ppy);
            AddEntity(e);
        }
        public void DelEntityMap(Entity e,double PX,double PY)
        {
            int i = 0, c = 0;
            while (i < E[(int)(PX)][(int)(PY)].Count && c == 0)
            {
                if (E[(int)(PX)][(int)(PY)][i].ID==e.ID)
                {
                    c += 1;
                    E[(int)(PX)][(int)(PY)].RemoveAt(i);
                }
                i++;
            }
        }
    }
}
