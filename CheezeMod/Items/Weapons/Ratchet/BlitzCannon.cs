using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class BlitzCannon : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Blitz Cannon";
			item.damage = 19;
			item.ranged = true;
			item.width = 50;
            item.scale = 0.8f;
			item.height = 38;
			item.toolTip = "Shoots more bullets and autofires, converts normal bullets into Blitz Cannon shots.";
            item.toolTip2 = "Originally from Ratchet and Clank: Going Commando.";
            item.useTime = 40;
            item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 180000;
			item.rare = 2;
			item.useSound = 11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = ProjectileID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlitzGun");
            recipe.AddIngredient(null, "HellstoneBolt", 50);
            recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddIngredient(null, "BlitzGun");
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 25f * 0.0174f; // 25 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            for (int i = 0; i <= 3 + Main.rand.Next(3); i++)
            {
                double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                float randomSpeed = Main.rand.NextFloat() * 0.05f + 0.975f;
                speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
                speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
                if (type == ProjectileID.Bullet || type == mod.ProjectileType("BlitzCannon"))
                {
                    type = mod.ProjectileType("BlitzCannon");
                    speedX *= 6f;
                    speedY *= 6f;
                    damage *= (int)1.1;
                }
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, item.owner);
            }
            return true;
        }
    }
}