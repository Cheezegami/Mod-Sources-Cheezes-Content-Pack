using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Sounds.NPCKilled
{
	public class ThyrranoidDie : ModSound
	{
        public override void PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
            soundInstance = sound.CreateInstance();
            soundInstance.Volume = volume * .8f;
            Main.PlaySoundInstance(soundInstance);
            return;
        }
	}
}