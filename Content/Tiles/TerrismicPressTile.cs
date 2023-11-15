using Microsoft.Xna.Framework;
using TerranOrb.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerranOrb.Content.Tiles
{
    internal class TerrismicPressTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = false;

            LocalizedText name = CreateMapEntryName();

            AddMapEntry(new Color(81, 224, 86), name);

            DustType = ModContent.DustType<TerraDust>();
            HitSound = SoundID.Tink;
        }
    }
}
