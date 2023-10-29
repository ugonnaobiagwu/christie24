using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0.Blocks
{
    internal class DungenDragonBlock : IBlock,IGameObject
    {

        private Block block;
        int blockX;
        int blockY;
        int scaledWidth;
        int scaledHeight;


        /* private int currentFrame;
         private int TotalFrame;*/

        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }





        public DungenDragonBlock()
        {

        }
        public DungenDragonBlock(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

            /*InitializeFrame();*/
        }

        /* private void InitializeFrame()
         {

             TotalFrame = Rows * Columns;
             currentFrame = 0;
         }
 */


        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            blockX = x;
            blockY = y;
            int width = Texture.Width / Columns; //width of a one frame per whole column
            int height = Texture.Height / Rows;
            int blockColumn = 3;
            int blockRow = 0;

            Rectangle sourceLocation = new Rectangle(width * blockColumn, height * blockRow, width, height);

            //resize block image
            double scale = 0.2; //40% of the orignal size image
            scaledWidth = (int)(width * scale);
            scaledHeight = (int)(height * scale);


            Rectangle destinationRectangle = new Rectangle(x, y, scaledWidth, scaledHeight);



            spriteBatch.Draw(Texture, destinationRectangle, sourceLocation, Color.White);

        }
        public void Explode() { }
        public void Update(){}
        //hard code for now (make new class for these?)
        public int xPosition() { return blockX; } // returns X pos of object
        public int yPosition() { return blockY; } // returns Y pos of object
        public int width() { return scaledWidth; } // (i.e.) "how big are you?"
        public int height() { return scaledHeight; } // (i.e.) "how big are you?"
        public bool isDynamic() { return false; } // does this object move? 


    }

}



