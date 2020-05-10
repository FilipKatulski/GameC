using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class MySkillsFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); // check what skills from MySkills category are known by the player already
            if (known == null) // no skills known - we will return one of them
            {
                PowerAttackAxe a1 = new PowerAttackAxe();
                PrecisionSwordAttack a2 = new PrecisionSwordAttack();
                StaffBash a3 = new StaffBash();
                
                List<Skill> tmp = new List<Skill>();
                if (a1.MinimumLevel <= player.Level) tmp.Add(a1); // check level requirements
                if (a2.MinimumLevel <= player.Level) tmp.Add(a2);
                if (a3.MinimumLevel <= player.Level) tmp.Add(a3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // a created by me skill has been already learned, use decorator to create a combo
            {
                PowerAttackAxeDecorator a1 = new PowerAttackAxeDecorator(known);
                PrecisionSwordAttackDecorator a2 = new PrecisionSwordAttackDecorator(known);
                StaffBashDecorator a3 = new StaffBashDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (a1.MinimumLevel <= player.Level) tmp.Add(a1); // check level requirements
                if (a2.MinimumLevel <= player.Level) tmp.Add(a2);
                if (a3.MinimumLevel <= player.Level) tmp.Add(a3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // a combo of my skills has been already learned - this factory doesn't offer double combos so we stop here
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is StaffBash || skill is StaffBashDecorator || skill is PrecisionSwordAttack || skill is PrecisionSwordAttackDecorator || skill is PowerAttackAxe || skill is PowerAttackAxeDecorator) return skill;
            }
            return null;
        }
    }
}
