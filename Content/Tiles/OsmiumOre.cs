using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using TerranOrb.Content.Items.Placeables;
using TerranOrb.Content.Dusts;
using Terraria.Localization;

namespace TerranOrb.Content.Tiles
{
    internal class OsmiumOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 900;
            Main.tileShine2[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 350;

            LocalizedText name = CreateMapEntryName();

            AddMapEntry(new Color(188, 233, 226), name);

            DustType = DustID.Platinum;

            HitSound = SoundID.Tink;

            MineResist = 1.5f;
            MinPick = 85;
        }
    }
}
