using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class GraniteShard : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 14;
            item.scale = 1.1f;
			item.maxStack = 999;

			item.value = 1400;
			item.rare = 1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Granite Shard");
      Tooltip.SetDefault("This seems pretty durable.");
    }

	}
}
