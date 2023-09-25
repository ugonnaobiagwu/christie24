using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;

namespace sprint0
{
    public class UpBowSprite : ISprite, IItemSprite
    {
        private Texture2D Texture;
        private int Rows;
        private int Columns;
        private int CurrentFrame = 0;
        private int SpriteXPos;
        private int SpriteYPos;
        private int spriteVelocity = 1;

        public UpBowSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

        }

        public int currentItemXPos()
        {
            return SpriteXPos;
        }

        public int currentItemYPos()
        {
            return SpriteYPos;
        }

        public bool finishedAnimationCycle()
        {
            return false; // infinite cycle / no cycle .
        }


        public void Update()
        {
            SpriteYPos+=spriteVelocity;
        }



        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;
            Rectangle incomingSprite = new Rectangle(width * column, height * row, width, height);
            Rectangle drawnSprite = new Rectangle(SpriteXPos, y + SpriteYPos, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, drawnSprite, incomingSprite, Color.White);
            spriteBatch.End();
        }
    }
}

