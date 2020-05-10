using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class OrcWarboss : Monster
    {
        public OrcWarboss(int orcLevel)
        {
            Health = 50 + 10 * orcLevel;
            Strength = 20 + orcLevel;
            Armor = 20;
            Precision = 15;
            MagicPower = 0;
            Stamina = 150;
            XPValue = 100 + orcLevel;
            Name = "orcwarboss" + (orcLevel + 1).ToString().PadLeft(4, '0');
            BattleGreetings = "For Gork! For Mork!";
        }

        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 20;
                return new List<StatPackage>() { new StatPackage("cut", 25 + Strength, "Orc uses stone knife! (" + (25 + Strength) + " cut damage)") };
            }
            else
            {
                Stamina += 21; //regeneration
                return new List<StatPackage>() { new StatPackage("blunt", 10, "Tired Orc pushes you away to gain ground!") };
            }
        }
    }
}
