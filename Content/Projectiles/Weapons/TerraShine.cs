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
            Projectile.rotation += 10;
            if (Projectile.velocity.X < 25f)
            {
                Projectile.velocity.X *= 1.01f;
                Projectile.velocity.Y *= 1.01f;
            }
            else if (Projectile.velocity.X >= 25f)
            {
                if (Main.rand.NextBool(1))
                {
                    Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<TerraDust>(), Projectile.velocity.X *= 0.75f, Projectile.velocity.Y *= 0.75f);
                }
                Projectile.Kill();
            }
            if (++Projectile.frameCounter >= 9)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
        }
    }
}
