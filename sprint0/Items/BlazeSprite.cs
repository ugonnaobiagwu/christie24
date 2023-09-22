using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items
{
	public class BlazeSprite : ISprite
	{
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public BlazeSprite()
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

