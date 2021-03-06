using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Other
{
    public class MahoganyBlowpipe : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 15;
            item.ranged = true;
            item.width = 30;
            item.height = 8;

            item.useTime = 36;
            item.useAnimation = 36;
            item.autoReuse = true;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = 1200;
            item.rare = 0;
            item.crit = 2;
            item.UseSound = SoundID.Item63;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 14f;
            item.useAmmo = AmmoID.Dart;
            item.position.Y -= 10;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mahogany Blowpipe");
      Tooltip.SetDefault("Seeds can be crafted with acorns.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddIngredient(null, "TwinklingStone");
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
