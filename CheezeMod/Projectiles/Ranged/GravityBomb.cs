using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Projectiles.Ranged
{
    public class GravityBomb : ModProjectile
    {
        public bool canExplode = true;
        int bonusTime = 30;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.BoulderStaffOfEarth);
            projectile.width = 24;
            projectile.height = 24;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.timeLeft = 160;
            projectile.penetrate = 30;
            aiType = ProjectileID.BoulderStaffOfEarth;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gravity Bomb");
        }

        public override bool PreAI()
        {
            projectile.spriteDirection = projectile.direction;
            return base.PreAI();
        }
        
        public override void AI()
        {
            if (Main.rand.Next(20) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("WhiteLightCircle"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            if (Main.rand.Next(20) == 0)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("BlueLight"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            if (projectile.timeLeft == 1 && canExplode)
            {
                explode();
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)projectile.ai[1]];
            if (canExplode)
            {
                explode();
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (canExplode)
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                explode();
            }
            return false;
        }

        public void explode()
        {
            Main.PlaySound(2, projectile.position, 62);
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;
            Gore.NewGore(projectile.position - projectile.Size, new Vector2(0, 0), mod.GetGoreSlot("Gores/Explosions/GravityBomb"));
            Lighting.AddLight(projectile.position, 1f, 1f, 1.8f);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 140;
            projectile.height = 140;
            projectile.penetrate = 30;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            projectile.knockBack = 8f;
            for (int k = 0; k < 4+ Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2 (Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke1);
                Main.gore[num1].timeLeft = Main.rand.Next(50) + 45;
            }
            for (int k = 0; k < 4+ Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke2);
                Main.gore[num1].timeLeft = Main.rand.Next(30) + 35;
            }
            for (int k = 0; k < 4+ Main.rand.Next(2); k++)
            {
                int num1 = Gore.NewGore(projectile.Center, new Vector2(Main.rand.Next(4) - 2, Main.rand.Next(4) - 2), GoreID.ChimneySmoke3);
                Main.gore[num1].timeLeft = Main.rand.Next(20) + 25;
            }
            for (int k = 0; k < 12; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("BlueLight"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            for (int k = 0; k < 12; k++)
            {
                int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("WhiteLightCircle"), Main.rand.Next(10) - 5, Main.rand.Next(10) - 5);
                Main.dust[num1].noGravity = true;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
                Main.dust[num1].velocity.X = Main.rand.NextFloat() * 5 - 2.5f;
            }
            projectile.hide = true;
            projectile.timeLeft = bonusTime;
            projectile.extraUpdates = bonusTime;
            canExplode = false;
        }
    }
}