using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace TerranOrb.Content.Items.Weapons
{
    public class TerraLongsword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;

            Item.autoReuse = false;
            Item.useTime = 8;
            Item.useAnimation= 8;

            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.damage = 23;
            Item.knockBack = 3;

            Item.value = Item.sellPrice(silver: 95);
            Item.UseSound = SoundID.Item1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Longsword");
            Tooltip.SetDefault("Return Them to The Earth!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraShard>(), 12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
