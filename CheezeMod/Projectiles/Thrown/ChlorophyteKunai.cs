using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Thrown
{
    public class ChlorophyteKunai : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            projectile.width = 22;
            projectile.height = 22;
            projectile.thrown = true;
            projectile.friendly = true;
            projectile.timeLeft = 700;
            projectile.scale = 0.9f;
            projectile.penetrate = 5;
            aiType = ProjectileID.ThrowingKnife;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Kunai");
        }

        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        public override void AI()
        {
            Lighting.AddLight(new Vector2(projectile.position.X, projectile.position.Y), 0.4f, 0.8f, 0.4f);
            if (Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.GrassBlades, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);       
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("ChlorophyteKunai"));
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, DustID.GrassBlades, default(Color), 0.75f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];

            if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.Poisoned, 360);
            }
        }
    }
}