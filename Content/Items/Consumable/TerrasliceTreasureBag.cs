using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerranOrb.Content.Items.Accessories;
using TerranOrb.Content.NPCs.Boss.Terraslice;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items.Consumable
{
    internal class TerrasliceTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;

            ItemID.Sets.BossBag[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Expert;
            Item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {


            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TerraCrystal>(), 1, 23, 68));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<RageEmblem>()));
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<TerrasliceBody>()));
        }
    }
}
