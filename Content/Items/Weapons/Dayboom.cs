using CalamityMod.Items.Materials;
using CalamityMod.Items;
using CalRemix.Content.Projectiles.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CalRemix.Content.Items.Weapons
{
	public class Dayboom : ModItem
	{
		public override void SetStaticDefaults() 
		{
            Item.ResearchUnlockCount = 1;
            DisplayName.SetDefault("Dayboom");
            Tooltip.SetDefault("Fires five sharp daybloom flowers that inflict bleeding.");
		}

		public override void SetDefaults() 
		{
			Item.width = 116;
			Item.height = 36;
			Item.rare = ItemRarityID.Blue;
			Item.value = CalamityGlobalItem.RarityGreenBuyPrice;
            Item.useTime = 12; 
			Item.useAnimation = 60;
			Item.reuseDelay = 60;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item111;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 3;
			Item.knockBack = 1f; 
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<DayboomFlower>();
			Item.shootSpeed = 8f;
			Item.useAmmo = ItemID.Daybloom;
            Item.consumeAmmoOnFirstShotOnly = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, velocity, type, damage / 2, knockback);
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup("IronBar").
                AddIngredient(ItemID.Daybloom, 5).
                AddIngredient(ItemID.Bottle).
                AddIngredient(ItemID.FallenStar, 5).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
