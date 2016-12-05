using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Sounds.Item
{
	public class SaxtonHalejump04 : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			soundInstance = sound.CreateInstance();
			soundInstance.Volume = volume * .2f;
            return soundInstance;
        }
	}
}
