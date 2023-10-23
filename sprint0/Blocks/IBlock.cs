using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Blocks
{

    public interface IBlock
    {

       // public void Draw(SpriteBatch spriteBatch, int x, int y);

        //add in Game central argument
       // public void Update();
        public void Explode();
        public void NextBlock();
        public void PreviousBlock();

        public void Draw(SpriteBatch spriteBatch, int x, int y);




    }

}