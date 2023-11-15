using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerranOrb.Content.Projectiles.Minions;
using Terraria;
using Terraria.ModLoader;

namespace TerranOrb.Content.Buffs
{
    internal class TerraOrbMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<TerraOrbMinion>()] > 0)
            {
                player.buffTime[buffIndex] = 10500;
                return;
            }

            player.DelBuff(buffIndex);
            buffIndex--;
        }
    }
}
