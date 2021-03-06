using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheezeMod.Items.Weapons.Swords
{
	public class AdminSword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9001;
			item.melee = true;
			item.width = 118;
			item.height = 138;
            item.crit = 46;

			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1;
			item.rare = 2;
            item.expert = true;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Admin Sword");
      Tooltip.SetDefault("Truth is, this alien looking weapon was used by the original creator to make sure the world functions as it does now. But, this weapon is probably the cheeziest weapon in all of history!");
    }


        int effect = -1;

        public void UseItem(Player player, int playerID)
        {
            effect += 1;
            if (effect > 255) effect = 0;
            player.HealEffect(effect);
        }

        public void UseItemEffect(Player player, Rectangle rectangle)
        {
            Color color = new Color();
            int dust = Dust.NewDust(new Vector2((float)rectangle.X, (float)rectangle.Y), rectangle.Width, rectangle.Height, effect, (player.velocity.X) + (player.direction * 3), player.velocity.Y, 100, color, 2.0f);
            Main.dust[dust].noGravity = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(1) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, effect);
                effect += 1;
                if (effect > 255) effect = 0;
            }
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 60);
		}
	}
}
