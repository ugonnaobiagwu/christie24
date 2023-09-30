using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Block
{
    internal class Block : IBlock
    {


        IBlock block1 = new Block1();
        IBlock block2 = new Block2();


        IBlock currentBlock;


        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Block(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

            block1 = new Block1(texture, rows, columns);
            block2 = new Block2(texture, rows, columns);

            currentBlock = block1;

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
            spriteBatch.Begin();

            currentBlock.Draw(spriteBatch, x, y);
            spriteBatch.End();
        }



    }
}