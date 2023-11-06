using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Sound.Ocarina
{
    public class OcarinaEffectData
    {
        public SoundEffect sfx { get; }
        public bool isLoopable { get; }

        public OcarinaEffectData(SoundEffect sfx, bool isLoopable)
        {
            this.sfx = sfx;
            this.isLoopable = isLoopable;
        }
    }
}
