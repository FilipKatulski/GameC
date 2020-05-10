using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Orc : Monster
    {
        public Orc(int orcLevel)
        {
            Health = 30 + 10 * orcLevel;
            Strength = 20 + orcLevel;
            Armor = 10;
            Precision = 20;
            MagicPower = 0;
            Stamina = 100;
            XPValue = 70 + orcLevel;
            Name = "orc" + (orcLevel+1).ToString().PadLeft(4,'0');
            BattleGreetings = "Whaaaaaaaagh!"; 
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 20;
                return new List<StatPackage>() { new StatPackage("blunt", 15 + Strength, "Orc uses fists! (" + (15 + Strength) + " blunt damage)") };
            }
            else
            {
                Health -= 2; //self harm
                return new List<StatPackage>() { new StatPackage("none", 0, "Orc swings his arms, barely breathing!") };
            }
        }
    }
}
