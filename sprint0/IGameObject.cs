using Microsoft.Xna.Framework.Graphics;
using System;
using System.Security.Cryptography.X509Certificates;


namespace sprint0
{
    public interface IGameObject
    {
        public int xPosition();
        public int yPosition();
        public int width();
        public int height();
        public bool isDynamic();
        public bool isUpdateable();
        public bool isInPlay();
        public bool isDrawable();
        public void SetRoomId(int roomId);
        public int GetRoomId();
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
        public String type();
    }
}
