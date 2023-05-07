using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerranOrb.Content.Items
{
   public class TerraShard : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Shard");
            Tooltip.SetDefault("Smells like the Earth");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width= 32;
            Item.height = 32;


            Item.value = Item.sellPrice(silver: 10);
            Item.maxStack = 9999;
        }
    }
}
