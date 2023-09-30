using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0.Block
{
    internal class Block3 : IBlock
    {

        private Texture2D texture;
        int Rows, Columns;
        int blockRow = 1;
        int blockColumn = 2;
        int currentFrame = 2;
        int TotalFrame = 3;



        public Block3()
        {

        }
        public Block3(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            Rows = rows;
            Columns = columns;

        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {

            int width = texture.Width / Columns;
            int height = texture.Height / Rows;

            Rectangle sourceLocation = new Rectangle(width * blockRow, height * blockColumn, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);


            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceLocation, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {

        }

        public void Explode()
        {
            //explode logic

        }
        public void NextBlock()
        {
            currentFrame++;
            if (currentFrame == TotalFrame)
                currentFrame = 0;
        }
        public void PreviousBlock()
        {

            if (currentFrame == 0) { currentFrame = TotalFrame - 1; }
            else
            { currentFrame--; }
        }


    }
}