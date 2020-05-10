using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    class MagicSword : Sword
    {
        public MagicSword() : base("sword0001")
        {
            StrMod = 25;
            PrMod = 5;
            HpMod = 20;
            GoldValue = 100;
            PublicName = "Magic Sword";
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if(pack.DamageType == "cut" || pack.DamageType == "blunt")
            {
                pack.HealthDmg -= 10;
            }
            return pack;
        }
    }
}
