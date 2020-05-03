using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp1
{
    public class Spells
    {

        Dictionary<string, int> SpellCount;
        public Spells()
        {
            SpellCount = new Dictionary<string, int>();
        }
        public void UseSpell(List<string> availablespells, ref double MP, ref double HP, ref double mxHP, ref double XP, ref double lv, Board B, List<Entity> UndeadThralls,
            ref double px,ref double py, ref double pz)
        {
            string s = Reader.TakeAChoice(availablespells);
            if (s == "Create Undead" && MP>=conf.SpellMPCost["DeathKnight"])
            {
                UndeadThralls.Add(CreateUndead(ref MP, ref lv,B, ref px, ref py));
                B.AddEntity(UndeadThralls[UndeadThralls.Count - 1]);
            }
            if (MP >= SpellMPCost[s])
            {
                if (s == "Death")
                {
                    Death(ref MP,ref XP,B);
                }
                else if (s == "Teleport")
                {
                    Teleport(ref MP,ref px,ref py,ref pz);
                }
            }
        }
        public Entity CreateUndead(ref double MP, ref double lv,Board B, ref double px, ref double py)
        {
            List<string> c = new List<string>();
            foreach (string thralltype in conf.ListOfThrallTypes)
            {
                if (lv > conf.CreateUndeadMinLevel[thralltype] && MP > conf.SpellMPCost[thralltype])
                {
                    c.Add(thralltype);
                }
            }
            string C = Reader.TakeAChoice(c);
            SpellCount[C] += 1;
            MP -= conf.SpellMPCost[C];
            return new UndeadThrall(GetUndeadThrallBaseLevel(C, lv) , B ,px, py,C);
        }
        double GetUndeadThrallBaseLevel(string ThrallName, double lv)
        {
            return Math.Sqrt(Math.Sqrt(SpellCount[ThrallName]) * lv);
        }
        void Death(ref double MP, ref double XP,Board B)
        {
            Entity E = B.ChooseTarget();
            double MPcost = Math.Sqrt(E.lv) * conf.SpellMPCost["Death"];
            double dmg;
            if (MPcost<=MP) {
                MP -= MPcost;
                dmg += E.HP;
                E.Dies();
            }
            else {
                dmg = E.HP / (MP / MPcost);
                MP = 0;
                E.HP -= dmg;
            }
            XP += dmg;
        }
        void Teleport(ref double MP,ref double px,ref double py, ref double pz)
        {
            SideWriter.Write("introduce x , y, z; coordenadas de teletransporte");
            px = Reader.ReadDouble();
            py = Reader.ReadDouble();
            pz = Reader.ReadDouble();
            BK.inrange(px, B.BZ);
            BK.inrange(py, B.BZ);
            BK.inrange(pz, B.BZ);
            MP -= conf.SpellMPCost["Teleport"];
       
        }   
    }
}
