using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Accessory
{
	public class PeisionNecklace : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Neck);
            return true;
        }
        public override void SetDefaults()
		{
			item.name = "Peision Necklace";
			item.width = 32;
			item.height = 32;
			item.toolTip = "What's FP?";
			item.toolTip2 = "Increases Additional Damage of Ranged and Thrown Critical Hits by 15% and ranged and thrown critical strike chance by 5%";
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.rangedCrit += 5;
            player.thrownCrit += 5;
            ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).rangedCritMultiplier += 0.15f;
            ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).thrownCritMultiplier += 0.15f;

        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilkRopeCoil, 1);
            recipe.AddIngredient(null, "GuardianEssence", 5);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}