using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;

namespace sprint0
{
    public class BombSprite : ISprite, IItemSprite
    {
        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private int CurrentFrame = 0;
        private int width;
        private int height;

        public BombSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;

        }

        public bool finishedAnimationCycle()
        {
            return false; // infinite cycle / no cycle .
        }


        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
           
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;
            Rectangle incomingSprite = new Rectangle(width * column, height * row, width, height);
            Rectangle drawnSprite = new Rectangle(x, y, width, height);
            spriteBatch.Draw(Texture, drawnSprite, incomingSprite, Color.White);
        }

        public int itemWidth()
        {
            return width;
        }

        public int itemHeight()
        {
            return height;
        }
    }
}

