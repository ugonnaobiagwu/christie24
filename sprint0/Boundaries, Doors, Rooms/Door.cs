using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Boundaries___Doors
{
    public enum SideOfRoom {LEFT = 0, RIGHT = 1, UP = 2, DOWN = 3};
    internal class Door : IGameObject
    {
        Rectangle DoorObj;
        int ToWhichRoom;
        int RoomId;
        bool IsDynamic = false;
        bool IsUpdateable = false;
        bool IsDrawable = true;
        bool IsInPlay = false;
        ISprite DoorSprite;
        SideOfRoom sideOfRoom;
        public Door(Rectangle door, int roomId, int toWhichRoom, SpriteFactory spriteFactory, int SideOfScreen) 
        {
            DoorObj = door;
            RoomId = roomId;
            ToWhichRoom = toWhichRoom;
            DoorSprite = spriteFactory.getAnimatedSprite("Door");
            sideOfRoom = (SideOfRoom)SideOfScreen;
        }
        public int xPosition()
        {
            return DoorObj.X;
        }
        public int yPosition()
        {
            return DoorObj.Y;
        }
        public int width() 
        {
            return DoorObj.Width;
        }
        public int height()
        {
            return DoorObj.Height;
        }
        public bool isDynamic()
        {
            return IsDynamic;
        }
        public bool isUpdateable() 
        { 
            return IsUpdateable;
        }
        public bool isDrawable()
        {
            return IsDrawable;
        }
        public bool isInPlay()
        {
            return IsInPlay;
        }
        public void SetRoomId(int newId)
        {
            RoomId = newId;
        }
        public int GetRoomId()
        {
            return RoomId;
        }
        public int GetToWhichRoom()
        {
            return ToWhichRoom;
        }
        public void Update()
        {
            //Nothing to update 
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            DoorSprite.Draw(spriteBatch, xPosition(), yPosition());
        }
        public int GetSideOfRoom()
        {
            return (int) sideOfRoom;
        }
    }
}
