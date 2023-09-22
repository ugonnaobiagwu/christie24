using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
	public class BetterBowSprite : ISprite
	{
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int spriteXPos;
        public int spriteYPos;


        public BetterBowSprite(Texture2D texture, int rows, int columns)
		{
            Texture = texture;
            Rows = rows;
            Columns = columns;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

