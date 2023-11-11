using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.BoundariesDoorsAndRooms
{
    internal class Boundary : IGameObject
    {

        Rectangle BoundaryObj;
        int RoomId;
        bool IsDynamic = false;
        bool IsInPlay = false;
        bool IsUpdateable = false;
        bool IsDrawable = false;
        public Boundary(Rectangle boundary, int roomId) 
        { 
            BoundaryObj = boundary;
            RoomId = roomId;
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
        public bool isInPlay()
        {
            return IsInPlay;
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
        public void Update()
        {
            /*Nothing to update*/
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Nothing to draw
        }
    }
}
