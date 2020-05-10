using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills
{
    [Serializable]
    class StaffBash : Skill
    {
        public StaffBash() : base("Staff bash", 10, 1)
        {
            PublicName = "Staff bash [requires staff]: 0.2 * St damage[blunt] ";
            RequiredItem = "Staff";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("blunt");
            response.HealthDmg = (int)(0.2 * player.Strength);
            return new List<StatPackage>() { response };
        }
    }
}
