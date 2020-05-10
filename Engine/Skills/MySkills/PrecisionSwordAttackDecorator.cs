using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class PrecisionSwordAttackDecorator : SkillDecorator
    {
        public PrecisionSwordAttackDecorator( Skill skill) : base("Precision Sword Attack", 10, 3, skill)
        {
            MinimumLevel = Math.Max(1, decoratedSkill.MinimumLevel) + 1;
            PublicName = "COMBO - Precision sword attack [requires sword]: 2 * Pr - 5 damage[stab] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Sword";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("stab");
            response.HealthDmg = (int)(2 * player.Precision) - 5;
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
