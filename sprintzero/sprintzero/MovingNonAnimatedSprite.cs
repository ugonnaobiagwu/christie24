using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static sprintzero.Game1;

namespace sprintzero
{
    public class MovingNonAnimatedSprite : ISprite
    {
        public Texture2D SpriteSheet { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int Frame;
        private int spriteXPos = 400;
        private int spriteYPos = 0;

        public MovingNonAnimatedSprite(Texture2D spritesheet, int rows, int columns)
        {
            SpriteSheet = spritesheet;
            Rows = rows;
            Columns = columns;
            Frame = 0;
        }

        public void Update(Viewport viewport)
        {
            spriteYPos++;
            if (spriteYPos > viewport.Height)
                spriteYPos = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = SpriteSheet.Width / Columns;
            int height = SpriteSheet.Height / Rows;
            int row = Frame / Columns;
            int column = Frame % Columns;
            Rectangle incomingSprite = new Rectangle(width * column, height * row, width, height);
            Rectangle drawnSprite = new Rectangle(spriteXPos, spriteYPos, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(SpriteSheet, drawnSprite, incomingSprite, Color.White);
            spriteBatch.End();
        }
    }
}

