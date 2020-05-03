using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Task;
namespace ConsoleApp1
{
    public class Factory : AGIExtension 
    {
        string name = "Airforcefactory";
        List<string> specialization;
        
        public Factory(double level, bool issubterranean, Dictionary<string, double> SC, string specialization) : base(level, SC, issubterranean) { __init__(specialization); }
        public Factory(double level, Dictionary<string, double> SC, string specialization) : base(level, SC) { __init__(specialization); }
        void __init__(string specialization)
        {
            this.specialization = specialization;
            calcgrowthspeed(conf.VehiclefactoryMetafactoryspeed);
        }
        new public void getturnstobuild(ref int t)
        {
            t = base.getturnstobuild(t, conf.AirForceFactoryMinConstructiontime[specialization]) + 1;
        }
        new public void timestep()
        {
            if (isnotproducing())
            {

            }
            base.timestep();
        }
        void setspecialization() { }
        void setsubspecialization() { }
        void Produce(int ammount)
        {
            Entity r;
            Sidewriter.write(name + " " + specialization + " " + subspecialization);
        }
    }
}
