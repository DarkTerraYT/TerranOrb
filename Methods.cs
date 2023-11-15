using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace TerranOrb
{
    public class Methods
    {
        public static void UpdateDamage(float maxIndex,float damage, float damageChange, bool multiply = true, bool add = false, bool set = false, int currentIndex = 0)
        {
            for (currentIndex = currentIndex; currentIndex <= maxIndex; currentIndex++)
            {
                if (currentIndex == 1)
                {
                    if (multiply)
                    {
                        damage *= damageChange;
                    }
                    if (add)
                    {
                        damage += damageChange;
                    }
                    if (set)
                    {
                        damage = damageChange;
                    }
                }
            }
        }
    }
}
