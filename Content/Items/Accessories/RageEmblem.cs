using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items.Accessories
{
    internal class RageEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.accessory = true;
            Item.value = Item.sellPrice(silver: 110);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 1.2f;
        }
    }
}

