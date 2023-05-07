using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SpeedsterReinforcedPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Movement Speed by 33%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width= 22;
            Item.height= 18;

            Item.value = Item.sellPrice(silver: 20);
            Item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.33f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WoodBreastplate, 1)
                .AddIngredient(ItemID.Vine, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
