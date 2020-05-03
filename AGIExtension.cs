using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class AGIExtension : Entity
    {
        double growthspeed = 0, selfreplicatingfactorylevel, MWhe;
        List<NuclearReactor> SMRs;
        Dictionary<string, double> SC;
        string name,subName;
        public AGIExtension(double level, Dictionary<string, double> SC, string name,string subName) : base(level)
        {
            __init__(SC, name,subName);
        }
        void __init__(Dictionary<string, double> SC, string name,string subName)
        {
            this.name = name;
            this.subName = subName;
            selfreplicatingfactorylevel = lv;
            this.SC = SC;
            movspeed = 0;
            CalcStats();
        }
        public void CalcStats()
        {
            HP = lv * conf.ExtensionHPmult[name]*GetLevel(); regHP = lv * conf.ExtensionRegHPmult[name]*GetLevel();
            CalcGrowthSpeed();
        }
        public double GetBaseBuildTime(double m)
        {
            return Math.Sqrt(m) * conf.BaseBuildTime[name] * GetPowerAcessMult();
        }
        new public void timestep()
        {
            base.timestep();
            addtolevel(growthspeed);
            CalcStats();
        }
        new public void attacked(double AP)
        {
            base.attacked(AP);
        }
        new public bool isalive()
        {
            return base.isalive();
        }
        public void setlevel(double level)
        {
            base.lv = level;
        }
        public double GetLevel()
        {
            return base.lv;
        }
        public void addtolevel(double add)
        {
            lv += add;
        }
        public void CalcGrowthSpeed()
        {
            growthspeed = selfreplicatingfactorylevel * conf.MetaFactorySpeed[name] * GetPowerAcessMult();
        }
        public double GetPowerAcessMult()
        {
            CalcMWhe();
            double r = 1.0;
            if (SMRs.Count > 1)
            {
                double MWhe = 0.0;
                for (int i = 0; i < SMRs.Count; i++)
                {
                    MWhe += SMRs[i].MWhe;
                }
                if (MWhe <= this.MWhe) { r = 1.0 - ((MWhe / this.MWhe) * BaseBuildTimeMaxFractionalReductionFromSMR[name]); }
                else { r = 1.0 - BaseBuildTimeMaxFractionalReductionFromSMR[name]; }
            }
            return r;
        }
        void CalcMWhe()
        {
            double r = GetLevel() * conf.MWhPerLevel[subName];
            if (name=="NR") { r = r * conf.ReactorEfficiency[subName]; }
            MWhe = r;
        }
    }
}
