using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TerranOrb.Content.Items.Armours
{
    [AutoloadEquip(EquipType.Head)]
    internal class SpeedsterHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width= 20;
            Item.height= 18;

            Item.value = Item.sellPrice(silver: 50);
            Item.defense = 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SpeedsterShirt>() && legs.type == ModContent.ItemType<SpeedsterPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases Total Movement Speed by 50%";
            player.moveSpeed *= 1.5f;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.33f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WoodHelmet, 1)
                .AddIngredient(ModContent.ItemType<TerraShard>(), 5)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
