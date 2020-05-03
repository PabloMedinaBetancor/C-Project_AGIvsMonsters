using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Dragonlord : Monster, Immortal
	{
		public Dragonlord(float level):base(level)
		{
			base.movspeed = 10;
			base.name = "Dragonlord";
		}
		public override void grow()
		{
			base.lv += 0.5f;
			calcstats();
		}
		public void resucitate()
		{
			if (base.HP == 0)
			{
				grow();
				base.lv = base.lv * 0.9f;
				base.HP = mxHP;
			}
		}
		new public void fulldisplay()
		{
			if (isfriend())
			{
				Console.Write("Aliado");
			}
			if (isfoe) { Console.WriteLine("Enemigo"); }
			Console.WriteLine("DragonLord");
		}
		new public void mapdisplay()
		{
			base.display();
			Console.Write('D');
		}
	}
}