using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Writer
    {
        int x, y;
        List<List<int>> p;
        public Writer() { }
        public void Write() {
            Console.; }
        public void Clean()
        {
            for (int i = 0; i < p.Count; i++)
            {  
                Console.SetCursorPosition(p[i][0],p[i][1]);
                Console.WriteLine(" ");
            }
        }
    }
}
