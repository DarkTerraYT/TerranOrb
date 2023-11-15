using TerranOrb.Content.Items.Placeables;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace TerranOrb.Content.Items.Accessories
{
    internal class SpeedArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults() 
        {
            Item.width = 32;
            Item.height=32;

            Item.accessory= true;
            Item.value = Item.sellPrice(gold:1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Melee) *= 1.4f;
            player.moveSpeed += 0.5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SpeedAmulet>(), 1)
                .AddIngredient(ModContent.ItemType<OsmiumBar>(), 4)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
