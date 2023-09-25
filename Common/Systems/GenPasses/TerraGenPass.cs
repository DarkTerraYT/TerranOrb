using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using TerranOrb.Content.Tiles;

namespace TerranOrb.Common.Systems.GenPasses
{
    internal class TerraGenPass : GenPass
    {
        public TerraGenPass(string name, double loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spawning Osmium Ores";

            // TutorialOre
            int maxToSpawn = (int)(Main.maxTilesX * Main.maxTilesY * 6E-05);
            for (int i = 0; i < maxToSpawn; i++)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)GenVars.worldSurface, Main.maxTilesY - 900);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 5), ModContent.TileType<TerraOre>());
            }
        }
    }
}