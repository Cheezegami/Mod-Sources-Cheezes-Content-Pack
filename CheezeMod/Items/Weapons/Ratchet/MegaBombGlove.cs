using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Ratchet
{
	public class MegaBombGlove : ModItem
	{
		float spread = 1f; // 1 degrees 
		public override void SetDefaults()
		{

			item.damage = 40;
			item.thrown = true;
			item.width = 60;
			item.height = 42;
            item.scale = 0.75f;


            item.useTime = 32;
            item.useAnimation = 32;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 200000;
            item.rare = CheezeItem.ratchetRarity[2];
            item.UseSound = SoundID.Item19;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 3f;
			item.useAmmo = ProjectileID.Grenade;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mega Bomb Glove");
      Tooltip.SetDefault("Uses grenades, has a 50% chance not to consume ammo.\nInsired by Ratchet and Clank.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GoldBombGlove");
            recipe.AddIngredient(null, "HallowedBolt", 50);
            recipe.AddIngredient(ItemID.Cannonball, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddTile(null, "MegaCorpVendor");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            speedX = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.X);
            speedY = CheezeMod.CalculateSpread(spread, speedX, speedY, CheezeMod.Direction.Y);
            damage = (int)(damage * 0.95f);
            if (type == ProjectileID.Grenade)
            {
                type = ProjectileID.GrenadeIII;
            }
            return true;
        }
        public override bool ConsumeAmmo(Player p)
        {
            return Main.rand.Next(4) < 3; // 20%
        }
    }
}
