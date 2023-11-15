using Microsoft.Xna.Framework;
using TerranOrb.Content.Buffs;
using TerranOrb.Content.Projectiles.Minions;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items.SummonWeapons
{
    public class TerraOrbBait : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.GamepadWholeScreenUseRange[Type] = true;

            ItemID.Sets.LockOnIgnoresCollision[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item44;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.DamageType = DamageClass.Summon;
            Item.damage = 27;
            Item.knockBack = 3.1f;
            Item.noMelee = true;
            Item.mana = 15;

            Item.value = Item.buyPrice(gold: 1, silver: 75);
            Item.shoot = ModContent.ProjectileType<TerraOrbMinion>();
            Item.buffType = ModContent.BuffType<TerraOrbMinionBuff>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseScreen;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);

            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            return false;
        }
    }
}
