using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;
using TerranOrb.Content.Dusts;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Projectiles.Weapons
{
    internal class TerraShine : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 7;
        }
        public override void SetDefaults()
        {
            // HITBOX
            Projectile.width = 30;
            Projectile.height = 30;

            // COMBAT
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 140;

        }

        public override void AI()
        {
            if (Projectile.frameCounter >= 8)
            {
                Projectile.frameCounter = 0;
            }
        }
    }
}
