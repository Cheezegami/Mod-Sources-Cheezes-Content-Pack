using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Materials
{
	public class EmeraldLens : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Emerald Lens";
			item.width = 18;
			item.height = 18;
			item.maxStack = 999;
			AddTooltip("Great for projecting light, made with an emerald and a lens");
			item.value = 3000;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Lens);
            recipe.AddTile(17);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}