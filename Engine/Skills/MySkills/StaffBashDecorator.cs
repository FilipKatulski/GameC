using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class StaffBashDecorator : SkillDecorator
    {
        public StaffBashDecorator(Skill skill) : base("Staff bash", 10, 1, skill)
        {
            MinimumLevel =  1;
            PublicName = "COMBO - Staff bash [requires staff]: 0.2 * St damage[blunt] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Staff";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("blunt");
            response.HealthDmg = (int)(0.2 * player.Strength);
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
