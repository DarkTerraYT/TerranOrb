using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TerranOrb.Content.Projectiles.Weapons;

namespace TerranOrb.Content.Items.Weapons
{
    internal class TerraStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() 
        {
            // HITBOX
            Item.width = 32;
            Item.height = 32;

            // GRAPHICS
            Item.useTime = 8;
            Item.autoReuse = true;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;

            // COMBAT
            Item.DamageType = DamageClass.Magic;
            Item.mana = 8;
            Item.damage = 18;
            Item.noMelee= true;
            Item.knockBack = 2.1f;

            // MISC
            Item.UseSound = SoundID.Item71;
            Item.value = Item.sellPrice(gold: 1, silver: 25);
            Item.shoot = ModContent.ProjectileType<TerraBallProjectile>();
            Item.shootSpeed = 2.1f;
        }
    }
}
