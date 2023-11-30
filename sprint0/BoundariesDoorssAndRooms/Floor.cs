using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.BoundariesDoorsAndRooms
{
    internal class Floor : IGameObject
    {
        Vector2 position;
        ISprite floorSprite;
        int roomId;
        public Floor(int x, int y, SpriteFactory floorFactory)
        {
            position.X = x; position.Y = y;
            floorSprite = floorFactory.getAnimatedSprite("Floor");
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
            return floorSprite.GetWidth();
        }
        public int height()
        {
            return floorSprite.GetHeight();
        }
        public void SetRoomId(int roomId)
        {
            this.roomId = roomId;
        }
        public int GetRoomId()
        {
            return roomId;
        }
        public bool isDynamic()
        {
            return false;
        }
        public bool isDrawable()
        {
            return true;
        }
        public bool isInPlay()
        {
            return true;
        }
        public bool isUpdateable()
        {
            return false;
        }
        public void Update()
        {
            //nothing to update
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            floorSprite.Draw(spriteBatch, xPosition(), yPosition(), 0);
        }
        public GameObjectType type { get { return GameObjectType.FLOOR; } }
    }
}
