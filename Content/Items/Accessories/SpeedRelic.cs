using TerranOrb.Content.Items.Placeables;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items.Accessories
{
    internal class SpeedRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() 
        {
            Item.width = 32;
            Item.height=32;

            Item.accessory= true;
            Item.value = Item.sellPrice(gold:15);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Melee) *= 1.65f;
            player.moveSpeed *= 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SpeedAmulet>(), 1)
                .AddIngredient(ModContent.ItemType<TitaniumOsmiumBlend>(), 7)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
