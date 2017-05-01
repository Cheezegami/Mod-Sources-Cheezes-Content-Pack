﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace CheezeMod
{
    public class ProjFX : GlobalProjectile
    {
        public const float shieldDist = 40f;

        public override bool PreAI(Projectile projectile)
        {
            foreach (Player player in Main.player)
            {
                if (!player.active) continue;
                if (projectile.melee ||
                    projectile.minion ||
                    projectile.npcProj ||
                    projectile.damage <= 0 ||
                    projectile.aiStyle == 7 ||
                    projectile.aiStyle == 13 ||
                    projectile.aiStyle == 15 ||
                    projectile.aiStyle == 19 ||
                    projectile.aiStyle == 20 ||
                    projectile.aiStyle == 26 ||
                    projectile.aiStyle == 84 ||
                    projectile.aiStyle == 85) continue;

                PlayerFX pFX = player.GetModPlayer<PlayerFX>(mod);
                if (!pFX.CanReflectProjectiles) continue;
                Player pOwner = Main.player[projectile.owner];

                // based off Projectile.cs CanReflect()
                bool isHostile =
                    projectile.hostile &&
                    projectile.owner == Main.myPlayer;
                bool isUnfriendlyPlayer = projectile.friendly && !PlayerFX.SameTeam(
                    player, pOwner);
                if (projectile.damage > 0 && (isHostile || isUnfriendlyPlayer))
                {
                    // Can reflect

                    // Is close enough
                    if (Vector2.Distance(projectile.Center, player.Center) <= shieldDist +
                        Vector2.Distance(default(Vector2), projectile.velocity * 2.5f))
                    {
                        ReflectProjectilePlayer(projectile, player, pFX, true);
                    }
                }

            }
            return true;
        }

        public override void PostAI(Projectile projectile)
        {
            LunarAccessoryVisuals(projectile);
        }

        internal static void ReflectProjectilePlayer(Projectile projectile, Player player, PlayerFX modPlayer, bool showEffect)
        {
            // Set ownership
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.owner = player.whoAmI;

            // Turn around
            projectile.velocity *= -1f;
            projectile.penetrate = 1;

            // Flip sprite
            if (projectile.Center.X > player.Center.X * 0.5f)
            {
                projectile.direction = 1;
                projectile.spriteDirection = 1;
            }
            else
            {
                projectile.direction = -1;
                projectile.spriteDirection = -1;
            }

            // Make last less time
            projectile.timeLeft = projectile.timeLeft / 2;

            // Don't know if this will help but here it is
            projectile.netUpdate = true;

            if (showEffect)
            {
                // Shield visual
                ShieldVisual(projectile, player);
            }
        }

        private static void ShieldVisual(Projectile projectile, Player player)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 28);
            Vector2 spawnPosition;
            for (int j = 0; j < 30; j++)
            {
                int d = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, j * projectile.velocity.X * 0.03f, j * projectile.velocity.Y * 0.03f, 50, Color.Transparent, 1f);
                Main.dust[d].velocity *= 0.5f;

                //circle effect
                float rotToTarget = Main.rand.Next((int)(-Math.PI * 10000), (int)(Math.PI * 10000)) / 10000f;
                spawnPosition = player.position
                    + new Vector2(player.width / 2 - 2, player.height / 2)
                    + new Vector2((float)(shieldDist * Math.Cos(rotToTarget)), (float)(shieldDist * Math.Sin(rotToTarget)));
                d = Dust.NewDust(spawnPosition, 0, 0, 43, 2f * (float)Math.Cos(rotToTarget), 2f * (float)Math.Sin(rotToTarget), 0, Color.White, 0.4f);
                Main.dust[d].fadeIn = 1f;
                Main.dust[d].velocity *= 0.25f;
            }
        }

        private void LunarAccessoryVisuals(Projectile projectile)
        {
            // Servers and server projectiles ignore projectile otherwise falling star bug
            if (Main.netMode == 2 || projectile.owner == 255) return;

            //Ignore npcs and statics
            if (projectile.npcProj || projectile.hostile) return;
            if (projectile.position == projectile.oldPosition) return;

            PlayerFX p = Main.player[projectile.owner].GetModPlayer<PlayerFX>(mod);
            if (p.lunarMagicVisual && projectile.magic)
            {
                Dust d = Main.dust[Dust.NewDust(
                    projectile.position, projectile.width, projectile.height,
                    DustID.PinkFlame,
                    projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f,
                    0, default(Color), 0.2f
                    )];
                d.fadeIn = 1f;
                d.velocity = d.velocity * 0.7f;
                d.noGravity = true;

                if (Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                { d.noLight = true; }
            }
            if (p.lunarRangeVisual && projectile.ranged)
            {
                Dust d = Main.dust[Dust.NewDust(
                    projectile.Center - new Vector2(4, 4), 0, 0,
                    DustID.Vortex
                    )];
                d.scale = (float)Math.Log10(projectile.width + projectile.height) * 0.7f;
                d.velocity = d.velocity * 0.1f + projectile.velocity / 2;
                d.noGravity = true;

                if (Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                { d.noLight = true; }
            }
            if (p.lunarThrowVisual && projectile.thrown)
            {
                if (projectile.whoAmI < 200) // Do not use Beenades.
                {
                    float speed = (10f + projectile.velocity.Length()) / 11;
                    Vector2 trailLeft = new Vector2(
                        projectile.velocity.X * 0.2f,
                        projectile.velocity.Y * 0.2f).
                        RotatedBy(1);
                    Vector2 trailRght = new Vector2(
                        projectile.velocity.X * 0.2f,
                        projectile.velocity.Y * 0.2f).
                        RotatedBy(-1);

                    bool solid = Collision.SolidCollision(projectile.position, projectile.width, projectile.height);

                    Vector2 pos = projectile.Center - new Vector2(4, 4) + projectile.velocity * 2;
                    Dust d = Main.dust[Dust.NewDust(
                        pos, 0, 0,
                        75,
                        0, 0, 0, default(Color), projectile.scale * speed
                        )];
                    d.velocity = trailLeft;
                    d.noGravity = true;
                    if (solid) { d.noLight = true; }
                    d = Main.dust[Dust.NewDust(
                        pos, 0, 0,
                        75,
                        0, 0, 0, default(Color), projectile.scale * speed
                        )];
                    d.velocity = trailRght;
                    d.noGravity = true;
                    if (solid) { d.noLight = true; }
                }
                else
                {
                    Dust d = Main.dust[Dust.NewDust(
                        projectile.position, projectile.width, projectile.height,
                        75,
                        0, 0, 0, default(Color), 2f
                        )];
                    d.velocity = projectile.velocity * 0.6f;
                    d.noGravity = true;
                }
            }
        }
    }
}