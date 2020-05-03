using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class EnrichmentFacility: AGIExtension
    {
        string target;
        double InputRatio, Enrichment, WasteRatio;
        public EnrichmentFacility(string target, double level, Dictionary<double, string> SC, Dictionary<string, List<Dictionary<double, double>>> IS) : base(level, SC)
        {
            this.target = target;
            InformPlayer();
            InitEnrichment();
        }
        new public void timestep()
        {
            base.timestep();
            produce();
        }
        public void produce()
        {
            base.SC[target] += GetEnrichmentCapacity();
        }
        double GetEnrichmentCapacity()
        {
            if (target == "D")
            {
                base.lv;
            }
            else { }
            
        }
        void InitEnrichment() {
            if (target == "U" || target == "Li")
            {
                SideWriter.Write("seleciona la Fraccion del Total de Recurso bruto a usar para enriquecimiento, si esta va a ser la unica planta de enriquecimiento para ese recurso puedes poner 1.0, " +
                    "si no  elige numero menor que 1, si varias plantas compiten por el mismo recurso se distribuira segun el valor dado");
                double InputRatio = Reader.ReadDouble();
            }
        }
        void InformPlayer()
        {
            SideWriter.Write("A mayor desecho genere la planta mayor la cantidad que se puede separar, " +
                "a menos enriquecimiento mayor cantidad de salida, usa grandes cantidades de material para enriquecer mas rapido");
            if (target == "U") {
                SideWriter.Write("Enriquecedora de Uranio, Enriquece al >80% para primarios de Uranio, >50% para Sparkplugs, cualquier enriquecimiento para Fusion Tamper");
            }
            else if(target== "D") { 
                SideWriter.Write("Enriquecedora de Hidrogeno, Enriquece al >90% para usarlo como combustible termonuclear y moderador de neutrones"); }
            else if(target == "Li") {
                SideWriter.Write("Enriquecidora de Litio, Enriquece a menos del 97% para usarlo como combustible termonuclear (requiere deuterio para ese proposito)");
            }
        }
    }
}
