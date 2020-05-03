using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Reader
    {
        Sidewriter SW;
        Reader(Sidewriter SW)
        {
            this.SW = SW;
        }
        public static int ReadInt()
        {
            bool isint = false;
            int r = 0;
            while (!isint)
            {
                Sidewriter.Write("Introduce un numero entero");
                string s = Console.ReadLine();
                isint = int.TryParse(s,out r);
            }
            return r;
        }
        public static double ReadDouble() {
            bool isdouble = false;
            double r = 0;
            while (!isdouble)
            {
                Sidewriter.Write("Introduce un numero decimal, ejemplo: 5.5");
                string s = Console.ReadLine();
                isdouble= double.TryParse(s, out r);
            }
            return r;
        }
        public static bool ReadBool()
        {
            bool r = true;
            string s = " ";
            while (!(s == "y" || s == "n"))
            {
                Sidewriter.Write("(y/n)");
                s = Console.ReadLine();
                if (s == "y")
                {
                    r = true;
                }
                else if (s == "n")
                {
                    r = false;
                }
            }
            return r;
        }
        public static void TakeAChoice(List<string> Choices, List<string> Explanation) {
            Sidewriter.Write("Elige");
            Sidewriter.Write(Explanation);   
        }
    }
}
