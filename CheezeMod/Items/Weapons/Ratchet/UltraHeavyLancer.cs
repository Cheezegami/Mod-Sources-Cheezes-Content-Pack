using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class UltraHeavyLancer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 98;
			item.ranged = true;
			item.width = 64;
			item.height = 30;
            item.scale = 0.8f;


            item.useTime = 5;
            item.useAnimation = 5;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 280000;
            item.rare = CheezeItem.ratchetRarity[3];
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Bullet;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ultra Heavy Lancer");
      Tooltip.SetDefault("'My barrel runs hot!', 55% Chance not to consume ammo.\nConverts normal bullets into Ultra Heavy Lancer shots which inflict cursed flames, ichor and midas with random explosions.\nOriginally from Ratchet and Clank: Going Commando.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MegaHeavyLancer");
            recipe.AddIngredient(null, "LuminiteBolt", 50);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 20);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 5f; // 5 degrees.
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.X);
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.Y);
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("UltraHeavyLancer");
                damage *= (int)1.05;
            }
            return true;
        }

        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(9) < 4; // 55.55%
        }
    }
}
