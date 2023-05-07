﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items.Accessories
{
    internal class SpeedArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Total Attack Speed by 40%.n/" +
                "Increases Movement Speed by 50%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() 
        {
            Item.width = 32;
            Item.height=32;

            Item.accessory= true;
            Item.value = Item.sellPrice(silver: 25);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Melee) *= 1.4f;
            player.moveSpeed += 0.5f;
        }
    }
}
