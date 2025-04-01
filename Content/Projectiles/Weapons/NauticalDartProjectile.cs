using CalamityMod.Buffs.StatDebuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalRemix.Content.Projectiles
{
    public class NauticalDartProjectile : ModProjectile
    {
        public override string Texture => "CalRemix/Content/Items/Ammo/NauticalDart";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("NauticalDart");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.PoisonDartFriendly);
            AIType = ProjectileID.PoisonDartFriendly;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 240;
            target.AddBuff(ModContent.BuffType<Eutrophication>(), time);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            int time = Projectile.ai[2] == 1 ? 600 : 240;
            target.AddBuff(ModContent.BuffType<Eutrophication>(), time);
        }
    }
}
