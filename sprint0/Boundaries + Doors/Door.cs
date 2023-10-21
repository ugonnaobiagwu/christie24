using Microsoft.Xna.Framework;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Boundaries___Doors
{
    internal class Door /*: IGameObject, ISprite*/
    {
        Rectangle DoorObj;
        int ToWhichRoom;
        int RoomId;
        SpriteFactory SpriteFactory;
        public Door(Rectangle door, int roomId, int toWhichRoom, SpriteFactory spriteFactory) 
        {
            DoorObj = door;
            RoomId = roomId;
            ToWhichRoom = toWhichRoom;
            SpriteFactory = spriteFactory;
        }
        /*TO ADD: GameObject methods
          ALSO: need to ask if you can draw clear rectangles*/
    }
}
