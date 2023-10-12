using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0.Blocks
{
    internal class Block2 : IBlock
    {
        /*private int TotalFrame;
        private int currentFrame;*/
        private Block block;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }



        public Block2() { }

        public Block2(Texture2D texture, int rows, int columns)
        {
            this.Texture = texture;
            Rows = rows;
            Columns = columns;

            /*InitializeFrame();*/
        }

        /*  private void InitializeFrame()
          {

              TotalFrame = Rows * Columns;
              currentFrame = 1;
          }
  */

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {

            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int blockColumn = 1;
            int blockRow = 0;

            Rectangle sourceLocation = new Rectangle(width * blockColumn, height * blockRow, width, height);

            //resize block image
            double scale = 0.2; //40% of the orignal size image
            int scaledWidth = (int)(width * scale);
            int scaledHeight = (int)(height * scale);


            Rectangle destinationRectangle = new Rectangle(x, y, scaledWidth, scaledHeight);



            spriteBatch.Draw(Texture, destinationRectangle, sourceLocation, Color.White);

        }

        public void Update()
        {

        }
        public void Explode() { }
        public void NextBlock()
        {

        }

        public void PreviousBlock()
        {

        }





    }

}



