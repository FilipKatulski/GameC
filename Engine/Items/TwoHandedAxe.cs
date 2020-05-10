using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Items
{
    class TwoHandedAxe : Axe
    {
        public TwoHandedAxe() : base("axe0001")
        {
            StrMod = 20;
            GoldValue = 40;
            PublicName = "Two Handed Axe";
        }
        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            base.ApplyBuffs(currentPlayer, otherItems);
            currentPlayer.PrecisionBuff -= 5; //precision debuff for using two hands
        }
    }
}
