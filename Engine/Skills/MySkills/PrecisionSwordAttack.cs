using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class PrecisionSwordAttack : Skill
    {
        public PrecisionSwordAttack() : base("Precision Sword Attack", 10, 3)
        {
            PublicName = "Precision sword attack [requires sword]: 2 * Pr - 5 damage[stab] ";
            RequiredItem = "Sword";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("stab");
            response.HealthDmg = (int)(2 * player.Precision) - 5;
            return new List<StatPackage>() { response };
        }
    }
}
