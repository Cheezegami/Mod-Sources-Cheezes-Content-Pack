using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class PulseRifle : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 34;
			item.ranged = true;
			item.width = 76;
            item.scale = 0.8f;
			item.height = 36;


            item.useTime = 55;
            item.useAnimation = 55;
			item.useStyle = 5;
            item.crit = 10;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 40000;
            item.rare = CheezeItem.ratchetRarity[0];
            item.UseSound = SoundID.Item40;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 25f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pulse Rifle");
      Tooltip.SetDefault("Shoots a piercing green pulse, right click to zoom.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MeteoriteBolt", 75);
            recipe.AddIngredient(null, "EmeraldLens", 3);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                player.scope = true;
            }
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("PulseRifle");
            return true;
        }
    }
}
