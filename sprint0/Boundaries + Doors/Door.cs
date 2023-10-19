using Microsoft.Xna.Framework;
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
        public Door(Rectangle door, int roomId, int toWhichRoom) 
        {
            DoorObj = door;
            RoomId = roomId;
            ToWhichRoom = toWhichRoom;
        }
        /*TO ADD: GameObject methods
          ALSO: need to ask if you can draw clear rectangles*/
    }
}
