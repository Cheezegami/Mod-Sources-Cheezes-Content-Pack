using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Blocks
{
	public class StackedIceBlock : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stacked Ice Block";
			item.width = 16;
			item.height = 16;
            item.scale = 1.0f;
			item.maxStack = 999;
            AddTooltip("One of these contain " + Convert.ToString(CheezeMod.stackedBlockNumber) + " Ice Blocks.");
            item.value = CheezeMod.blockBaseValue * CheezeMod.stackedBlockNumber; ;
			item.rare = 1;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, CheezeMod.stackedBlockNumber);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DoubleStackedIceBlock");
            recipe.SetResult(this, CheezeMod.stackedBlockNumber);
            recipe.AddRecipe();
        }
    }
}