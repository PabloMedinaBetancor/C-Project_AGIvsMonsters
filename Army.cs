using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Army
    {
        List<double> movingTowards;
        List<Entity> members;
        public Army(List<Entity> members) {
            this.members = members; 
        }
        public void Move() {
            foreach (Entity m in members) {
                m.MoveTowards(movingTowards);
            }
        }
    }
}
