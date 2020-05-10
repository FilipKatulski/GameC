using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class OrcFactory : MonsterFactory
    {
        // this factory produces  orcs or orc warbosses
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber <= 2) // up to 3 encounters -  returns an orc 
            {
                encounterNumber++;
                return new Orc(playerLevel);
            }
            else if (encounterNumber == 3) // 4 times - returns an orc warboss
            {
                encounterNumber++;
                return new OrcWarboss(playerLevel);
            }
            else return null; // no more orcs to fight
        }

        public override Image Hint()
        {
            if (encounterNumber <= 2) return new Orc(0).GetImage();
            else if (encounterNumber == 3) return new OrcWarboss(0).GetImage();
            else return null;
        }
    }
}
