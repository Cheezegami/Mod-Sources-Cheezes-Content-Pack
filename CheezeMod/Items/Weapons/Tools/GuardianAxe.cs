using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Tools
{
	public class GuardianAxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 32;
			item.melee = true;
			item.width = 34;
			item.height = 32;

            item.crit = 9;
            item.scale = 1.25f;
            item.useTime = 30;
			item.useAnimation = 30;
			item.axe = 19;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = CheezeItem.guardianPrice;
			item.rare = CheezeItem.guardianRarity;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Guardian Axe");
      Tooltip.SetDefault("An axe used by the guardians of Madrigal. \n+9% Critical chance and damage. \n+3 Defense when holding.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddRecipeGroup("CheezeMod:EvilAxes");
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(20) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 29);
			}
		}

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.09f; // This number here changes the multiplier
                player.statDefense += 3;
            }
        }
    }
}
