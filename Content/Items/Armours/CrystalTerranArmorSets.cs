using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TerranOrb.Content.Tiles;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Head)]
    internal class CrystalTerranHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;

            Item.value = Item.sellPrice(gold: 45);
            Item.defense = 14;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<CrystalTerranBreastplate>() && legs.type == ModContent.ItemType<CrystalTerranLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 15;
            player.manaRegen += 15;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases Damage by 25%, Also Increases Movement Speed by 25%. Grants Immunity to Confusion.";
            player.buffImmune[BuffID.Confused] = true;
            player.GetDamage(DamageClass.Generic) += 0.25f;
            player.moveSpeed += 0.25f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraCrystal>(), 20)
                .AddTile(ModContent.TileType<TerrismicWorkStationTile>())
                .Register();
        }
    }
    [AutoloadEquip(EquipType.Legs)]
    internal class CrystalTerranLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;

            Item.value = Item.sellPrice(gold: 44);
            Item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraCrystal>(), 22)
                .AddTile(ModContent.TileType<TerrismicWorkStationTile>())
                .Register();
        }
    }
    [AutoloadEquip(EquipType.Body)]
    internal class CrystalTerranBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 48);
            Item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 65;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraCrystal>(), 24)
                .AddTile(ModContent.TileType<TerrismicWorkStationTile>())
                .Register();
        }
    }
    [AutoloadEquip(EquipType.Head)]
    internal class ActivatedCrystalTerranHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;

            Item.value = Item.sellPrice(gold: 78);
            Item.defense = 17;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ActivatedCrystalTerranBreastplate>() && legs.type == ModContent.ItemType<ActivatedCrystalTerranLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 20;
            player.manaRegen += 20;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases Damage by 35%, Also Increases Movement Speed by 35%. Grants Immunity to Confusion.";
            player.buffImmune[BuffID.Confused] = true;
            player.GetDamage(DamageClass.Generic) += 0.35f;
            player.moveSpeed += 0.35f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ActivatedTerraCrystal>(), 20)
                .AddTile(ModContent.TileType<TerrismicWorkStationTile>())
                .Register();
        }
    }
    [AutoloadEquip(EquipType.Legs)]
    internal class ActivatedCrystalTerranLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;

            Item.value = Item.sellPrice(gold: 80);
            Item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.35f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ActivatedTerraCrystal>(), 22)
                .AddTile(ModContent.TileType<TerrismicWorkStationTile>())
                .Register();
        }
    }
    [AutoloadEquip(EquipType.Body)]
    internal class ActivatedCrystalTerranBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 98);
            Item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 85;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ActivatedTerraCrystal>(), 24)
                .AddTile(ModContent.TileType<TerrismicWorkStationTile>())
                .Register();
        }
    }
}
