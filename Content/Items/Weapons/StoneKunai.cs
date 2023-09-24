using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TerranOrb.Content.Projectiles.Weapons;

namespace TerranOrb.Content.Items.Weapons
{
    internal class StoneKunai : ModItem
    {
        public override void SetStaticDefaults()
        {;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.damage= 11;
            Item.width= 40;
            Item.height= 40;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 5;
            Item.useAnimation = 5;

            Item.value = Item.sellPrice(copper: 20);
            Item.UseSound= SoundID.Item1;
            Item.maxStack= 9999;

            Item.shoot = ModContent.ProjectileType<StoneKunaiFriendly>();
            Item.shootSpeed = 5f;

            Item.consumable = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(99)
                .AddIngredient(ItemID.StoneBlock, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
