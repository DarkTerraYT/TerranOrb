using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SpeedsterPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width= 22;
            Item.height= 18;

            Item.value = Item.sellPrice(silver: 70);
            Item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.33f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WoodGreaves, 1)
                .AddIngredient(ModContent.ItemType<TerraShard>(), 7)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
