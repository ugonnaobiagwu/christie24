using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items
{
	public class BombSprite : ISprite
	{
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public BombSprite()
		{
		}

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

