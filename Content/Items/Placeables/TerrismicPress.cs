﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TerranOrb.Content.Tiles;

namespace TerranOrb.Content.Items.Placeables
{
    internal class TerrismicPress : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 52;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.autoReuse = true;

            Item.maxStack = 9999;

            Item.consumable = true;

            Item.value = Item.sellPrice(gold: 1, silver: 50);

            Item.createTile = ModContent.TileType<TerrismicPressTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraShard>(), 15)
                .AddIngredient(ItemID.IronAnvil | ItemID.LeadAnvil, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
