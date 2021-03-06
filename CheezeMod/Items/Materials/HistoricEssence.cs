using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class HistoricEssence : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 22;
			item.maxStack = 999;

			item.value = CheezeItem.historicPrice / 10;
			item.rare = CheezeItem.historicRarity-1;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Historic Essence");
      Tooltip.SetDefault("An historic relic from Madrigal");
    }

	}
}
