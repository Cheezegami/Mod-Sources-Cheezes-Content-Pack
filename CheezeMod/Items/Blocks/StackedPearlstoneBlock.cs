using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Blocks
{
    public class StackedPearlstoneBlock : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Stacked Pearlstone Block";
            item.width = 16;
            item.height = 16;
            item.scale = 1.0f;
            item.maxStack = 999;
            AddTooltip("One of these contain " + Convert.ToString(CheezeMod.stackedBlockNumber) + " Pearlstone Blocks.");
            item.value = CheezeMod.blockBaseValue * CheezeMod.stackedBlockNumber; ;
            item.rare = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock, CheezeMod.stackedBlockNumber);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DoubleStackedPearlstoneBlock");
            recipe.SetResult(this, CheezeMod.stackedBlockNumber);
            recipe.AddRecipe();
        }
    }
}