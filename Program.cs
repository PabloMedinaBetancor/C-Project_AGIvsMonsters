using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(File.ReadAllText("../../../gamedescription.txt"));
            Console.ReadLine();
            Board b = new Board(10000, conf.startDif);
            initEntityB(b);
            while (b.dif <= conf.endgame)
            {
                while (b.isloss() == false && b.iswin() == false)
                {
                    b.timestep();
                }
                if (b.isloss())
                {
                    b.initmap(b.dif * conf.dificultydecreaseatloss);
                    initEntityB(b);
                    Console.WriteLine("La era de AGI llega a su fin, la era de los monstruos comienza!...(Dificultad rebajada)");
                }
                else if (b.iswin())
                {
                    b.initmap(b.dif * conf.dificultyincreaseatwin);
                    initEntityB(b);
                    Console.WriteLine("Enorabuena has ganado empezando nueva partida Dificultad Incrementada");
                }
                if (b.dif > conf.endgame)
                {
                    string k=" ";
                    while (k != "n" && k != "y")
                    {
                        Console.WriteLine("Has ganado, hecho lo imposible; restaurar a la humanidad? (y/n)");
                        k = Console.ReadLine();
                        if (k == "n") { Console.WriteLine("Has Fracasado"); }
                        if (k == "y") { Console.WriteLine("...bien hecho!"); }
                    }
                }
            }
        }
        static void initEntityB(Board b)
        {
            foreach (Entity e in b.E) {
                e.B = b;
                e.randpos();
            }
            
        }
    }
}
