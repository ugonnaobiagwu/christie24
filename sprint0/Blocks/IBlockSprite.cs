using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Blocks
{
    internal interface IBlockSprite: ISprite
    {

        public int blockWidth();
        public int blockHeight();
    }
}
