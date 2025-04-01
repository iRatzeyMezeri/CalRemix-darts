using CalamityMod;
using CalamityMod.Projectiles.Ranged;
using CalRemix.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Projectiles.Weapons
{
	public class ShocktrainDart : ModProjectile
    {
        public override string Texture => "CalRemix/Content/Projectiles/Weapons/ShocktrainDart.png";
        public Player Owner => Main.player[Projectile.owner];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shocktrain Dart");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.PoisonDartFriendly);
            AIType = ProjectileID.PoisonDartFriendly;
            Projectile.penetrate = 4;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 240;
            target.AddBuff(ModContent.BuffType<MysticDischarge>(), time);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 240;
            target.AddBuff(ModContent.BuffType<MysticDischarge>(), time);
        }
    }
}

