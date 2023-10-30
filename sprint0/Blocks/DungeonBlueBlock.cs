using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0.Blocks
{
    internal class DungeonBlueBlock : IBlock
    {
        int blockRow = 0;
        int blockColumn = 0;
        int scaledWidth;
        int scaledHeight;
        int RoomId;
        ISprite blockSprite;
        IBlock iblock;
        SpriteFactory blockSpriteFactory;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int XValue { get; set; }
        private int YValue { get; set; }




        public DungeonBlueBlock(int x, int y, int roomId, SpriteFactory spriteFactory)
        {

            blockSpriteFactory = spriteFactory;
            XValue = x; YValue = y;
            iblock = this;
            RoomId = roomId;
        }
        public DungeonBlueBlock(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

            
        }



        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {

            int width = Texture.Width / Columns; //width of a one frame per whole column
            int height = Texture.Height / Rows;
           

            Rectangle sourceLocation = new Rectangle(width * blockColumn, height * blockRow, width, height);

            //resize block image
            double scale = 0.2; //40% of the orignal size image
            scaledWidth = (int)(width * scale);
            scaledHeight = (int)(height * scale);


            Rectangle destinationRectangle = new Rectangle(x, y, scaledWidth, scaledHeight);

            spriteBatch.Draw(Texture, destinationRectangle, sourceLocation, Color.White);

        }


        public void Draw(SpriteBatch spritebatch) { blockSprite.Draw(spritebatch, XValue, YValue); }
        public void Explode() { }
        public void Update() { }

        //hard code for now (make new class for these?)
        public int xPosition() { return XValue; } // returns X pos of object
        public int yPosition() { return YValue; } // returns Y pos of object
        public int width() { return scaledWidth; } // (i.e.) "how big are you?"
        public int height() { return scaledHeight; } // (i.e.) "how big are you?"
        public bool isDynamic() { return false; } // does this object move? 
        public bool isUpdateable() { return true; }
        public bool isInPlay() { return true; }
        public bool isDrawable() { return true; }
        public void SetRoomId(int roomId) { RoomId = roomId; }
        public int GetRoomId() { return RoomId; }
    }

}



