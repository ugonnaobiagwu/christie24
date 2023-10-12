using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items
{
	public class BowDespawnSprite : ISprite, IItemSprite
	{
        private bool animationCycleFinished;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame;
        private int TotalFrames;
        private int FrameDisplay;
        public BowDespawnSprite(Texture2D texture, int rows, int columns)
		{
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            FrameDisplay = 0;
            TotalFrames = 10;
            animationCycleFinished = false;
        }

        public bool finishedAnimationCycle()
        {
            return animationCycleFinished;
        }

        public void Update()
        {
            FrameDisplay++;
            if (FrameDisplay >= TotalFrames)
            {
                animationCycleFinished = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            /*Figures out where the sprite we want is*/
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;
            Rectangle sheetLocation = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);

            /*POTENTIAL BAD CODE: Dr. Kirby mentioned that Begin() and End() before and after each draw is sketchy*/
           
            spriteBatch.Draw(Texture, destinationRectangle, sheetLocation, Color.White);
           
        }

        
    }
}

