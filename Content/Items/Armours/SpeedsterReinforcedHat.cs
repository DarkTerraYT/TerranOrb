using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TerranOrb.Content.Items.Placeables;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Head)]
    internal class SpeedsterReinforcedHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width= 20;
            Item.height= 18;

            Item.value = Item.sellPrice(gold:5);
            Item.defense = 4;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SpeedsterReinforcedShirt>() && legs.type == ModContent.ItemType<SpeedsterReinforcedPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases Total Movement Speed by 75%";
            player.moveSpeed *= 1.75f;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.33f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SpeedsterHat>(), 1)
                .AddIngredient(ModContent.ItemType<OsmiumBar>(), 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
