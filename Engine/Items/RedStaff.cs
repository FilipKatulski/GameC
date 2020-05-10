using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    class RedStaff : Staff
    {
        public RedStaff() : base("staff0001")
        {
            MgcMod = 20;
            GoldValue = 150;
            PublicName = "Red fancy Staff";
        }
    }
}
