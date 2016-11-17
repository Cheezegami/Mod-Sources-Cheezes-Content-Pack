using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Sounds.Custom
{
	public class Wind2 : ModSound
	{
		public override void PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * 0.2f;
			Main.PlaySoundInstance(soundInstance);
		}
	}
}