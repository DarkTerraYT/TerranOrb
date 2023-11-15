using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TerranOrb.Content.Tiles;

namespace TerranOrb.Content.Items.Placeables
{
    internal class PetrifiedTerraShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.value = Item.buyPrice(copper: 1000);

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.createTile = ModContent.TileType<TerraOre>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraShard>(), 1)
                .AddTile(TileID.Solidifier)
                .Register();
        }
    }
}
