using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;

namespace sprint0
{
    public class BoomerangSprite : ISprite, IItemSprite
    {
        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private int CurrentFrame;
        private int TotalFrames;

        public BoomerangSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = 2;

        }

        public bool finishedAnimationCycle()
        {
            return false; // infinite cycle / no cycle .
        }


        public void Update()
        {
            CurrentFrame++;
            if (CurrentFrame == TotalFrames)
            {
                CurrentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;
            Rectangle incomingSprite = new Rectangle(width * column, height * row, width, height);
            Rectangle drawnSprite = new Rectangle(x, y, width, height);
            spriteBatch.Draw(Texture, drawnSprite, incomingSprite, Color.White);
        }
    }
}

