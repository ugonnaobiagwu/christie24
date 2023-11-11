using sprint0.AnimatedSpriteFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sprint0.Globals;

namespace sprint0.BoundariesDoorsAndRooms
{
    internal class Door : IGameObject
    {
        ISprite doorSprite;
        int roomId;
        int toRoomId;
        Vector2 position;
        Globals.Direction sideOfRoom;
        public Door(int x, int y, int toRoomId, SpriteFactory spriteFactory, Globals.Direction sideOfRoom)
        {
            position.X = x;
            position.Y = y;
            this.toRoomId = toRoomId;
            doorSprite = spriteFactory.getAnimatedSprite("Door");
            this.sideOfRoom = sideOfRoom;
        }
        public int xPosition()
        {
            return (int)position.X;
        }
        public int yPosition()
        {
            return (int)position.Y;
        }
        public int width()
        {
            return doorSprite.GetWidth();
        }
        public int height()
        {
            return doorSprite.GetHeight();
        }
        public Direction getSideOfRoom()
        {
            return sideOfRoom;
        }
        public void setSideOfRoom(Globals.Direction side)
        {
            sideOfRoom = side;
        }
        public bool isDrawable()
        {
            return true;
        }
        public bool isUpdateable()
        {
            //When we need to add exploding walls, we can make this into a variable
            return false;
        }
        public bool isInPlay()
        {
            return true;
        }
        public bool isDynamic()
        {
            //This will also need to be changed like IsUpdateable
            return false;
        }
        public void SetRoomId(int roomId)
        {
            this.roomId = roomId;
        }
        public int GetRoomId()
        {
            return roomId;
        }

        public void Update()
        {
            //Nothing to update but states would require it to be added
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            doorSprite.Draw(spriteBatch, xPosition(), yPosition(), 0);
        }
    }
}
