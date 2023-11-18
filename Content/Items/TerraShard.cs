using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TerranOrb.Content.Items.Placeables;

namespace TerranOrb.Content.Items
{
   public class TerraShard : ModItem
   {

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults()
        {
            Item.width= 32;
            Item.height = 32;


            Item.value = Item.sellPrice(silver: 10);
            Item.maxStack = 9999;

            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<PetrifiedTerraShard>(), 3)
                .AddTile(TileID.Hellforge)
                .Register();
        }
   }
    public class ActivatedTerraShard : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;


            Item.value = Item.sellPrice(silver: 50);
            Item.maxStack = 9999;

            Item.rare = ItemRarityID.Orange;
        }
    }
}
