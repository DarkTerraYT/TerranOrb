using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace TerranOrb.Content.Items.Weapons
{
    public class TerraSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.autoReuse = false;
            Item.useTime = 6;
            Item.useAnimation= 6;

            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.damage = 17;
            Item.knockBack = 3;

            Item.value = Item.sellPrice(silver: 95);
            Item.UseSound = SoundID.Item1;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Broadsword");
            Tooltip.SetDefault("Return Them to The Earth!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraShard>(), 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
