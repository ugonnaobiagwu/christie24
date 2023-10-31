using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Sound.Ocarina
{
    /*
     * NOTE TO SELF: This class is developed in tandem with another class: WINDWAKER (song system)
     */
    public static class Ocarina
    {
        public enum SoundEffects { ONE, TWO };
        private static IDictionary<SoundEffects, OcarinaEffectData> Library 
            = new Dictionary<SoundEffects, OcarinaEffectData>();

        // Returns true or false if the soundEffect was loaded into the system.
        public static bool LoadSoundEffect(Ocarina.SoundEffects sfxName, SoundEffect sfx, bool isLoopable = false)
        {
            return false;
        }
        // Plays the given sound effect on the assumption that it was properly loaded into the system.
        // If not, will print an error to console. 
        public static void PlaySoundEffect(Ocarina.SoundEffects sfxName)
        {
            
        }
        // Stops the given sound effect on the assumption that it was properly loaded into the system.
        // As well as is currently playing. If not, will print error to console.
        public static void StopSoundEffect(Ocarina.SoundEffects sfxName)
        {
           
        }
    }
}
