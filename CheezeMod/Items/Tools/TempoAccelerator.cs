using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Tools
{
	public class TempoAccelerator : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Tempo Accelerator";
			item.width = 32;
			item.height = 32;
			item.toolTip = "Changes time from day to night and vice versa.";
			item.useTime = 19;
            item.scale = 0.7f;
            item.mana = 200;
			item.useAnimation = 19;
			item.useStyle = 5;
			item.value = 10000;
			item.rare = 11;
			item.useSound = 9;
			item.autoReuse = false;
		}
        public override bool UseItem(Player player)
        {
            if (Main.time <= Main.dayLength)
            {
                Main.time = Main.dayLength;
            }
            else
            {
                Main.time = 0;
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.Sundial, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}