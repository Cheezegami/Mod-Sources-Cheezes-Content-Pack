using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Summoning
{
    public class UltraDreadLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 8;
            projectile.scale = 0.9f;
            projectile.friendly = true;
            projectile.penetrate = 6;
            projectile.timeLeft = 300;
            ProjectileID.Sets.MinionShot[projectile.type] = true;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Dread Laser");
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 1f, 0.6f, 0f);
            if (Main.rand.Next(9) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("RedLight"), projectile.velocity.X * 0.3f + Main.rand.Next(4) - 2, projectile.velocity.Y * 0.3f + Main.rand.Next(4) - 2);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].scale = 1f;
            }
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 60);
            target.AddBuff(BuffID.OnFire, 120);
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}