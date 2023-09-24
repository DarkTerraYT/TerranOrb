using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID; 
using Terraria;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Legs)]
    internal class TerranLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;

            Item.value = Item.sellPrice(gold: 2, silver: 10);
            Item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TerraShard>(), 22)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
