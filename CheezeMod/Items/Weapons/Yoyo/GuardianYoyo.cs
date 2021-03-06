using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Yoyo
{
	public class GuardianYoyo : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.melee = true;
			item.width = 36;
			item.height = 32;

			item.knockBack = 5f;
            item.useTime = 10;
            item.useAnimation = 10;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.useStyle = 5;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useTurn = true;
            item.value = CheezeItem.guardianPrice;
            item.rare = CheezeItem.guardianRarity;
            item.crit = 15;
            item.shoot = mod.ProjectileType("GuardianYoyo");
            item.channel = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Guardian Yo-Yo");
      Tooltip.SetDefault("A yoyo used by the guardians of Madrigal. \n+5% Critical Chance. \n+28% Increased Critical Damage.");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddIngredient(ItemID.Valor);
            recipe.AddTile(18);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.28f;
            }
        }
    }
}
