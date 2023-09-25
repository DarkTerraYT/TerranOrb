using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                tasks.Insert(shiniesIndex + 1, new OsmiumGenPass("OsmiumOreGenPass", 325f));
                tasks.Insert(shiniesIndex + 1, new TerraGenPass("TerraGenPass", 115f));
            }
        }
    }
}
