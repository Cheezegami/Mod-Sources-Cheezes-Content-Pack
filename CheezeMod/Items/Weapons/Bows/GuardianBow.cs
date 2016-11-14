using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Bows
{
    public class GuardianBow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Guardian Bow";
            item.damage = 18;
            item.ranged = true;
            item.width = 18;
            item.height = 42;
            item.toolTip = "A bow used by the guardians of Madrigal. \n+15% Critical Chance. \n+21% Increased Critical Damage. \n+Autofire.";
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = 25000;
            item.rare = 2;
            item.crit = 15;
            item.autoReuse = true;
            item.useSound = 5;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 11f;
            item.useAmmo = ProjectileID.WoodenArrowFriendly;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddRecipeGroup("CheezeMod:EvilBows");
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.21f; // This number here changes the multiplier
            }
        }
    }
}