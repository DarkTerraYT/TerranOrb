using TerranOrb.Content.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items
{
    internal class TerraCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Dig;

            Item.value = Item.sellPrice(gold: 3);

            Item.rare = ItemRarityID.LightRed;

            Item.maxStack = 9999;
        }
    }
    internal class ActivatedTerraCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Dig;

            Item.value = Item.sellPrice(gold: 12);

            Item.rare = ItemRarityID.LightPurple;

            Item.maxStack = 9999;
        }
    }
}
