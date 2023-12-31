﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
namespace sprint0.AnimatedSpriteFactory
{
	public class SpriteFactory 
	{
		private Texture2D spriteSheet;
        private Vector2 position;
        private IDictionary<string, ISprite> animationDictionary;
		private int spriteSheetRows, spriteSheetColumns;


        public SpriteFactory(Texture2D newSpriteSheet,  int sheetRows, int sheetColumns)
		{
            spriteSheet = newSpriteSheet;
            spriteSheetRows = sheetRows;
            spriteSheetColumns = sheetColumns;
            animationDictionary = new Dictionary<string, ISprite>();

            //Setting position at 0 for default, can use method to change or add new constructor field in the future
            position = new Vector2(0,0);
            
		}

		public void createAnimation(string animationName, int[] spriteRows, int[]spriteColumns, int frameCount)
		{
			List<Rectangle> sourceRectangleList = new List<Rectangle>();
            int width = spriteSheet.Width / spriteSheetColumns;
            
            int height = spriteSheet.Height / spriteSheetRows;

            //Creates List containing source rectangles
            for (int i = 0; i < frameCount; i++)
            {
                //Operations to find position and make current sprite
                //Ask people better at sprite sheet math about this
                Rectangle sheetLocation = new Rectangle(width * spriteColumns[i], height * spriteRows[i], width, height);

                sourceRectangleList.Add(sheetLocation);
            }

            //Create AnimatedSprite object using created sourceRectangle list
            ISprite currentSprite = new AnimatedSprite(spriteSheet, sourceRectangleList, frameCount, spriteSheetRows, spriteSheetColumns, (float)0.5,50,50);

            //Add animated sprite to dictionary
            animationDictionary.Add(animationName, currentSprite);
        }
        public void createAnimation(string animationName, int[] spriteRows, int[] spriteColumns, int frameCount, float secondsPerFrame, float spriteWidthScale = 1.0f, float spriteHeightScale = 1.0f)
        {
            List<Rectangle> sourceRectangleList = new List<Rectangle>();
            int width = spriteSheet.Width / spriteSheetColumns;
            int height = spriteSheet.Height / spriteSheetRows;

            //Creates List containing source rectangles
            for (int i = 0; i < frameCount; i++)
            {
                //Operations to find position and make current sprite
                //Ask people better at sprite sheet math about this
                Rectangle sheetLocation = new Rectangle(width * spriteColumns[i], height * spriteRows[i], width, height);

                sourceRectangleList.Add(sheetLocation);
            }

            //Create AnimatedSprite object using created sourceRectangle list
            ISprite currentSprite = new AnimatedSprite(spriteSheet, sourceRectangleList, frameCount, spriteSheetRows, spriteSheetColumns, secondsPerFrame, spriteWidthScale, spriteHeightScale);

            //Add animated sprite to dictionary
            animationDictionary.Add(animationName, currentSprite);
        }

        public void updatePosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }


        public ISprite getAnimatedSprite(string animationName)
        {
         ISprite newSprite =  animationDictionary[animationName];
            return newSprite;
        }
    }
}

