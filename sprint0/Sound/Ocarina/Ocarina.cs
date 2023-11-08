﻿using Microsoft.Xna.Framework.Audio;
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
        public enum SoundEffects { SWORD_SLASH, SWORD_SHOOT, SHIELD,
            ARROW_LAUNCH, BOOMERANG_LAUNCH, BOMB_DROP, BOMB_EXPLODE, ENEMY_HIT,
            ENEMY_DIE, LINK_TAKE_DAMAGE, LINK_DEATH, LINK_LOW_HEALTH, FANFARE,
            LINK_ITEM_GET, GET_GROUND_HEART_KEY, GET_GROUND_RUPEE,
            REFILL, TEXT_APPEAR, GROUND_KEY_APPEAR, DOOR_UNLOCK,
            BOSS_AQUAMENTUS_SCREAM, BOSS_TAKE_DAMAGE, STAIRS, PUZZLE_SOLVED,
            BLAZE
        };
        private static IDictionary<Ocarina.SoundEffects, SoundEffectInstance>
            InPlaySound = new Dictionary<Ocarina.SoundEffects, SoundEffectInstance>();
        private static IDictionary<SoundEffects, OcarinaEffectData> Library 
            = new Dictionary<SoundEffects, OcarinaEffectData>();

        // Returns true or false if the soundEffect was loaded into the system.
        public static bool LoadSoundEffect(Ocarina.SoundEffects sfxName, SoundEffect sfx, bool isLoopable = false)
        {
            bool soundAdded = false;
            if (!Library.ContainsKey(sfxName))
            {
                OcarinaEffectData effectData = new OcarinaEffectData(sfx, isLoopable);
                Library.Add(sfxName, effectData);
                soundAdded = true;
            }
            return soundAdded;
        }
        // Plays the given sound effect on the assumption that it was properly loaded into the system.
        // If not, will print an error to console. 
        public static void PlaySoundEffect(Ocarina.SoundEffects sfxName)
        {
            if (Library.ContainsKey(sfxName))
            {
                OcarinaEffectData effectData = Library[sfxName];
                SoundEffectInstance effectInstance = effectData.sfx.CreateInstance();
                if (effectData.isLoopable)
                {
                    effectInstance.IsLooped = true;
                }
                effectInstance.Play();
                if (!InPlaySound.ContainsKey(sfxName))
                {
                    InPlaySound.Add(sfxName, effectInstance);
                }
                

            } else
            {
                Console.WriteLine("DEBUG: OCARINA_SOUND_SYSTEM: PLAYBACK FAILED: EFFECT NOT FOUND.");
            }

        }
        // Stops the given sound effect on the assumption that it was properly loaded into the system.
        // As well as is currently playing. If not, will print error to console.
        public static void StopSoundEffect(Ocarina.SoundEffects sfxName)
        {
            if (InPlaySound.ContainsKey(sfxName))
            {
                SoundEffectInstance effectInstance = InPlaySound[sfxName];
                effectInstance.Stop();
                InPlaySound.Remove(sfxName);
            }
            else
            {
                Console.WriteLine("DEBUG: WINDWAKER_SOUND_SYSTEM: TRACK KILL FAILED: SONG NOT FOUND / WAS NOT BEING PLAYED.");
            }

        }
    }
}
