using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.World;
using Terraria.ID;
using Terraria.ModLoader;
using CheezeMod.Items;

namespace CheezeMod.NPCs
{
    public class DragonEye : ModNPC
    {
        private float attackCool
        {
            get
            {
                return npc.ai[0];
            }
            set
            {
                npc.ai[0] = value;
            }
        }
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 30;
            npc.scale = 1.1f;
            npc.life = 50;
            npc.lifeMax = 50;
            npc.damage = 20;
            npc.defense = 20;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 120f;
            npc.buffImmune[20] = true;
            npc.buffImmune[31] = false;
            npc.knockBackResist = 0.9f;
            npc.aiStyle = 2;
            banner = npc.type;
            bannerItem = mod.ItemType("DragonEyeBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye];
            animationType = NPCID.DemonEye;
            attackCool = 200f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Eye");
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            return (CheezeMod.NormalSpawn(spawnInfo) && NPC.downedBoss1 && player.ZoneJungle && !Main.dayTime) ? spawnInfo.spawnTileY > Main.worldSurface ? 0.05f : 0.105f : 0f;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (npc.localAI[0] == 0f)
            {
                int damage = npc.damage / 3;
                attackCool -= 1f;
                if (Main.netMode != 1 && attackCool <= 0f)
                {
                    Vector2 delta = player.Center - npc.Center;
                    float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                    if (magnitude > 0)
                    {
                        delta *= 15f / magnitude;
                    }
                    else
                    {
                        delta = new Vector2(0f, 15f);
                    }
                    if (Main.expertMode && Collision.CanHit(npc.position,npc.width,npc.height,player.position,player.width,player.height) && Math.Abs(player.Center.X - npc.Center.X) < 900 && Math.Abs(player.Center.Y - npc.Center.Y) < 900)
                    {
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X/2, delta.Y/2, ProjectileID.Stinger, damage, 3f, Main.myPlayer);
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 17);
                        attackCool = 300f + 300f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(200);
                    }
                    else
                    {
                        attackCool = Main.rand.NextFloat() * 60f;
                    }
                    npc.netUpdate = true;
                    base.AI();
                }
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Vector2 pos;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                    }
                    pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    if (Main.rand.Next(3) >= 1)
                    {
                        Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Organic/DragonEyeTail"), 1f);
                    }
                    else
                    {
                        Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Organic/DragonEyeBody"), 1f);
                    }
                }
                for (int k = 0; k < 1; k++)
                {
                    pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Organic/DragonEye"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Grass, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(12) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1);
            }
            else if (Main.rand.Next(5) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Lens, 1);
            }
            else if (Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SapphireLens"), 1);
            }
            else if (Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DiamondLens"), 1);
            }
            else if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmeraldLens"), 1);
            }
            if (Main.rand.Next(100) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThornBlast"), 1);
            }
            if (Main.rand.Next(120) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosShirt, 1);
            }
            if (Main.rand.Next(120) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosPants, 1);
            }
            if (Main.rand.Next(120) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HerosHat, 1);
            }
        }
    }
}
