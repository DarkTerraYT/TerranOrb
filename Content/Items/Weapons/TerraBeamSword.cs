using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;

namespace TerranOrb.Content.Items.Weapons
{
    public class TerraBeamSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;

            Item.autoReuse = false;
            Item.useTime = 8;
            Item.useAnimation= 4;

            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.damage = 28;
            Item.knockBack = 3;

            Item.value = Item.sellPrice(silver: 95);
            Item.UseSound = SoundID.Item8;

            Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.TerraBeamSwordBeam>();
            Item.shootSpeed = 3.5f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Beam Sword");
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
