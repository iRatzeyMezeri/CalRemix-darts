using CalamityMod.Items;
using CalRemix.Content.Projectiles.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CalRemix.Content.Items.Weapons
{
	public class AcesLow : ModItem
	{
		public override void SetStaticDefaults() 
		{
            Item.ResearchUnlockCount = 1;
            DisplayName.SetDefault("Cobadium Rifle");
            Tooltip.SetDefault("Fires two high velocity darts");
		}

		public override void SetDefaults() 
		{
			Item.width = 60;
			Item.height = 24;
			Item.rare = ItemRarityID.LightRed;
			Item.value = CalamityGlobalItem.RarityLightRedBuyPrice;
            Item.useTime = 30; 
			Item.useAnimation = 70;
			Item.reuseDelay = 70;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item99;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 40;
			Item.knockBack = 7f; 
			Item.noMelee = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 17f;
			Item.useAmmo = AmmoID.Dart;
            Item.consumeAmmoOnLastShotOnly = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback);
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup("CobaltBar", 10).
                AddIngredient(ItemID.PalladiumBar,10).
                AddIngredient(ItemID.PoisonDart,100).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
