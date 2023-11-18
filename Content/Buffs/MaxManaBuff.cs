using System;
using TerranOrb.Content.Projectiles.Minions;
using Terraria;
using Terraria.ModLoader;

namespace TerranOrb.Content.Buffs
{
    internal class MaxManaBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            Random random = new();

            player.statManaMax2 += (int)random.NextInt64(30, 100);
        }
    }
}
