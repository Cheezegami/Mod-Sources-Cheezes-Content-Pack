﻿using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Buffs
{
    public class ParryActive : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Parrying Moment";
            Main.buffTip[Type] = "Provides a bonus effect to fist weapons with parry";
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Main.buffTip[Type] = "Provides a bonus effect to fist weapons with parry";
        }
    }
}