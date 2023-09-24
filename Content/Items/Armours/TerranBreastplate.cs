using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Body)]
    internal class TerranBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;

            Item.value = Item.buyPrice(gold: 2, silver: 40);
            Item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 25;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraShard>(), 24)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
