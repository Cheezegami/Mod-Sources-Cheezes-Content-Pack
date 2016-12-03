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
    public class MoltenEye : ModNPC
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
            npc.name = "MoltenEye";
            npc.displayName = "Molten Eye";
            npc.width = 32;
            npc.height = 30;
            npc.scale = 1.2f;
            npc.life = 60;
            npc.lifeMax = 60;
            npc.damage = 40;
            npc.defense = 25;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 150f;
            npc.lavaImmune = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
            npc.buffImmune[31] = false;
            npc.knockBackResist = 0.75f;
            npc.aiStyle = 2;
            banner = npc.type;
            bannerItem = mod.ItemType("MoltenEyeBanner");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye];
            animationType = NPCID.DemonEye;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return (CheezeMod.NoBiomeNormalSpawn(spawnInfo)) && (spawnInfo.spawnTileY < CheezeMod.HellLayer - 10) ? 0.2f : 0f;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            Lighting.AddLight(npc.position, 1f, 0.7f, 0.2f);
            if(Main.rand.Next(4) == 0) {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Fire, 2.5f * (float)npc.direction, -2.5f, 0, default(Color), 1.3f);
            }
            if (npc.localAI[0] == 0f)
            {
                int damage = npc.damage / 2;
                attackCool -= 1f;
                if (Main.netMode != 1 && attackCool <= -150f)
                {
                    attackCool = 200f + 200f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(200);
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
                    if (Main.expertMode)
                    {
                        damage = (int)(damage / Main.expertDamage);
                    }
                    if (Main.expertMode)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BurningSphere);
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 20);
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
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Fire, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
                    pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    if (Main.rand.Next(3) >= 1)
                    {
                        Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Magmatic/MoltenTail"), 1f);
                    }
                    else
                    {
                        Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Magmatic/MoltenBody"), 1f);
                    }
                }
                for (int k = 0; k < 1; k++)
                {
                    pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/Magmatic/MoltenEye"), 1f);
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 226, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }
        public override void NPCLoot()
        {
            for (int i = 0; i < 9; i++) // For giving a 0-8 amount of Iron Bolt on drop.
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HellstoneBolt"), 1);
                }
            }
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
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TopazLens"), 1);
            }
            else if (Main.rand.Next(3) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RubyLens"), 1);
            }
        }
    }
}
