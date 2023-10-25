using Microsoft.Xna.Framework;
using sprint0.AnimatedSpriteFactory;
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
        SpriteFactory BoundaryFactory;
        bool IsDynamic = false;
        bool IsRemoveable = false;
        bool IsUpdateable = false;
        bool IsDrawable = true;
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
        public int width()
        {
            return BoundaryObj.Width;
        }
        public int height() 
        {
            return BoundaryObj.Height;
        }
        public bool isRemoveable()
        {
            return IsRemoveable;
        }
        public bool isUpdateable()
        {
            return IsUpdateable;
        }
        public bool isDrawable()
        {
            return IsDrawable;
        }
        public void SetRoomId(int newId)
        {
            RoomId = newId;
        }
        public int GetRoomId()
        {
            return RoomId;
        }
    }
}
