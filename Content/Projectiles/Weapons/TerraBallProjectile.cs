using Microsoft.Xna.Framework;
using TerranOrb.Content.Dusts;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Projectiles.Weapons
{
    internal class TerraBallProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            // HITBOX
            Projectile.width = 40;
            Projectile.height = 40;

            // COMBAT
            Projectile.friendly = true;
            Projectile.penetrate = 5;
            Projectile.DamageType = DamageClass.Magic;

            // MISC
            Projectile.timeLeft = 850;
        }
        public override void AI()
        {
            Projectile.velocity.Y += Projectile.ai[0];
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<TerraDust>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if(Projectile.penetrate <= 0) 
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.ai[0] += 0.1f;
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X * 2;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y * 2;
                }
                Projectile.velocity *= 0.75f;
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            }
            return false;
        }
    }
}
