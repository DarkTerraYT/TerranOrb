using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Projectiles.Weapons
{
    public class StoneKunaiFriendly : ModProjectile
    {
        public override void SetStaticDefaults()
        {

        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            // HITBOX
            Projectile.width = 32;
            Projectile.height = 32;

            // COMBAT
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Ranged;

            // MISC
            Projectile.timeLeft = 850;
            AIType = ProjAIStyleID.Arrow;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            int numToSpawn;

            for (numToSpawn = 1; numToSpawn < 12; numToSpawn++) {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Stone, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f,
                       0, new Color(143,143,143), 1f);
            }

            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return true;
        }
    }
}
