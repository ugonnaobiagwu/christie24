using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Blocks
{
    internal class RedPyramidBlock : IBlock
    {

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




        public RedPyramidBlock(int x, int y, SpriteFactory spriteFactory)
        {

            blockSpriteFactory = spriteFactory;
            blockSprite = spriteFactory.getAnimatedSprite("RedPyramidBlock");
            XValue = x; YValue = y;
            iblock = this;
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, XValue, YValue, 0.0f);
        }

        public void Explode() { }
        public void Update() { }
        public void SetToRoomId(int toRoomId)
        {
            //No toRoomId
        }
        public int GetToRoomId()
        {
            return -1; // nothing to return
        }
        //hard code for now (make new class for these?)
        public int xPosition() { return XValue; } // returns X pos of object
        public int yPosition() { return YValue; } // returns Y pos of object
        public int width() { return blockSprite.GetWidth(); } // (i.e.) "how big are you?"
        public int height() { return blockSprite.GetHeight(); } // (i.e.) "how big are you?"
        public bool isDynamic() { return false; } // does this object move? 
        public bool isUpdateable() { return true; }
        public bool isInPlay() { return true; }
        public bool isDrawable() { return true; }
        public void SetRoomId(int roomId) { RoomId = roomId; }
        public int GetRoomId() { return RoomId; }
        public String type() { return "Block"; }
    }
}