using CalamityMod.Items;
using CalRemix.Content.Projectiles.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CalRemix.Content.Items.Weapons
{
	public class CobadiumRifle : ModItem
	{
		public override void SetStaticDefaults() 
		{
            Item.ResearchUnlockCount = 1;
            DisplayName.SetDefault("Subnauticide");
            Tooltip.SetDefault("Converts Poison Darts to Nautical Darts that inflict Eutrophication");
		}

		public override void SetDefaults() 
		{
			Item.width = 60;
			Item.height = 24;
			Item.rare = ItemRarityID.LightRed;
			Item.value = CalamityGlobalItem.RarityLightRedBuyPrice;
            Item.useTime = 30; 
			Item.useAnimation = 30;
			Item.reuseDelay = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item99;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 25;
			Item.knockBack = 3f; 
			Item.noMelee = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Dart;
            Item.consumeAmmoOnLastShotOnly = true;
        }
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.PoisonDart)
			{
				type = ModContent.ProjectileType<NauticalDartProjectile>();
			}
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback);
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SeaPrism>(8).
                AddIngredient<Navystone>(10).
                AddIngredient<PearlShard>(2).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
