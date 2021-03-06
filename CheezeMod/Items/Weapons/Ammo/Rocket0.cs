using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ammo
{
    public class Rocket0 : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.RocketI);

            item.damage = 4;
            item.ranged = true;

            item.noMelee = true; //so the item's animation doesn't do damage
            item.value = 300;
            item.rare = 0;
            item.maxStack = 9999;
            item.ammo = AmmoID.Rocket;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Rocket 0");
      Tooltip.SetDefault("A low tier rocket.\nIt doesn't do much damage on it's own, but at least you have ammo now.\nCrafted with Musket Balls");
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 33);
            recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 9);
            recipe.AddRecipe();
        }
    }
}
