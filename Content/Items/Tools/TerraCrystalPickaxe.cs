using TerranOrb.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items.Tools
{
    internal class TerraCrystalPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 5;
            Item.useAnimation = 5;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 12;
            Item.knockBack = 3;
            Item.pick = 85;

            Item.value = Item.sellPrice(gold: 30);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddIngredient(ModContent.ItemType<TerraCrystal>(), 10)
                .AddTile<TerrismicWorkStationTile>()
                .Register();
        }
    }
}
