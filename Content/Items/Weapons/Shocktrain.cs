using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CalamityMod.Items;
using CalRemix.Content.Projectiles.Weapons;

namespace CalRemix.Content.Items.Weapons
{
	public class Shocktrain : ModItem
	{
		public override void SetStaticDefaults() 
		{
            Item.ResearchUnlockCount = 1;
            DisplayName.SetDefault("Shocktrain");
            Tooltip.SetDefault("Slowly Fires five high velocity darts that damage your enemies Armor");
		}

		public override void SetDefaults() 
		{
			Item.width = 60;
			Item.height = 24;
			Item.rare = ItemRarityID.Lime;
			Item.value = CalamityGlobalItem.RarityLimeBuyPrice;
            Item.useTime = 10; 
			Item.useAnimation = 50;
			Item.reuseDelay = 90;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item67;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 54;
			Item.knockBack = 0f; 
			Item.noMelee = true;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.shootSpeed = 21f;
			Item.useAmmo = AmmoID.Dart;
            Item.consumeAmmoOnLastShotOnly = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback);
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 420;
            target.AddBuff(ModContent.BuffType<ArmorCrunch>(), time);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 420;
            target.AddBuff(ModContent.BuffType<ArmorCrunch>(), time);
        }
    }
}
