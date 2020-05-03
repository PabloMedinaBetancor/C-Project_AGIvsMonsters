using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class DeathOverlord : Entity
    {
        double MP,mxMP, regMP, XP = 0;
        Army UndeadArmy;
        List<Entity> UndeadThralls;
        Spells spells;
        string Name = "DeathOverlord";
        public DeathOverlord(double level) : base(level)
        {
            init();
        }
        public DeathOverlord(double level, Board B, bool isplayer, bool isfoe, double px, double py, double pz) : base(level, B, isplayer, isfoe, px, py, pz)
        {
            init();
        }
        void init()
        {
            UndeadThralls = new List<Entity>();
            spells=new Spells();
            initstats();
        }
        void initstats()
        {   
            base.HP = conf.OverlordBaseHPPerLevel * base.lv;
            base.mxHP = HP;
            MP = conf.OverlordBaseMPPerLevel * base.lv;
            mxMP = MP;
            regMP = conf.OverlordBaseregMPPerLevel * base.lv;
        }
        void calcMP()
        {
            MP += regMP;
            if (MP > mxMP)
            {
                MP = mxMP;
            }
        }
        public void timestep()
        {
            calcMP();
            GatherTrallsXP();
            base.timestep();
            spells.UseSpell(conf.OverlordAvailableSpells,ref MP,ref HP,ref mxHP,ref XP,ref lv,base.B,ref UndeadThralls,ref px,ref py,ref pz);
            while (MayLevelUp())
            {
                LevelUP(); 
            }
            calcMP();
            FormArmy();
            UndeadArmy.PlayerMove();
        }
        void LevelUP()
        {
            if (MayLevelUp())
            {
                base.lv += 1;
                List<string> c=new List<string>();
                c.Add("mxMP");
                c.Add("regMP");
                c.Add("mxHP");
                c.Add("regHP");
                string C = Reader.TakeAChoice(c);
                XP = XP - conf.UndeadLevelUPXP * base.lv;
                if (C == "mxMP")
                {
                    mxMP += conf.UndeadIncreasePerLevel[C] * base.lv;
                }
                else if (C == "regMP")
                {
                    regMP += conf.UndeadIncreasePerLevel[C] * base.lv;
                }
                else if (C == "mxHP")
                {
                    mxHP += conf.UndeadIncreasePerLevel[C] * base.lv;
                }
                else if (C == "regHP")
                {
                    regHP += conf.UndeadIncreasePerLevel[C] * base.lv;
                }
            }
        }
        bool MayLevelUp()
        {
            bool r = false;
            if (XP > conf.UndeadLevelUPXP * base.lv)
            {
                r = true;
            }
            return r;
        }
        void GatherTrallsXP()
        {
            foreach (Entity Thrall in UndeadThralls)
            {
                XP += Thrall.XP;
                Thrall.XP =0.0;
            }
        }
        void FormArmy()
        {
            UndeadArmy = new Army(UndeadThralls);
        }
    }
}
