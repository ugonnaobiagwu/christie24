using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sprint0.Sound.Ocarina
{
    /*
     * NOTE TO SELF: This class is developed in tandem with another class: OCARINA (sfx system)
     */
    public static class WindWaker
    {
        public enum Songs { TITLE, OVERWORLD, DUNGEON, ENDING,
          TRIFORCE_OBTAIN };
        private static IDictionary<Songs, WindWakerSongData> Library
            = new Dictionary<Songs, WindWakerSongData>();

        // Returns true or false if the track was loaded into the library.
        public static bool LoadSong(WindWaker.Songs songName, SoundEffect song, bool isLoopable = false)
        {
            bool soundAdded = false;
            if (!Library.ContainsKey(songName))
            {
                WindWakerSongData songData = new WindWakerSongData(song, isLoopable);
                Library.Add(songName, songData);
                soundAdded = true;
            }
            return soundAdded;
        }
        // Plays the given track on the assumption that it was properly loaded into the system.
        // If not, will print an error to console. 
        public static void PlaySong(WindWaker.Songs songName)
        {
            if (Library.ContainsKey(songName))
            {
                WindWakerSongData songData = Library[songName];
                SoundEffectInstance songInstance = songData.song.CreateInstance();
                if (songData.isLoopable)
                {
                    songInstance.IsLooped = true;
                }
                songInstance.Play();


            }
            else
            {
                Console.WriteLine("DEBUG: OCARINA_SOUND_SYSTEM: PLAYBACK FAILED: EFFECT NOT FOUND.");
            }
        }
        // Stops the given track on the assumption that it was properly loaded into the system.
        // As well as is currently playing. If not, will print error to console.
        public static void StopSong(WindWaker.Songs songName)
        {

        }

        // Pauses the given track on the assumption that it was properly loaded into the system.
        // As well as is currently playing. If not, will print error to console.
        public static void PauseSong(WindWaker.Songs songName)
        {

        }

        // Restarts the given track on the assumption that it was properly loaded into the system.
        // As well as is currently playing. If not, will print error to console.
        public static void RestartSong(WindWaker.Songs songName)
        {

        }
    }
}
