using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;
namespace ConsoleApp1
{
    public class Factory : AGIExtension
    {
        string name = "Factory", specialization, subspecialization;
        List<Entity> inProd;
        public Factory(double level, Dictionary<string, double> SC) : base(level, SC, "Fact", "Fact")
        {

            specialization = ChangeSpecialization();
        }
        new public void timestep()
        {
            if (isnotproducing())
            {
                AskPlayer();
            }
            else
            {
                Produce();
            }
            base.timestep();
        }
        string ChangeSpecialization()
        {
            Sidewriter.Write("Factoria: Elige especializacion");
            List<string> cho = { "DeathOverlord", "Missile", "NuclearBomb", "NuclearMissile", "SMR" };
            List<string> expl = { "Mago No Muerto Artificial", "Tiempo de produccion aumenta con alcanze y masa de cabeza (puede equipar cabeza nuclear, pero usa carga convencional por defecto)",
                "Bombas nucleares varias sin sistema de lanzamiento","Misiles con cabeza nuclear","Reactores nucleares de Fision Modulares"};
            return Reader.TakeAChoice(cho, expl);
        }
        void Produce(int ammount)
        {
            SideWriter.Write("Seleciona numero de unidades a producir en el Lote");
            int lotSize = Reader.ReadInt();
            Sidewriter.write(name + " " + specialization);
            if (specialization == "DeathOverlord")
            {
                for (int i = 0; i < lotSize; i++)
                {
                    inProd.Add(new DeathOverlord());
                }
            }
            else if (specialization == "Missile" || specializacion == "NuclearMissile")
            {
                SideWriter.Write("Seleciona masa que puede ser lanzada por el cohete");
                double trowmass = Reader.ReadDouble();
                SideWriter.Write("Seleciona alcanze en KM (cada casilla es 1 KM)");
                double range = Reader.ReadDouble();
                SideWriter.Write("Elige Balistico o de crucero (balistico es mas rapido, pero el de crucero se maneja como una unidad mas)");
                bool b = Reader.ReadBool();
                for (int i = 0; i < lotSize; i++)
                {
                    bool n = false;
                    if (specialization == "NuclearMissile")
                    {
                        n = true;
                    }
                    if (b)
                    {
                        inProd.Add(new BallisticMissile(trowmass, range, n));
                    }
                    else
                    {
                        inProd.Add(new CruiseMissile(trowmass, range, n));
                    }
                }

            }
            else if (specialization == "NuclearBomb")
            {
                bool addStage = true;
                List<string> FiF = new List<string>();
                List<string> FuF = new List<string>();
                List<string> T = new List<string>();
                bool PB = true;
                while (addStage)
                {
                    SideWriter.Write("Elige Combustible de fision a usar(si no tienes suficientes materiales las bombas no se completaran)");
                    List<string> c = new List<string> { "HEU", "U233", "Pu239" };
                    FiF.Add(Reader.TakeAChoice(c));
                    if (FiF.Count > 1)
                    {
                        SideWriter.Write("Elige Combustible principal de fusion a usar (HELi usara Litio lo mas enriquecido posible)");
                        List<string> c = new List<string> { "HELi", "LEli", "D", "1P_9D" };
                        FuF.Add(Reader.TakeAChoice(c));
                        SideWriter.Write("Elige Material usado para el tamper para contener el combustible nuclear (IM es material inerte, no aumenta la potencia de detonacion de forma sustancial)");
                        List<string> c = new List<string> { "LEU", "HEU", "IM", "Th" };
                        T.Add(Reader.TakeAChoice(c));
                    }
                    else
                    {
                        SideWriter.Write("Elige Material usado para contener el combustible nuclear y reflejar neutrones de vuelta al primario (Be es el mejor para bombas con multiple etapa)");
                        List<string> c = new List<string> { "LEU", "HEU", "Be" };
                        T.Add(Reader.TakeAChoice(c));
                        SideWriter.Write("Elige si usar DTboosting en el primario" +
                         " (aumenta eficiencia y reduce masa en el primario aunmentado la multiplicacion posible en la siguiente etapa, consume 1 a 3 gramos de tritio)");
                        PB = Reader.ReadBool();
                    }
                    SideWriter.Write("¿Añadir etapa nuclear?");
                    addStage = Reader.ReadBool();
                }
                for (int i = 0; i < lotSize; i++)
                {
                    inProd.Add(new Nuclearbomb(FiF, FuF, T, PB));
                }
            }
            else if (specialization == "SMR")
            {
                SideWriter.Write("Seleciona el tipo de reactor de Fision");
                List<string> c = new List<string> {"Heavy Water Rector (Requiere Uranio Natural)","Light Water Reactor (Requiere Uranio a mas del 2.5%)",
                    "Sodium Cooled Fast Breeder Reactor (Requiere Uranio al 20% o Pu239 o U233 Crea su propio combustible con U238 o Torio)"};
                string type = Reader.TakeAChoice(c);
                SideWriter.Write("Seleciona Los MW termicos del reactor min 50, max 500(Pueden dedicarse a una Extension De AGI reduciendo costes de expansion)");
                double MW = Reader.ReadDouble();
                for (int i = 0; i < lotSize; i++)
                {
                    inProd.Add(new SMR(type, MW));
                }
            }
        }
    }
}
