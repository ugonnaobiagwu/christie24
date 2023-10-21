using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.AnimatedSpriteFactory
{
    /*EDITED FOR LINK TESTING: TO BE DELETED*/
    public class AnimatedSprite : ISprite
    {

        public Texture2D Texture;
        public Vector2 position;
        public int Rows;
        public int Columns;
        private int CurrentFrame;
        private int TotalFrames;
        private float frameTime;
        private float frameTimeLeft;
        private bool active = true;
        private List<Rectangle> SourceRectangles;
        public GameTime GameTime;
        //Add methods to get width and height


        public AnimatedSprite(Texture2D texture, List<Rectangle> sourceRectangles, int totalFrames, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = totalFrames;
            SourceRectangles = sourceRectangles;
            GameTime = new GameTime();
            frameTime = (float)0.0;
            frameTimeLeft = (float)0.0;
            position = new Vector2(0, 0);
        }
        public void changeXandY(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }
        public void Update()
        {
            //CurrentFrame = (int)GameTime.ElapsedGameTime.TotalSeconds % TotalFrames;
            if (!active) return;

            frameTimeLeft -= (float)GameTime.ElapsedGameTime.TotalSeconds;
            Console.WriteLine((float)GameTime.ElapsedGameTime.TotalSeconds);
            if (frameTimeLeft <= 0)
            {
                frameTimeLeft += frameTime;
                CurrentFrame = (CurrentFrame + 1) % TotalFrames;

                Console.WriteLine("sprite updated");
            }

        }
        /*NOTE: EDITED FOR LINK TESTING*/
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            //Sets length of each source rectangle relative to sprite sheet
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;

            /* position.X = x;
             position.Y = y;*/

            //Old code for finding rectangle on sprite sheet
            //int row = CurrentFrame / Columns;
            //int column = (CurrentFrame % Columns);
            //Rectangle sheetLocation = new Rectangle(width * column, height * row, width, height);

            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);


            spriteBatch.Draw(Texture, destinationRectangle, SourceRectangles[CurrentFrame], Color.White);

        }
        /*public void Draw(SpriteBatch spriteBatch)
        {
            //Sets length of each source rectangle relative to sprite sheet
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            spriteBatch.Draw(Texture, position, SourceRectangles[CurrentFrame], Color.White);
        }*/
    }
        
}