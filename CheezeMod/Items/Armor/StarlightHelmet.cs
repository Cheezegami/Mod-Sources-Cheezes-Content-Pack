using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Armor
{
	public class StarlightHelmet : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("StarlightBreastplate") && legs.type == mod.ItemType("StarlightLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Melee attacks restore mana and strenghten your magical attacks, +20 maximum mana.";
            player.statManaMax2 += 20;
            ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).starlit = true;         
        }

        public override void SetDefaults()
		{
			item.name = "Starlight Helmet";
			item.width = 18;
			item.height = 18;
			item.toolTip = "It fills you with... Spellblade capacities.";
            item.toolTip2 ="+5 max mana, 3% Melee and Magic damage.";
            item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 5;
            player.magicDamage += 0.03f;
            player.meleeDamage += 0.03f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 4);
            recipe.AddIngredient(mod, "StarlightBar", 12);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}