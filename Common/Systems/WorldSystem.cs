using System.Collections.Generic;
using TerranOrb.Common.Config;
using TerranOrb.Common.Systems.GenPasses;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace TerranOrb.Common.Systems
{
    internal class WorldSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(t => t.Name.Equals("Shinies"));
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new OsmiumGenPass("OsmiumOreGenPass", ModContent.GetInstance<TerraOrbServerSideConfig>().OsmiumOreWeight));
                tasks.Insert(shiniesIndex + 1, new TerraGenPass("TerraOreGenPass", ModContent.GetInstance<TerraOrbServerSideConfig>().TerraOreWeight));
            }
        }
    }
}
