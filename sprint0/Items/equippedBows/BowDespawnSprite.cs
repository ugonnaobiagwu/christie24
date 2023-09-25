using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items
{
	public class BowDespawnSprite : ISprite, IItemSprite
	{
        private bool animationCycleFinished = false;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame;
        private int TotalFrames;
        public BowDespawnSprite(Texture2D texture, int rows, int columns)
		{
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = 1;
        }

        public int currentItemXPos()
        {
            return -1;
        }

        public int currentItemYPos()
        {
            return -1;
        }

        public bool finishedAnimationCycle()
        {
            return animationCycleFinished;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            /*Figures out where the sprite we want is*/
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int xLoc = 1;
            int yLoc = 0;

            Rectangle sheetLocation = new Rectangle(width * xLoc, height * yLoc, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);

            /*POTENTIAL BAD CODE: Dr. Kirby mentioned that Begin() and End() before and after each draw is sketchy*/
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sheetLocation, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            CurrentFrame++;
            if (CurrentFrame == TotalFrames)
            {
                this.animationCycleFinished = true;
            }
        }
    }
}

