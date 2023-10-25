using Microsoft.Xna.Framework;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Boundaries___Doors
{

    internal class Door : IGameObject
    {
        Rectangle DoorObj;
        int ToWhichRoom;
        int RoomId;
        bool IsDynamic = false;
        bool IsUpdateable = false;
        bool IsDrawable = true;
        bool IsRemoveable = false;
        SpriteFactory SpriteFactory;
        public Door(Rectangle door, int roomId, int toWhichRoom, SpriteFactory spriteFactory) 
        {
            DoorObj = door;
            RoomId = roomId;
            ToWhichRoom = toWhichRoom;
            SpriteFactory = spriteFactory;
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
        public bool isRemoveable()
        {
            return IsRemoveable;
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
        /*TO ADD: GameObject methods
          ALSO: need to ask if you can draw clear rectangles*/
    }
}
