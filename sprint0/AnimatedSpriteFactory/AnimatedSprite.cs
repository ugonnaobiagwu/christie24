using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using sprint0;

namespace sprint0.AnimatedSpriteFactory
{
    public class AnimatedSprite : ISprite
    {
        public Texture2D Texture;
        public Vector2 position;
        public int Rows;
        public int Columns;
        private Vector2 scaleVector;
        private float scaleWidth, scaleHeight;
        private int CurrentFrame;
        private int TotalFrames;
        private float frameTime;
        private float frameTimeLeft;
        private bool active = true;
        private List<Rectangle> SourceRectangles;
        private bool animationComplete;
        public AnimatedSprite(Texture2D texture, List<Rectangle> sourceRectangles, int totalFrames, int rows, int columns, float secondsPerFrame, float width, float height)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = totalFrames;
            SourceRectangles = sourceRectangles;
            frameTime = secondsPerFrame;
            frameTimeLeft = secondsPerFrame;
            position = new Vector2(0, 0);
            scaleWidth = width;
            scaleHeight = height;
            scaleVector.X = width;
            scaleVector.Y = height;
            animationComplete = false;
        }
        public int GetWidth()
        {

            int width = Texture.Width / Columns;
            return (int)(scaleWidth * width);
        }

        public int GetHeight()
        {
            int height = Texture.Height / Rows;
            return (int)(scaleHeight * height);
        }
        public int GetTotalFrames()
        {
            return TotalFrames;
        }
        public int GetCurrentFrame()
        {
            return CurrentFrame;
        }
        public bool GetAnimationComplete()
        {
            return animationComplete;
        }
        public void Stop()
        {
            active = false;
        }
        public void Reset()
        {
            CurrentFrame = 0;
            active = true;
        }
        public bool GetAnimationComplete()
        {
            return animationComplete;
        }
        public void Update()
        {

            if (!active) return;
            frameTimeLeft -= Globals.TotalSeconds;
            if (frameTimeLeft <= 0)
            {
                frameTimeLeft += frameTime;
                CurrentFrame = (CurrentFrame + 1) % TotalFrames;

                //Console.WriteLine("sprite updated");
            }
            animationComplete = false;
            if ((CurrentFrame + 1) == TotalFrames)
            {
                animationComplete = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y, float rotation)
        {
            //Sets length of each source rectangle relative to sprite sheet
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            Vector2 origin = new Vector2();
            origin.X = width - (width / 2);
            origin.Y = height - (height / 2);
            SpriteEffects spriteEffect = SpriteEffects.None;
            position.X = x;
            position.Y = y;

            //Old code for finding rectangle on sprite sheet
            //int row = CurrentFrame / Columns;
            //int column = (CurrentFrame % Columns);
            //Rectangle sheetLocation = new Rectangle(width * column, height * row, width, height);

            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);


            spriteBatch.Draw(Texture, position, SourceRectangles[CurrentFrame], Color.White, rotation, origin, scaleVector, spriteEffect, 0.0f);


        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            position.X = x;
            position.Y = y;

            //Old code for finding rectangle on sprite sheet
            //int row = CurrentFrame / Columns;
            //int column = (CurrentFrame % Columns);
            //Rectangle sheetLocation = new Rectangle(width * column, height * row, width, height);

            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y,width ,height);


            spriteBatch.Draw(Texture, new Vector2(50, 50), SourceRectangles[CurrentFrame], Color.White, rotation, origin, scaleVector, spriteEffect, 0.0f);


        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Sets length of each source rectangle relative to sprite sheet
            int width = Texture.Width / Columns;
            int height = Texture.Height / Columns;
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, SourceRectangles[CurrentFrame], Color.White);
        }
    }
}
