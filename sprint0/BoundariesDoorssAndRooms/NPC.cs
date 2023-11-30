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
    internal class NPC : IGameObject
    {
        Vector2 position;
        ISprite nPCSprite;
        int roomId;
        public NPC(int x, int y, SpriteFactory spriteFactory)
        {
            position = new Vector2(x, y);
            nPCSprite = spriteFactory.getAnimatedSprite("NPC");
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
            return nPCSprite.GetWidth();
        }
        public int height()
        {
            return nPCSprite.GetHeight();
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
        public bool isUpdateable()
        {
            return false;
        }
        public bool isInPlay()
        {
            return true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            nPCSprite.Draw(spriteBatch, xPosition(), yPosition(), 0);
        }
        public void Update()
        {
            //nothing to update
        }
        public GameObjectType type { get { return GameObjectType.NPC; } }
    }
}
