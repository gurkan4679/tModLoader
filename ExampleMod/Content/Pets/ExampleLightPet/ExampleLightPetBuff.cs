﻿using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExampleMod.Content.Pets.ExampleLightPet
{
	public class ExampleLightPetBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Annoying Light");
			Description.SetDefault("Ugh, soooo annoying");

			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;

			int projType = ProjectileType<ExampleLightPetProjectile>();

			//If the player is local, and there hasn't been a pet projectile spawned yet - spawn it.
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0) {
				Projectile.NewProjectile(player.position.X + player.width * 0.5f, player.position.Y + player.height * 0.5f, 0f, 0f, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}