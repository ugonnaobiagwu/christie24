/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Block
{
    internal class ExplodableBlock : IBlock
    {


        IBlock block3 = new Block3();



        IBlock currentBlock;


        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public ExplodableBlock(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

            currentBlock = block3;

        }



        public void Update()
        {
            currentBlock.Update();
        }

        public void Explode()
        {// nothing here 
        }
        public void NextBlock()
        {

            currentBlock.NextBlock();
        }

        public void PreviousBlock()
        {

            currentBlock.PreviousBlock();
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {

            currentBlock.Draw(spriteBatch, x, y);
        }



    }
}*/