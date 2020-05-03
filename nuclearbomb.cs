using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Nuclearbomb:Warhead
    {
        Dictionary<string,double> FiF;
        Dictionary<string,double> FuF;
        Dictionary<string,double> T;
        Dictionary<string, double> IS;
        double H3;
        public Nuclearbomb(List<string> FiF, List<string> FuF, List<string> T, bool PB, Board B,Dictionary <string,double> IS):base(B) {
            this.IS = IS;
            base.mass =0.0;
            double m = 0.0;
            for(int i=0;i<FiF.Count;i++) {
                if (i == 0)
                {
                    m = CalcMinPrimaryFissionFuelMass(FiF[0]);
                    this.FiF.Add(FiF[0],m);
                    m = CalcPrimaryTamperMass(FuF[i], m);
                    this.T.Add(T[i], m);
                }
                else {
                    m = CalcMinSecundaryFissionFuelMass(FiF[i]);
                    this.FiF.Add(FiF[i],m);
                    m = CalcSecundaryFusionFuelMass(FuF[i - 1]);
                    this.FuF.Add(FuF[i-1],m);
                    m = CalcFusionTamperMass(FuF[i],m);
                    this.T.Add(T[i],m);
                }
            }
            base.nass = CalcMass(this.FiF,this.FuF,this.T,H3);
        }
        double CalcMinPrimaryFissionFuelMass() { }
        double CalcPrimaryTamperMass() { }
        double CalcMinSecundaryFissionFuelMass() { }
        double CalcSecundaryFusionFuelMass() { }
        double CalcFusionTamperMass() { }
    }
}
