using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;

namespace sprint0
{
    public class ExplosionSprite : ISprite, IItemSprite
    {
        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private int CurrentFrame;
        private int TotalFrames;
        private bool animationCycleFinished;

        private int width;
        private int height;
        public ExplosionSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = 2;
            animationCycleFinished = false;
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;
        }

        public bool finishedAnimationCycle()
        {
            return animationCycleFinished; 
        }


        public void Update()
        {
            
            if (CurrentFrame == TotalFrames)
            {
                animationCycleFinished = true;
            } else
            {
                CurrentFrame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;
            Rectangle incomingSprite = new Rectangle(width * column, height * row, width, height);
            Rectangle drawnSprite = new Rectangle(x, y, width, height);
            spriteBatch.Draw(Texture, drawnSprite, incomingSprite, Color.White);
        }

        // collision: hit box is expanded since explosion has bigger radius
        public int itemWidth()
        {
            return width + 5;
        }

        public int itemHeight()
        {
            return height + 5;
        }
    }
}

