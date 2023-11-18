using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TerranOrb.Content.Buffs
{
    internal class TerrasliceDamageBuff : ModBuff
    {
        bool AppliedDamageBuff = false;

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.damage *= 2;
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            npc.damage += 1;
            return true;
        }
    }
}
