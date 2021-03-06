using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Bows
{
    public class HistoricBow : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 36;
            item.ranged = true;
            item.width = 50;
            item.height = 60;

            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.scale = 0.8f;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3;
            item.value = CheezeItem.angelPrice;
            item.rare = CheezeItem.angelRarity;
            item.crit = 17;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 11f;
            item.useAmmo = AmmoID.Arrow;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Historic Bow");
      Tooltip.SetDefault("A bow that is an historic artifact of Madrigal. \n+17% Critical Chance. \n+23% Increased Critical Damage. \n+Autofire.\n Inflics Dryad's Bane on enemy hit.");
    }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.PearlwoodBow);
            recipe.AddTile(18);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.23f; // This number here changes the multiplier
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).flyffhistoric = true; // Dryad debuff on enemy for 1 sec.
            }
        }
    }
}
