using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalRemix.Content.Projectiles;
using CalamityMod.Items;

namespace CalRemix.Content.Items.Ammo
{
    public class NauticalDart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nautical Dart");
            Tooltip.SetDefault("Inflicts Eutrophication");
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(copper: 12);
            Item.shoot = ModContent.ProjectileType<NauticalDartProjectile>();
            Item.shootSpeed = 2f;
            Item.ammo = AmmoID.Dart;
        }
        public override void AddRecipes()
        {
            CreateRecipe(50).
                AddIngredient<SeaPrism>(1).
                AddIngredient<Navystone>(2).
                Register();
        }
    }
}
