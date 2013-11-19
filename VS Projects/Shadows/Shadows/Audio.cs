using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Shadows
{
    class Audio
    {
        SoundEffect soundEffect;
        SoundEffectInstance instance;
        bool playing = false;

        public Audio(SoundEffect soundEffect)
        {
            this.soundEffect = soundEffect;
        }

        public void playSound()
        {
            instance = soundEffect.CreateInstance();
            instance.IsLooped = true;
            instance.Play();
        }

        public void pauseSound()
        {
            instance.Pause();
        }
    }
}
