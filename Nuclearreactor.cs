using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class NuclearReactor : AGIExtension
    {
        Dictionary<string, double> I;
        Dictionary<string, double> O;
        Dictionary<string, List<Dictionary<double, double>>> IS;
        public NuclearReactor(double level, Dictionary<string, double> SC, Dictionary<string, List<Dictionary<double, double>>> IS, Dictionary<string, double> input, Dictionary<string, double> output) : base(level, SC)
        {
            this.IS = IS;
            Init(input, output);
        }
        public NuclearReactor(double level, Dictionary<string, double> SC, Dictionary<string, List<Dictionary<double, double>>> IS) : base(level, SC)
        {
            this.IS = IS;
        }
        public void Init(Dictionary<string, double> input, Dictionary<string, double> output) {
            I = input;
            O = output;
        }
        new public void timestep()
        {
            base.timestep();
            List<Dictionary<string, double>> IOA = GetMaterialUse(inputratio, outputratio);
            int v = 0;
            for (int i = -1; i < 2; i = i + 2)
            {
                foreach (string s in IOA[i].Keys)
                {
                    base.SC[s] += IOA[v][s];
                }
                v += 1;
            }
        }
        public List<Dictionary<string, double>> GetMaterialUse(Dictionary<string, double> I, Dictionary<string, double> O)
        {
            List<Dictionary<string, double>> IOA = new List<Dictionary<string, double>>();
            for (int i = 0; i < 2; i++)
            {
                IOA.Add(new Dictionary<string, double>());
                if (i == 0)
                {
                    foreach (string s in I.Keys)
                    {
                        IOA[i].Add(I[s],);
                    }
                }
                else if (i == 1)
                {

                }
            }

            return IOA;
        }
    }
}


