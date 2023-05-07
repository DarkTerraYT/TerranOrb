using Microsoft.Xna.Framework;
using TerranOrb.Content.Dusts;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Projectiles.Weapons
{
    internal class TerraBeamSwordBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TerraBall");
        }
        public override void SetDefaults()
        {
            // HITBOX
            Projectile.width = 32;
            Projectile.height = 32;

            // COMBAT
            Projectile.friendly = true;
            Projectile.penetrate = 5;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 850;


        }
    }
}
