using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Boundaries___Doors
{
    internal class Boundary : IGameObject
    {
        Rectangle BoundaryObj;
        int RoomId; 
        public Boundary(Rectangle boundary, int roomId) 
        { 
            BoundaryObj = boundary;
            RoomId = roomId;
        }
        /*TO ADD: GameObject methods
          ALSO: need to ask if you can draw clear rectangles*/
    }
}
