using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Tools
{
	public class HistoricAmbidextrousAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Historic Ambidextrous Axe";
			item.damage = 71;
			item.melee = true;
            item.width = 86;
			item.height = 86;
			item.toolTip = "An enourmous axe used by the guardians of Madrigal.\n+11% HP when holding.\n+5 defense when holding.\nInflicts Dryad's bane on your opponent.";
            item.scale = 1f;
            item.useTime = 64;
			item.useAnimation = 64;
			item.axe = 70;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = CheezeItem.historicPrice;
            item.rare = CheezeItem.historicRarity;
            item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.MushroomCap);
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
                player.statLifeMax2 += (int)(player.statLifeMax2 * 0.11f);
                player.statDefense += 5;
            }
        }
    }
}