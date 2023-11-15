using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerranOrb.Content.Items.Placeables
{
    internal class TerrasliceRelic : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 40;
            Item.rare = ItemRarityID.Master;
            Item.master = true;
            Item.value = Item.sellPrice(0, 5);
        }
    }
}
