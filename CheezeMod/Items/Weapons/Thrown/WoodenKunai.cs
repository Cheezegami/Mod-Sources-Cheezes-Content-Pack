using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Thrown
{
	public class WoodenKunai : ModItem
	{
		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.ThrowingKnife);
			item.name = "Wooden Kunai";
			item.damage = 7;
			item.thrown = true;
            item.noMelee = true;
			item.width = 10;
			item.height = 36;
            item.autoReuse = true;
            item.toolTip = "You can't be a true ninja without these.";
            item.useTime = 25;
			item.useAnimation = 25;
			item.knockBack = 1f;
			item.noUseGraphic = true;
			item.useTurn = true;
			item.useStyle = 1;
            item.value = 500;
            item.rare = 0;
			item.shoot = mod.ProjectileType("WoodenKunai");
			item.shootSpeed = 10f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 15);
			recipe.AddRecipe();
		}
    }
}