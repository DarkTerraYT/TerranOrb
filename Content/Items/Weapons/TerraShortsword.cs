using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using TerranOrb.Content.Projectiles.Weapons;

namespace TerranOrb.Content.Items.Weapons
{
    public class TerraShortsword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.autoReuse = false;
            Item.useTime = 6;
            Item.useAnimation= 6;
            Item.noUseGraphic = true;

            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.damage = 16;
            Item.knockBack = 3;

            Item.value = Item.sellPrice(silver: 95);
            Item.UseSound = SoundID.Item1;

            Item.shoot = ModContent.ProjectileType<TerraShortswordProjectile>();
            Item.shootSpeed = 2.1f;

        }
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraShard>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
