using Microsoft.Xna.Framework;
using System;
using TerranOrb.Content.Buffs;
using TerranOrb.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Humanizer.In;

namespace TerranOrb.Content.Projectiles.Minions
{
    internal class TerraOrbMinion : ModProjectile
    {
        // DEAFULTS
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 8;
            ProjectileID.Sets.MinionTargettingFeature[Type] = true;
            Main.projPet[Type] = true;
            ProjectileID.Sets.MinionSacrificable[Type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Type] = true;
        }
        public override void SetDefaults()
        {
            // HITBOX
            Projectile.width = 32;
            Projectile.height = 32;

            // COMBAT
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.timeLeft = -1;

            // OTHER
            Projectile.tileCollide = false;
            Projectile.minion = true;
            Projectile.minionSlots = 1;
        }

        // BOOL VALUE THINGS IDK
        public override bool? CanCutTiles() { return false; }

        public override bool MinionContactDamage() { return true; }

        // AI
        public override void AI()
        {
            if(Main.rand.NextBool(7)) 
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<TerraDust>());
            }

            Player owner = Main.player[Projectile.owner];

            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<TerraOrbMinionBuff>());
                return;
            }

            if (owner.HasBuff(ModContent.BuffType<TerraOrbMinionBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            AIGeneral(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition);
            AISearchForTarget(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            AIMovement(foundTarget, distanceFromTarget, targetCenter, distanceToIdlePosition, vectorToIdlePosition);

            AIUpdateAnimation();

            Methods.UpdateDamage(owner.numMinions, Projectile.damage, 1.5f);
        }

        private void AIGeneral(Player owner, out Vector2 toIdlePos, out float distanceToIdlePos)
        {
            Vector2 idlePos = owner.Center;
            idlePos.Y -= 48;


            float minionProjectileOffset = (10 + Projectile.minionPos * 40) * -owner.direction;

            idlePos.X += minionProjectileOffset;

            toIdlePos = idlePos - Projectile.Center;
            distanceToIdlePos = toIdlePos.Length();

            if(Main.myPlayer == owner.whoAmI && distanceToIdlePos > 2000f)
            {
                Projectile.position = idlePos;
                Projectile.velocity *= 0.1f;
            }

            float overlapVelocity = 0.04f;

            for(int i = 0; i <= Main.maxProjectiles; i++)
            {
                Projectile other = Main.projectile[i];
                if(i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width)
                {
                    if (Projectile.position.X < other.position.X)
                    {
                        Projectile.velocity.X -= overlapVelocity;
                    }
                    else
                    {
                        Projectile.velocity.X += overlapVelocity;
                    }

                    if (Projectile.position.Y < other.position.Y)
                    {
                        Projectile.velocity.Y -= overlapVelocity;
                    }
                    else
                    {
                        Projectile.velocity.Y += overlapVelocity;
                    }
                }
            }
        }
        private void AISearchForTarget(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter)
        {
            distanceFromTarget = 700f;
            targetCenter = Projectile.position;
            foundTarget = false;

            if (owner.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[owner.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, Projectile.Center);
                if (between < 1200f)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                }
            }

            if (!foundTarget)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, Projectile.Center);
                        bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);

                        bool closeThroughWall = between < 100f;

                        if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }
        }

        private void AIMovement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter, float distanceToIdlePosition, Vector2 toIdlePosition)
        {
            float speed = 8f;
            float inertia = 20f;

            if (foundTarget)
            {
                if (distanceFromTarget > 40f)
                {
                    Vector2 direction = targetCenter - Projectile.Center;
                    direction.Normalize();
                    direction *= speed;

                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
                }
                return;
            }

            if (distanceToIdlePosition > 600f)
            {
                speed = 12f;
                inertia = 60f;
            }
            else
            {
                speed = 4f;
                inertia = 80f;
            }

            if (distanceToIdlePosition > 20f)
            {
                toIdlePosition.Normalize();
                toIdlePosition *= speed;

                Projectile.velocity = (Projectile.velocity * (inertia - 1) + toIdlePosition) / inertia;
            }
            else if (Projectile.velocity == Vector2.Zero)
            {
                Projectile.velocity.X = -0.15f;
                Projectile.velocity.Y = -0.05f;
            }
        }

        private void AIUpdateAnimation()
        {
            Projectile.rotation = Projectile.velocity.X * 0.05f;

            int frameSpeed = 9;
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            if (Main.rand.NextBool(7))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<TerraDust>());
            }

            Lighting.AddLight(Projectile.position + Projectile.velocity, Color.Green.ToVector3() * 0.65f);
        }
    }
}
