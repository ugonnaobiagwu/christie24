using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0.Block
{
    internal class Block1 : IBlock
    {

        private Block block;
        private Texture2D texture;
        int Rows, Columns;
        int blockRow = 1;
        int blockColumn = 1;
        int currentFrame = 0;
        int TotalFrame = 3;



        public Block1()
        {

        }
        public Block1(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            Rows = rows;
            Columns = columns;
        }


        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {

            int width = texture.Width / Columns;
            int height = texture.Height / Rows;

            Rectangle sourceLocation = new Rectangle(width * blockColumn, height * blockRow, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);


           
            spriteBatch.Draw(texture, destinationRectangle, sourceLocation, Color.White);
           
        }

        public void Update()
        {

        }
        public void Explode() { }
        public void NextBlock()
        {
            currentFrame++;
        }

        public void PreviousBlock()
        {

            if (currentFrame == 0) { currentFrame = TotalFrame - 1; }
            else
            { currentFrame--; }
        }





    }

}



