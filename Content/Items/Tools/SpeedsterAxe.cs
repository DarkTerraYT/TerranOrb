using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace TerranOrb.Content.Items.Tools
{
    internal class SpeedsterAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.autoReuse= true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 3;
            Item.useAnimation = 3;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 6;
            Item.knockBack = 3;
            Item.axe = 45/5;

            Item.value = Item.sellPrice(gold: 1, silver: 10);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddIngredient(ItemID.Cactus, 12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
