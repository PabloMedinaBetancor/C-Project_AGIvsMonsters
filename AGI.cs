using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AGI : Entity
    {
        int TTC;
        string exec;
        Entity iteminprod;
        List<AGIExtension> expan;
        Dictionary<string, double> SC;
        Dictionary<string, List<Dictionary<double, double>>> IS;

        public AGI(double level) : base(level)
        {
            base.isplayer = true;
            name = "AGI";
            exec = "none";
            calcstats();
            HP = mxHP;
            SC = new Dictionary<string, double>();
            foreach (string k in conf.SC.Keys)
            {
                SC.Add(k, conf.SC[k]);
            }
            IS = new Dictionary<string, List<Dictionary<double, double>>>();
            expan = new List<AGIExtension>();
            init(conf.TurnsBeforeGame);
        }
        void init(int TurnsBeforeGame)
        {
            int RT = TurnsBeforeGame;
            SideWriter.Write("Tienes " + TurnsBeforeGame.ToString() + " turnos sin usar antes del inicio del juego");
            SideWriter.Write("A Continuacion se preguntara como esos turnos fueron aprovechados en cuanto a construccion de instalaciones");
            SideWriter.Write("Algunas instalaciones tienen capacidad quasi exponencial con respecto al tiempo usado en su produccion, dado que se usa MetaFactoria para hacer la instalacion en si");
            SideWriter.Write("Turnos a asignar " + RT.ToString());
            List<int> l = Reader.ReadIntList(conf.ExtensionNames);
            int i = 0;
            SideWriter.WriteFromFile("AGIunitsexplanation.txt");
            while (RT > 0)
            {
                RT -= l[i];
                if (RT >= 0)
                {
                    Build(l[i], conf.ExtensionNames[i]);
                    expan.Add(iteminprod.Clone());
                    iteminprod = null;
                    TTC = 0;
                    selfimprove();
                    i++;
                }
                if (i>=conf.ExtensionNames.Count)
                {
                    i = 0;
                }
            }
        }
        new public void timestep()
        {
            calcstats();
            base.timestep();
            if (exec == "selfimprove") { lv += conf.AGIfastgrowthrate; exec = "none"; }
            else if (TTC > 0) { TTC -= 1; }
            if (TTC == 0 && exec == "build")
            {
                iteminprod.px = px;
                iteminprod.py = py;
                expan.Add(iteminprod.Clone());
                expan[expan.Count - 1].B = B;
                exec = "none";
            }
            else
            {
                if (exec == "none") { DO(); }

            }
            lv += conf.BaseGrowthRate["AGI"];
            if (lv > conf.AGIMaxLevel)
            {
                lv = conf.AGIMaxLevel;
            }
            calcpowerdemand();
            expansionstimesteps();
        }
        public void expansionstimesteps()
        {
            for (int i = 0; i < expan.Count; i++)
            {
                expan[i].timestep();
            }
        }
        public void calcpowerdemand()
        {
            double p = 0;
            for (int i = 0; i < expan.Count; i++)
            {
                p += expan[i].electricpower;
            }
            electricpower = p;

        }
        public void selfimprove()
        {
            exec = "selfimprove";
        }
        public void Build(double PT, string type)
        {
            exec = "build";
            if ((type == conf.ExtensionNames[0]) || (type == conf.ShortExtensionNames[0]))
            {
                iteminprod = new Factory(PT, SC, IS);
            }
            else if ((type == conf.ExtensionNames[1])|| (type== conf.ShortExtensionNames[1]))
            {
                iteminprod = new Enrichmentfacility("U", PT, SC, IS);
            }
            else if ((type == conf.ExtensionNames[2]) || (type == conf.ShortExtensionNames[2]))
            {
                iteminprod = new PACER(PT, SC, IS);
            }
            else if ((type == conf.ExtensionNames[3]) || (type == conf.ShortExtensionNames[3]))
            {
                iteminprod = new Enrichmentfacility("Li", PT, SC, IS);
            }
            else if ((type == conf.ExtensionNames[4]) || (type == conf.ShortExtensionNames[4]))
            {
                iteminprod = new ResearchFacility("Nuclear",PT, SC);
            }
            else if ((type == conf.ExtensionNames[5]) || (type == conf.ShortExtensionNames[5]))
            {
                iteminprod = new Enrichmentfacility("D", PT, SC, IS);
            }
            else if ((type == conf.ExtensionNames[6]) || (type == conf.ShortExtensionNames[6]))
            {
                iteminprod = new Mine("U", PT, SC);
            }
            else if ((type == conf.ExtensionNames[7]) || (type == conf.ShortExtensionNames[7]))
            {
                iteminprod = new Mine("Th", PT, SC);
            }
            else if ((type == conf.ExtensionNames[8]) || (type == conf.ShortExtensionNames[8]))
            {
                iteminprod = new Mine("Be", PT, SC);
            }
            else if ((type == conf.ExtensionNames[9]) || (type == conf.ShortExtensionNames[9]))
            {
                iteminprod = new Mine("Li", PT, SC);
            }
            else if ((type == conf.ExtensionNames[10]) || (type == conf.ShortExtensionNames[10]))
            {
                iteminprod = new Mine("NFRCM", PT, SC);
            }
            else ((type == conf.ExtensionNames[11]) || (type == conf.ShortExtensionNames[11]))
            {
                iteminprod = new ResearchFacility("Magic",PT,SC);
            }
            iteminprod.setasfriend();
            TTC = (int)(iteminprod.GetBuildTime() / lv) + 1;
        }
        public void DO()
        {
            string r = " ";
            while (!((r == "a" && lv < conf.AGIMaxLevel) || r == "u"))
            {
                Sidewriter.write("Elige a:automejora, u: construir unidad");
                r = Console.ReadLine();
                if (r == "a")
                {
                    if (lv < conf.AGIMaxLevel) { selfimprove(); }
                    else
                    {
                        Sidewriter.write("AGI ya esta en su maximo nivel");
                        r = "u";
                    }
                }
                if (r == "u")
                {
                    SideWriter.Write("AGI: Menu de Produccion");
                    SideWriter.WriteFromFile("AGIunitsexplanation.txt");
                    string t = Reader.TakeAChoice(conf.ShortExtensionNames);
                    SideWriter.Write("Elige el multiplo de tiempo de produccion como double, a mayor tiempo," +
                        " mayor el nivel (En algunos casos el tiempo de produccion real puede ser muy largo)");
                    double ttc = Reader.ReadDouble();
                    Build(ttc, t);
                }
            }
        }
        new public void mapdisplay()
        {
            base.display();
            Console.Write('A');
        }
        public void calcstats()
        {
            movspeed = 0;
            AP = 0;
            mxHP = lv * 100000.0;
            regHP = mxHP / 10000.0;
        }
    }
}