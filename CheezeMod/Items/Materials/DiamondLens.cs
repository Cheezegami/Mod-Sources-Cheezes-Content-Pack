using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class DiamondLens : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Diamond Lens";
			item.width = 18;
			item.height = 18;
			item.maxStack = 999;
			AddTooltip("It might burn if you look to the sun wearing these, made with a diamond and a lens");
			item.value = 3000;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Diamond);
            recipe.AddIngredient(ItemID.Lens);
            recipe.AddTile(17);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}