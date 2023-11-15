using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using TerranOrb.Content.Items;
using TerranOrb.Content.Items.Consumable;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.CameraModifiers;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.NPCs.Boss.Terraslice
{
    [AutoloadBossHead]
    internal class TerrasliceBody : ModNPC
    {
        public static int secondStageHeadSlot = -1;

        public bool Phase2 = false;
        public bool HasDonePhaseSwitch = false;

        public override void Load()
        {
            string texture = BossHeadTexture + "_SecondStage";
            secondStageHeadSlot = Mod.AddBossHeadTexture(texture, -1);
        }

        public override void BossHeadSlot(ref int index)
        {
            int slot = secondStageHeadSlot;
            if (Phase2 && slot != -1)
            {
                // If the boss is in its second stage, display the other head icon instead
                index = slot;
            }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 8;

            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                CustomTexturePath = "TerranOrb/Assets/Textures/Bestiary/Terraslice_Preview",
                PortraitScale = 0.6f,
                PortraitPositionYOverride = 0f,
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetDefaults()
        {
            NPC.width = 144;
            NPC.height = 144;
            NPC.damage = 25;
            NPC.defense = 25;
            NPC.lifeMax = 15000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(gold: 15);
            NPC.boss = true;
            NPC.npcSlots = 10f;
            NPC.aiStyle = -1;

            if (!Main.dedServ)
            {
                Music = MusicID.Boss2;
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
                new FlavorTextBestiaryInfoElement("Made out of the terra shards it'll be sure to pack quite a punch!")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<TerrasliceTreasureBag>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ActivatedTerraShard>(), 1, 10, 25));
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }
        public override void FindFrame(int frameHeight)
        {

            int startFrame = 0;
            int finalFrame = 3;

            if (Phase2)
            {
                startFrame = 4;
                finalFrame = Main.npcFrameCount[NPC.type] - 1;

                if (NPC.frame.Y < startFrame * frameHeight)
                {
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }

            int frameSpeed = 5;
            NPC.frameCounter += 0.5f;
            NPC.frameCounter += NPC.velocity.Length() / 10f;
            if (NPC.frameCounter > frameSpeed)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;

                if (NPC.frame.Y > finalFrame * frameHeight)
                {
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }
        }
        public override void HitEffect(NPC.HitInfo hit)
        {

            if (Main.netMode == NetmodeID.Server)
            {

                return;
            }

            if (NPC.life <= 0)
            {

                int backGoreType = Mod.Find<ModGore>("TerrasliceBottom").Type;
                int frontGoreType = Mod.Find<ModGore>("TerrasliceTop").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }

                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);

                // This adds a screen shake (screenshake) similar to Deerclops
                PunchCameraModifier modifier = new PunchCameraModifier(NPC.Center, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), 20f, 6f, 20, 1000f, FullName);
                Main.instance.CameraModifiers.Add(modifier);
            }
        }

        public override void AI()
        {
            if (NPC.life <= NPC.lifeMax / 2 && !HasDonePhaseSwitch)
            {
                PhaseSwitch();

                Phase2 = true;
                HasDonePhaseSwitch = true;
            }
            else if (Phase2)
            { 
                if (HasDonePhaseSwitch)
                {
                    AIPhase1(Main.LocalPlayer);
                }
            }
            else
            {
                AIPhase1(Main.LocalPlayer);
            }
        }

        void AIPhase1(Player player, int maxRotationsAroundPlayer = 5, int maxDashesToPlayer = 3)
        {
            Vector2 place1;
            Vector2 place2;
            Vector2 place3;

            Vector2 dashLocation;

            int rotationsAroundPlayer = 0;
            int dashesToPlayer = 0;

            place1.X = player.Center.X - 50;
            place1.Y = player.Center.Y;

            place2.X = player.Center.X;
            place2.Y = player.Center.Y + 50;

            place3.X = player.Center.X + 50;
            place3.Y = player.Center.Y;

            if (rotationsAroundPlayer < maxRotationsAroundPlayer)
            {
                NPC.Center.MoveTowards(place1, 200);
                place1.X = player.Center.X - 50;
                place1.Y = player.Center.Y;

                place2.X = player.Center.X;
                place2.Y = player.Center.Y + 50;

                place3.X = player.Center.X + 50;
                place3.Y = player.Center.Y;
                NPC.Center.MoveTowards(place2, 200);
                place1.X = player.Center.X - 50;
                place1.Y = player.Center.Y;

                place2.X = player.Center.X;
                place2.Y = player.Center.Y + 50;

                place3.X = player.Center.X + 50;
                place3.Y = player.Center.Y;
                NPC.Center.MoveTowards(place3, 200);
                place1.X = player.Center.X - 50;
                place1.Y = player.Center.Y;

                place2.X = player.Center.X;
                place2.Y = player.Center.Y + 50;

                place3.X = player.Center.X + 50;
                place3.Y = player.Center.Y;
                NPC.Center.MoveTowards(place2, 200);
                rotationsAroundPlayer++;
            }
            else if (dashesToPlayer < maxDashesToPlayer)
            {
                dashLocation = player.Center;
                NPC.Center.MoveTowards(dashLocation, 999999999999f);
                dashesToPlayer++;
            }
            else if(dashesToPlayer >= maxDashesToPlayer)
            {
                rotationsAroundPlayer = 0;
                dashesToPlayer = 0;
            }
        }
        void PhaseSwitch()
        {
            Vector2 maxLeft;
            Vector2 maxRight;

            maxLeft.X = NPC.Center.X - 30;
            maxLeft.Y = NPC.Center.Y;

            maxRight.X = NPC.Center.X + 30;
            maxRight.Y = NPC.Center.Y;

            for (int i = 0; i < 5; i++)
            {
                NPC.Center.MoveTowards(maxLeft, 30);
                NPC.Center.MoveTowards(maxRight, 30);
            }
        }
    }
}