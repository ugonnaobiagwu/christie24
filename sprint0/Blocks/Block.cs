using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Blocks
{
    public class Block : IBlock,ISprite
    {

        private List<IBlock> blockStates;
        private int currentIndex; // default is 0
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

       

        IBlock currentBlock;

        /* public Block() { }*/
        public Block(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

            blockStates = new List<IBlock>
        {
            new DungenBlueBlock(texture, rows, columns),
            new DungenPyramidBlock(texture, rows, columns),
            new DungenFishBlock(texture, rows, columns)
        };
            currentBlock = blockStates[currentIndex]; // default block

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


            currentIndex++;

            //loop back to the beginning once end of the List
            if (currentIndex >= blockStates.Count)
            {
                currentIndex = 0;
            }
            currentBlock = blockStates[currentIndex];
        }


        public void PreviousBlock()
        {

            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = blockStates.Count - 1;
            }
            currentBlock = blockStates[currentIndex];
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            
            currentBlock.Draw(spriteBatch, x, y);
        
        }



    }
}