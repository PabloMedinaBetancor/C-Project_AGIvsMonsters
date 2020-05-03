using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Graphics
    {
        public void ShowPOVfromPos(Board B, int px, int py, int ws)
        {
            int xs, ys;
            xs = ws;
            ys = ws;
            if (px + ws > B.BZ)
            {
                xs = px + ws - B.BZ;
            }
            if (py + ws > B.BZ)
            {
                ys = py + ws - B.BZ;
            }
            for (int y = 0; y < ys; y++)
            {
                for (int x = 0; x < xs; x++)
                {
                    int npx = x + px, npy = y + py;
                    Console.SetCursorPosition(x, y);
                    if (B.TerrainInPos(npx, npy) == "Sea") { Console.ForegroundColor = ConsoleColor.Blue; }
                    if (B.StrongestUnitInPosIsFriend(npx, npy)) { Console.ForegroundColor = ConsoleColor.Green; }
                    if (B.StrongestUnitInPosIsFoe(npx, npy)) { Console.ForegroundColor = ConsoleColor.Red; }
                    Console.WriteLine(B.StrongestUnitInPos(npx, npy));
                }
            }
        }
    }
}
