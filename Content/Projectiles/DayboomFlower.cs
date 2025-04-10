using CalamityMod.Buffs.StatDebuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Projectiles
{
    public class DayboomFlower : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dayboom Flower");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 600;
            target.AddBuff(BuffID.Bleeding, time);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 600;
            target.AddBuff(BuffID.Bleeding, time);
        }
    }
}
