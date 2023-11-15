using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerranOrb.Content.Items.Accessories;
using TerranOrb.Content.NPCs.Boss.Terraslice;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace TerranOrb.Content.Items.Consumable
{
    // [Header("This Item is for me to Copy & Paste Whenever I Need")]
    internal class BaseTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;

            ItemID.Sets.BossBag[Type] = true;
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true; // TODO: If this isn't from a pre-hardmode boss REMOVE this line :)
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

            itemLoot.Add(ItemDropRule.Common(ItemID.DemoniteOre, 1, 15, 35)); // Main "Resource" From the Boss
            itemLoot.Add(ItemDropRule.Common(ItemID.EoCShield)); // The Expert Exclusive Item 
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(NPCID.EyeofCthulhu)); // COINS!
            itemLoot.Add(ItemDropRule.Common(ItemID.EyeofCthulhuTrophy)); // If there's no Trophy remove this line
            
        }
    }
}
