using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace sprint0.Factory
{
	public abstract class SpriteFactory : ISprite
	{
        private Texture2D SpriteSheet { get; set; }
        private Vector2 SpritePosition { get; set; }
        private int SpriteHeight { get; set; }
        private int SpriteWidth { get; set; }
        private string SpriteName { get; set; }
        private string SpriteDirection { get; set; }
        private int SpriteFrames { get; set; }
        private IDictionary<int, Rectangle> textureDictionary;
		public SpriteFactory()
		{
		}

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            Rectangle destinationRectangle = new Rectangle((int)SpritePosition.X, (int)SpritePosition.Y, x, y);
            for (int i =0; i < textureDictionary.Count; i++)
            {
                spriteBatch.Draw(SpriteSheet, destinationRectangle, textureDictionary[i], Color.White);
                //Need to add gametime wait here, could vary between implementations, new instance variable??
            }
        }
        //Overload for draw without need for x and y coordinates
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)SpritePosition.X, (int)SpritePosition.Y, SpriteWidth, SpriteHeight);
            for (int i = 0; i < textureDictionary.Count; i++)
            {
                spriteBatch.Draw(SpriteSheet, destinationRectangle, textureDictionary[i], Color.White);
                //Need to add gametime wait here, could vary between implementations, new instance variable??
            }
        }
        public void Update()
        {
            //ask about update
            //changes current animation frame
            throw new NotImplementedException();
        }

        //Method to make texture dictionary, uniform among all implementing factories
        public IDictionary<int, Rectangle> MakeDictionary(Texture2D newSpriteSheet, int spriteSheetRows, int spriteSheetColumns, int[] currentRow, int[] currentColumn, int frameCount)
        {
            textureDictionary = new Dictionary<int, Rectangle>();
            int width = newSpriteSheet.Width / spriteSheetColumns;
            int height = newSpriteSheet.Height / spriteSheetRows;
            //Loop to iterate through all frames of the spriteSheet, adds to the dictionary, mb change i to a better name
            for (int i = 0; i < frameCount; i++)
            {
                //Operations to find position and make current sprite
                //Ask people better at sprite sheet math about this
                int row = i / spriteSheetColumns;
                int column = (i % spriteSheetColumns);
                Rectangle sheetLocation = new Rectangle(width * column, height * row, width, height);

                textureDictionary.Add(i, sheetLocation);
            }
            return textureDictionary;
        }

        //Factory specific methods, to be implemented in their own classes
        //Why doesn't this work????
        public abstract void attack();
        public abstract void changeDirection(string v);
    }
}

