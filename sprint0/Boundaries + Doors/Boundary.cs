using Microsoft.Xna.Framework;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Boundaries___Doors
{
    internal class Boundary/* : IGameObject, ISprite*/
    {

        Rectangle BoundaryObj;
        int RoomId;
        SpriteFactory BoundaryFactory;
        bool IsDynamic = false;
        public Boundary(Rectangle boundary, int roomId, SpriteFactory spriteFactory) 
        { 
            BoundaryObj = boundary;
            RoomId = roomId;
            BoundaryFactory = spriteFactory;
        }
        public int xPosition()
        {
            return BoundaryObj.X;
        }
        public int yPosition()
        {
            return BoundaryObj.Y;
        }
        public bool isDynamic()
        {
            return IsDynamic;
        }
        /*TO ADD: GameObject methods
          ALSO: need to ask if you can draw clear rectangles*/
    }
    //
}
