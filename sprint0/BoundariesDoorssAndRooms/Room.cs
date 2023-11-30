using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sprint0.BoundariesDoorsAndRooms
{
    public class Room : IGameObject
    {
        ISprite roomSprite;
        Vector2 position;
        int roomId;
        public Room(int x, int y, SpriteFactory roomFactory)
        {
            roomSprite = roomFactory.getAnimatedSprite("Room");
            position = new Vector2(x, y);
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
            return roomSprite.GetWidth();
        }
        public int height()
        {
            return roomSprite.GetHeight();
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
            return true;
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
            roomSprite.Draw(spriteBatch,xPosition(), yPosition(), 0.0f);
        }
        public GameObjectType type { get { return GameObjectType.ROOM; } }
    }
}
