using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Nuclearmissilefactory: Entity
    {   List <Entity> weaponry;
        List <Entity> inprod;

        public Nuclearmissilefactory(float lv,bool roaming):base(lv) {
            movspeed = 0;
            if (roaming) { movspeed = 1;}

        }
        public void ProduceLot(int number)
        {   
            Sidewriter.write("¿Producir missiles balisticos?");
            bool t = Reader.readBool();
            string et = " ";
            if (t)
            {
                type = "ballistic";
            }
            else { type = "cruise";
                Sidewriter.write("Elige motor: tu: turbofan, ra: Ramjet");
                while(!(et=="tu" || et=="ra"))
                {
                    et = Console.ReadLine();
                }
            }
            Sidewriter.write("Elige alcanze de misiles a producir en primer lote como un int Recomendado:(>500 , <2000)");
            r = Reader.readInt();
            Sidewriter.write("Elige KT de la cabezas nucleares a producir recomendado: (suficiente como para que sea efectivo >10KT" +
             " no demasiado como para que sea muy peligroso < 10000 KT)");
            KT = Reader.readDouble();
            Sidewriter.write("elige numero de cabezas por misil (acelera produccion relativa al numero de cabezas, no aplicable a misiles lanzados a <200 casillas)");
            Nwarheads = Reader.readInt();
        }
    }
}
