using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.BoundariesDoorsAndRooms
{
    public class Boundary : IGameObject
    {
        Rectangle boundaryObj;
        int roomId;
        public Boundary(Rectangle boundaryObj)
        {
            this.boundaryObj = boundaryObj;
        }
        public int xPosition()
        {
            return boundaryObj.X;
        }
        public int yPosition()
        {
            return boundaryObj.Y;
        }
        public int width()
        {
            return boundaryObj.Width;
        }
        public int height()
        {
            return boundaryObj.Height;
        }
        public bool isDynamic()
        {
            return false;
        }
        public bool isUpdateable()
        {
            return false;
        }
        public bool isDrawable()
        {
            return false;
        }
        public bool isInPlay()
        {
            return true;
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
            //Nothing to update
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Nothing to draw
        }
        public GameObjectType type { get { return GameObjectType.BOUNDARY; } }
    }
}
