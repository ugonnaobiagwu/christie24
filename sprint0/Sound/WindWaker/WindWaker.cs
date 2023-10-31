using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Sound.Ocarina
{
    /*
     * NOTE TO SELF: This class is developed in tandem with another class: OCARINA (sfx system)
     */
    public static class WindWaker
    {
        public enum Songs { ONE, TWO };
        private static IDictionary<Songs, WindWakerSongData> Library
            = new Dictionary<Songs, WindWakerSongData>();

        // Returns true or false if the track was loaded into the library.
        public static bool LoadSong(WindWaker.Songs songName, Songs song)
        {
            return false;
        }
        // Plays the given track on the assumption that it was properly loaded into the system.
        // If not, will print an error to console. 
        public static void PlaySong(WindWaker.Songs songName)
        {

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
