using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Body)]
    internal class SpeedsterReinforcedShirt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reinforced Speedster Shirt");
            Tooltip.SetDefault("Increases Movement Speed by 34%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width= 30;
            Item.height= 22;

            Item.value = Item.sellPrice(silver: 25);
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
                .AddIngredient(ItemID.Vine, 15)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
