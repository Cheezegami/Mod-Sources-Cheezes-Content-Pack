using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class Lancer : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bullet);
            projectile.name = "Lancer shot";
            projectile.width = 11;
            projectile.height = 11;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;
            projectile.scale = 1.5f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Bullet;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }

        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.9f, 0.6f, 0.2f);
            projectile.velocity.Y += projectile.ai[0];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(2) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 1.6f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.6f;
            }
            if (Main.rand.Next(2) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 1.6f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.3f;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 255, default(Color), 2f);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }
}