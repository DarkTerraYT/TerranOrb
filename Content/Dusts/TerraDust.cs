using Terraria;
using Terraria.ModLoader;

namespace TerranOrb.Content.Dusts
{
    internal class TerraDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity= true;
            dust.noLight= true;
        }
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            if (dust.scale < 0.3f)
            {
                dust.active = false;
            }

            Lighting.AddLight(dust.position, 0.43137254902f, 0.74509803921f, 0.1294117647f);

            return false;
        }
    }
}
