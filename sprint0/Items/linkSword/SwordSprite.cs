﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items.LinkSword
{
	public class SwordSprite : ISprite
	{
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame;
        private int width;
        private int height;

        public SwordSprite(Texture2D texture, int rows, int columns)
		{
            Texture = texture;
            Rows = rows;
            Columns = columns;
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int row = CurrentFrame / Columns;
            int column = (CurrentFrame % Columns);

            Rectangle sheetLocation = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sheetLocation, Color.White);
        }

        public void Update()
        {
            
        }

        public int getWidth()
        {
            return this.width;
        }

        public int getHeight()
        {
            return this.height;
        }
    }
}
