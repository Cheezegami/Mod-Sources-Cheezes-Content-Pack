using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class UltraMultistar : ModProjectile
    {
        int maxBounces = 2;
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.timeLeft = 100;
            projectile.scale = 1.2f;
            projectile.penetrate = 4;
            aiType = ProjectileID.Shuriken;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Multistar");
        }

        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * 0.4f;
            projectile.velocity.Y += 0.3f;
            projectile.velocity *= 0.995f;
            if (Main.rand.Next(2) == 0)
            {
                int num5 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("GreenLight"), projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num5].velocity *= 0.05f;
            }
            if (Main.rand.Next(2) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X, projectile.velocity.Y);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity *= 0.1f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            if (maxBounces > 0)
            {
                Bounce(oldVelocity);
                maxBounces--;
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            }
            else
            {
                Bounce(oldVelocity);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
                if (projectile.timeLeft > 5)
                {
                    projectile.timeLeft = 5;
                }
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 61, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f);
            }
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, (projectile.oldVelocity.X * 1f) - 6 + Main.rand.Next(12), (projectile.oldVelocity.Y * 1f) + 2 - Main.rand.Next(8), mod.ProjectileType("MegaMultistar"), (int)(projectile.damage * 0.95f), projectile.knockBack, projectile.owner);
        }
        public void Bounce(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y / 5 * 3;
            }
        }
    }
}