using CalamityMod.Items;
using CalRemix.Content.Projectiles.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace CalRemix.Content.Items.Weapons
{
	public class Dartclops : ModItem
	{
		public override void SetStaticDefaults() 
		{
            Item.ResearchUnlockCount = 1;
            DisplayName.SetDefault("Dartclops");
            Tooltip.SetDefault("more knockback than when a car hits a deer!");
		}

		public override void SetDefaults() 
		{
			Item.width = 60;
			Item.height = 24;
			Item.rare = ItemRarityID.LightRed;
			Item.value = CalamityGlobalItem.RarityLightRedBuyPrice;
            Item.useTime = 60; 
			Item.useAnimation = 60;
			Item.reuseDelay = 60;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item99;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 49;
			Item.knockBack = 10.5f; 
			Item.noMelee = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Dart;
            Item.consumeAmmoOnLastShotOnly = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback);
            return false;
        }
    }
}
