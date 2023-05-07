using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Head)]
    internal class TerranHelmet : ModItem
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Terran Headgear");
            Tooltip.SetDefault("Increases Life+Mana Regen by 10, +1 Minion Slot");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type]= 1;
        }
       
        public override void SetDefaults() 
        {
            Item.width = 24;
            Item.height=28;

            Item.value = Item.sellPrice(gold: 2);
            Item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<TerranBreastplate>() && legs.type == ModContent.ItemType<TerranLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen = 10;
            player.manaRegen= 10;

            player.maxMinions += 1;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases Damage by 15%, Also Increases Movement Speed by 20%. Grants Immunity to Confusion.";
            player.buffImmune[BuffID.Confused] = true;
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.moveSpeed += 0.2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraShard>(), 20)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
