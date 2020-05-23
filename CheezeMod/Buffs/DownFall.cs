using Terraria;
using Terraria.ModLoader;
using CheezeMod;
using CheezeMod.NPCs;

namespace CheezeMod.Buffs
{
	public class Downfall : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Downfall");
            Description.SetDefault("Falling Down");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<CheezePlayer>().downfall = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
            npc.GetGlobalNPC<CheezeGlobalNPC>().downfall = true;
		}
	}
}
