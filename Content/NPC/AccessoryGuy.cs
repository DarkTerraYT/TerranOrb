using Microsoft.Xna.Framework;
using TerranOrb.Content.Items.Accessories;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using TerranOrb.Content.Projectiles.Weapons;
using TerranOrb.Content.Items.Weapons;
using TerranOrb.Content.Items;

namespace TerranOrb.Content.NPC
{
    [AutoloadHead]
    internal class AccessoryGuy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25;


            NPCID.Sets.ExtraFramesCount[Type] = 9; 
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 400; 
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90; 
            NPCID.Sets.AttackAverageChance[Type] = 50;
            NPCID.Sets.HatOffsetY[Type] = 4;
            NPCID.Sets.ShimmerTownTransform[NPC.type] = false;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = 1        
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Hate)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Steampunker, AffectionLevel.Love);
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 35;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 12;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;



        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,


				new FlavorTextBestiaryInfoElement("Coming from a designer past, he'll be sure to make you some accessories!"),
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.HermesBoots)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
               "Blocko",
               "Cubical",
               "Cubé",
               "Squared",
               "Steve",
               "Rectangled",
               "Cubed"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Upgrade Speed Core";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<SpeedCore>()))
                {
                    SoundEngine.PlaySound(SoundID.Item37);

                    Main.npcChatText = "Is that a Speed Core? I think I can make that useful for ya'. See I just know everything accessories!";

                    int speedCoreItemIndex = Main.LocalPlayer.FindItem(ModContent.ItemType<SpeedCore>());
                    var entitySource = NPC.GetSource_GiftOrReward();

                    Main.LocalPlayer.inventory[speedCoreItemIndex].TurnToAir();
                    Main.LocalPlayer.inventory[speedCoreItemIndex].UpdateItem(ModContent.ItemType<SpeedAmulet>());

                    return;
                }
                shopName = "Shop";
            }
        }

        public override void AddShops()
        {
            var npcShot = new NPCShop(Type)
                .Add(new Item(ItemID.BandofRegeneration) { shopCustomPrice = Item.buyPrice(gold: 2, silver: 50) })
                .Add(new Item(ItemID.CreativeWings), new Condition("Main.TerranOrb.PlayerHasFeatherFallingorGravitation", () => Main.LocalPlayer.HasBuff(BuffID.Featherfall | BuffID.Gravitation)));

        }

        public override string GetChat()
        {
           

            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Why don't I use the speed amulet? I'm not a speedy guy.";
                case 1:
                    return "The speed amulet and it's upgrades go great with the speedster armor!";
                case 2:
                    return "Do you wanna fly? Cause I got wings, no seriously I have wings in my shop!";
                default:
                    return "This is the default case.";
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 15;
            knockback = 2.9f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 20;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<StoneKunaiFriendly>();
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 15f;
            randomOffset = 3f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StoneKunai>(), 3, 50, 150));
        }
    }
}
