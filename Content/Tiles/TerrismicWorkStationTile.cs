using Microsoft.Xna.Framework;
using TerranOrb.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TerranOrb.Content.Tiles
{
    internal class TerrismicWorkStationTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileTable[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.addTile(Type);

            AdjTiles = new int[] { TileID.Anvils };

            AddMapEntry(new Color(200, 200, 200), Language.GetText("ItemName.Anvil"));

            DustType = ModContent.DustType<TerraDust>();
            HitSound = SoundID.Tink;
        }
    }
}
