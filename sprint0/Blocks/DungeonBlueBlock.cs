using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace sprint0.Blocks
{
    internal class DungeonBlueBlock : IBlock
    {
        int scaledWidth;
        int scaledHeight;
        int roomId;
        ISprite blockSprite;
        public Texture2D texture { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }
        public int xValue { get; set; }
        public int yValue { get; set; }
        public DungeonBlueBlock(int x, int y, SpriteFactory spriteFactory)
        {
            blockSprite = spriteFactory.getAnimatedSprite("DungeonBlueBlock");
            xValue = x;
            yValue = y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, xPosition(), yPosition(),0.0f);
        }
        public void SetToRoomId(int ToRoomId) { }
        public int GetToRoomId()
        { return -1; }
        public void Explode() { }
        public void Update() { /*Nothing to update*/ }
        public int xPosition() { return xValue; }
        public int yPosition() { return yValue; }
        public int width() { return blockSprite.GetWidth(); }
        public int height() { return blockSprite.GetHeight(); }
        public bool isDynamic() { return false; }
        public bool isUpdateable() { return false; }
        public bool isInPlay() { return true; }
        public bool isDrawable() { return true; }
        public void SetRoomId(int roomId) { this.roomId = roomId; }
        public int GetRoomId() { return roomId; }
        public string type()
        {
            return "Block";
        }
    }
}
