using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class PowerAttackAxe : Skill
    {
        public PowerAttackAxe() : base("Power Axe Attack", 30, 5)
        {
            PublicName = "Power axe attack[requires axe]: 0.1 * Str + 0.1 * Pr damage[stab] and then 0.2 * St damage[blunt]";
            RequiredItem = "Axe";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage("stab");
            response1.HealthDmg = (int)(0.1 * player.Strength) + (int)(0.1 * player.Precision);
            StatPackage response2 = new StatPackage("blunt");
            response2.HealthDmg = (int)(0.2 * player.Strength);
            // applying CustomText only once is sufficient
            response2.CustomText = "You use axe power attack! It's super effective! (" + ((int)(0.1 * player.Strength) + (int)(0.1 * player.Precision)) + " stab damage, " + ((int)(0.2 * player.Strength)) + " blunt damage)";
            return new List<StatPackage>() { response1, response2 };
        }
    }
}
