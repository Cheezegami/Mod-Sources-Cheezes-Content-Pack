using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace CheezeMod.Sounds.NPCHit
{
	public class ThyrranoidHit : ModSound
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