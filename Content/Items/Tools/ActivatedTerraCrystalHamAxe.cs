using TerranOrb.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items.Tools
{
    internal class ActivatedTerraCrystalHamAxe : ModItem
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
            Item.useTime = 3;
            Item.useAnimation = 3;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 13;
            Item.knockBack = 3;
            Item.hammer = 85;
            Item.axe = 100 / 5;

            Item.value = Item.sellPrice(gold: 36);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddIngredient(ModContent.ItemType<ActivatedTerraCrystal>(), 8)
                .AddTile<TerrismicWorkStationTile>()
                .Register();
        }
    }
}
