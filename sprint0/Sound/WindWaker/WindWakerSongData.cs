using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Sound.Ocarina
{
    internal class WindWakerEffectData
    {
        public Song song { get; }
        public bool isLoopable { get; }

        public WindWakerEffectData(Song song, bool isLoopable)
        {
            this.song = song;
            this.isLoopable = isLoopable;
        }
    }
}
