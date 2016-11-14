using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class Multistar : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Multistar";
			item.damage = 25;
			item.thrown = true;
			item.width = 38;
            item.scale = 0.6f;
			item.height = 24;
			item.toolTip = "Throw a splitting, bouncing shuriken, uses Shuriken as ammo.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 155000;
			item.rare = 3;
            item.crit = 4;
            item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Chopper");
            item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 8f;
			item.useAmmo = ProjectileID.Shuriken;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Chopper");
            recipe.AddIngredient(null, "HellstoneBolt", 60);
            recipe.AddIngredient(ItemID.JungleSpores, 5);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("Multistar");
            return true;
        }
    }
}