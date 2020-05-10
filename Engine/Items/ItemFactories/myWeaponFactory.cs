using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    class myWeaponFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> myWeapon = new List<Item>()
            {
                new RedStaff(),
                new MagicSword(),
                new TwoHandedAxe()
            };
            return myWeapon[Index.RNG(0, myWeapon.Count)];
        }

        public Item CreateNonMagicItem()
        {
            List<Item> myWeapon = new List<Item>()
            {
                new TwoHandedAxe(),
                new MagicSword() // does not make magic attack, just special buff, name is not very accurate
            };
            return myWeapon[Index.RNG(0, myWeapon.Count)];
        }

        public Item CreateNonWeaponItem()
        {
            List<Item> myWeapon = new List<Item>()
            {
                new RedStaff()
            };
            return myWeapon[0];
        }
    }
}
