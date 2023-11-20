using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.AnimatedSpriteFactory;
using sprint0.Commands;

namespace sprint0.BoundariesDoorsAndRooms
{
    public class Room :IGameObject
    {
        private int xPos, yPos, width1, height1, currentRoomID;
        private bool inPlay;
        SpriteFactory RoomFactory;
        ISprite RoomSprite;

        public int xPosition() { return xPos;  }
        public int yPosition() { return yPos; }
        public int width() { return width1; }
        public int height() { return height1; }
        public bool isDynamic() { return false; }
        public bool isUpdateable() { return false; }
        public bool isInPlay() { return inPlay; }
        public bool isDrawable() { return true; }
        public void SetRoomId(int roomId) { currentRoomID = roomId; }
        public int GetRoomId() { return currentRoomID; }

        public Room(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            currentRoomID = 0;
            RoomSprite = spriteFactory.getAnimatedSprite("Room");
            inPlay = true;
            xPos = x; yPos = y; width1 = RoomSprite.GetWidth(); height1 = RoomSprite.GetHeight(); ;
        }

        public void Update()
        {
            //nothing to update
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            RoomSprite.Draw(spriteBatch, xPos, yPos, 0.0f);
        }
        public String type() { return "Block"; }
    }
}