using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0.Blocks
{
    internal class DungeonPyramidBlock : IGameObject, IBlock
    {
        
        
        int blockX;
        int blockY;
        int scaledWidth;
        int scaledHeight;

        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }



        public DungeonPyramidBlock() { }

        public DungeonPyramidBlock(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

            
        }

        

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            //for the IGameObject methods
            blockX = x;
            blockY = y;

            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int blockColumn = 1;
            int blockRow = 0;

            Rectangle sourceLocation = new Rectangle(width * blockColumn, height * blockRow, width, height);

            //resize block image
            double scale = 0.2; //40% of the orignal size image
            scaledWidth = (int)(width * scale);
            scaledHeight = (int)(height * scale);


            Rectangle destinationRectangle = new Rectangle(x, y, scaledWidth, scaledHeight);



            spriteBatch.Draw(Texture, destinationRectangle, sourceLocation, Color.White);

        }

        public void Update() { }

        public void Explode() { }
        public void NextBlock() { }
        public void PreviousBlock() { }

        //hard code for now (make new class for these?)
        public int xPosition() { return blockX; } // returns X pos of object
        public int yPosition() { return blockY; } // returns Y pos of object
        public int width() { return scaledWidth; } // (i.e.) "how big are you?"
        public int height() { return scaledHeight; } // (i.e.) "how big are you?"
        public bool isDynamic() { return false; } // does this object move? 


    }

}



