using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Magic
{
    public class HistoricWand : ModItem
    {
        int baseDamage = 25;
        float damageMultiplier = 0.125f;
        public override void SetDefaults()
        {

            item.damage = baseDamage;
            item.magic = true;
            item.mana = 9;
            item.width = 42;
            item.height = 42;
            item.channel = true;

            Item.staff[item.type] = true;
            item.useTime = 38;
            item.useAnimation = 38;
            item.useStyle = 5;
            item.channel = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = CheezeItem.historicPrice;
            item.rare = CheezeItem.historicRarity;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PsyBomb");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SpiritBomb");
            item.shootSpeed = 10f;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Historic Wand");
      Tooltip.SetDefault("A wand that is an historic artifact of Madrigal. \nShoots a penetrating Spirit Bomb that inflics ShadowFlame.\nDeals increased damage if you have more mana left. \n+25 Max mana when hold. \n +14% critical damage when hold.");
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

        public override void PostReforge()
        {
            base.PostReforge();
            baseDamage = item.damage;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HistoricEssence", 5);
            recipe.AddIngredient(ItemID.WandofSparking);
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.inventory[player.selectedItem] == this.item)
            {
                ((CheezePlayer)player.GetModPlayer(mod, "CheezePlayer")).critMultiplier += 0.14f; // This number here changes the multiplier
                player.statManaMax2 += 25; // Increases maximum mana by 25.
            }
            HoldStats(player); // Stat increases when item is being hold.
        }
        public override void HoldItem(Player player) // Syncs weapon damage when held in hand to prevent abuse.
        {
            HoldStats(player); // Stat increases when item is being hold.
        }
        public void HoldStats(Player player)
        {
            item.damage = baseDamage+(int)(player.statMana * damageMultiplier); // Damage is base damage plus the players mana times the damage multiplier.
        }
    }
}
