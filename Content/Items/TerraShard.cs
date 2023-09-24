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
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width= 32;
            Item.height = 32;


            Item.value = Item.sellPrice(silver: 10);
            Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<PetrifiedTerraShard>(), 1)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}
