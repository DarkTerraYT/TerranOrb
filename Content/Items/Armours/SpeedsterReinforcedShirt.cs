using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TerranOrb.Content.Items.Placeables;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Body)]
    internal class SpeedsterReinforcedShirt : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width= 30;
            Item.height= 22;

            Item.value = Item.sellPrice(gold:8);
            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.34f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WoodBreastplate, 1)
                .AddIngredient(ModContent.ItemType<OsmiumBar>(), 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
