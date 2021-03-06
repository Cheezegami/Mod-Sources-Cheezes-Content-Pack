using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class ShipWreckage : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 22;
			item.maxStack = 999;

            item.value = 9000;
            item.rare = 4;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ship Wreckage");
      Tooltip.SetDefault("There might be some useful parts within this.");
    }

	}
}
