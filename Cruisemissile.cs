using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Nuclearbombmonster : Monster
    {
        nuclearbomb load;
        public Nuclearbombmonster(float lv, nuclearbomb load) : base(lv)
        {
            this.load = load;
            name = "Nuclearbombmonster";
            movspeed = 2;
            AP = 0;
        }
        new public void move()
        {
            base.move();
            Sidewriter.write("Estas al mando de un monstruo que carga una bomba thermonuclear elige: d para detonar, u otra teclar para continuar");
            string o = Console.ReadLine();
            if (o == "d") { attack(); }

        }
        new public void attack()
        {
            Sidewriter.write("estas a punto de detonar un arma nuclear de " + load.KT +
                " KT, ¿estas seguro de que quieres detonarla? y: para detonar, otra tecla para cancelar");
            string o = Console.ReadLine();
            if (o == "y") { selfdestroy(); }
        }
        void selfdestroy()
        {
            load.attack(px, py);
            load = null;
            checkdeath();
        }


    }
}
