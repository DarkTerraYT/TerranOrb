using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Body)]
    internal class SpeedsterShirt : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width= 30;
            Item.height= 22;

            Item.value = Item.sellPrice(gold:1);
            Item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.34f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WoodBreastplate, 1)
                .AddIngredient(ModContent.ItemType<TerraShard>(), 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
