using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TerranOrb.Content.Items.Placeables;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SpeedsterReinforcedPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width= 22;
            Item.height= 18;

            Item.value = Item.sellPrice(gold:5,silver:60);
            Item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.33f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SpeedsterPants>(), 1)
                .AddIngredient(ModContent.ItemType<OsmiumBar>(), 7)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
