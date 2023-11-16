using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
	public interface IGameObject
	{
		public int xPosition(); // returns X pos of object
		public int yPosition(); // returns Y pos of object
		public int width(); // (i.e.) "how big are you?"
        public int height(); // (i.e.) "how big are you?"
        public bool isDynamic(); // does this object move?
        public bool isUpdateable();
        public bool isInPlay();
        public bool isDrawable();
        public String type();
        public void SetRoomId(int roomId);
        public int GetRoomId();
	public void Draw(SpriteBatch spritebatch);
	public void Update();
    }
}

