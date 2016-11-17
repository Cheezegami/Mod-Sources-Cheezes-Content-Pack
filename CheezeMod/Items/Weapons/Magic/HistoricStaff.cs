using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class HistoricStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Historic Staff";
            item.damage = 35;
            item.magic = true;
            item.mana = 24;
            item.width = 42;
            item.height = 42;
            item.channel = true;
            item.toolTip = "An staff used by the guardians of Madrigal. \nShoots a Wind Field that slows and inflics Dryad's Bane on enemies. \n+20% Max mana when hold. \n +57% critical damage and chance when hold.";
            Item.staff[item.type] = true;
            item.reuseDelay = 50;
            item.useTime = 55;
            item.useAnimation = 55;
            item.useStyle = 5;
            item.crit = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 2;
            item.value = 75000;
            item.rare = 4;
            item.useSound = 43;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("WindFieldCast");
            item.shootSpeed = 15f;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float spread = 0.5f * 0.0174f; // 0.5 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            speedX = baseSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * (float)Math.Cos(randomAngle);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.AquaScepter);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.05f; // This number here changes the multiplier
                player.statManaMax2 += (int)((player.statManaMax2) * 0.2f);
            }
        }
    }
}