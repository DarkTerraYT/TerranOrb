using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace TerranOrb.Content.Items.Tools
{
    internal class TerraHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.autoReuse= true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 9;
            Item.useAnimation = 9;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 6;
            Item.knockBack = 3;
            Item.hammer=70;

            Item.value = Item.sellPrice(gold: 1, silver: 10);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddIngredient(ModContent.ItemType<TerraShard>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
