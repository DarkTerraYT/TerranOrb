using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace TerranOrb.Common.Config
{
    internal class TerraOrbServerSideConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Ores")]
        [DefaultValue(325f)]
        [ReloadRequired]
        public float OsmiumOreWeight;

        [DefaultValue(52f)]
        [ReloadRequired]
        public float TerraOreWeight;
    }
}
