using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;
using sprint0.Items.LinkSword;

namespace sprint0.LinkSword
{

    /* 
     * NOTE TO SELF: 
     * 
     * 1. NEED GLOBAL CLASS FOR TIMERS STILL.
     * 2. NEED TO LOAD THE ITEM SYSTEM WITH THE RIGHT SPRITES STILL.
     * 3. NEED TO UPDATE ITEM SYSTEM INTERFACE
     * 4. NEED TO ENSURE ITEM SYSTEM KEEPS THE LINK SWORD OBJECT ALIVE
     * 5. NEED TO ENSURE GAME1 UPDATES AND DRAWS THE SWORD THROUGH THE 
     * ITEM SYSTEM.
     * 
     * 
     */
	public class LinkSword : ILinkSword
	{
		private SwordSprite currentSprite;
        private int xPos;
        private int yPos;
        private int linkHeight;
        private int linkWidth;
        private Texture2D upSword;
        private Texture2D downSword;
        private Texture2D leftSword;
        private Texture2D rightSword;
        private IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool isDrawn;
        private int maxTime;
        private int elapsedTime;

        private enum Direction { LEFT, RIGHT, UP, DOWN };

        /*
         * Constant lifetime, will not get instantiated upon equipment like other items do.
         */
        public LinkSword(IList<Texture2D> itemSpriteSheet)
		{
            upSword = itemSpriteSheet[0];
            downSword = itemSpriteSheet[1];
            leftSword = itemSpriteSheet[2];
            rightSword = itemSpriteSheet[3];
            currentItemDirection = Direction.LEFT;
            
        }

        public void Draw(SpriteBatch spritebatch)
        {
          if (isDrawn)
            {
                switch (currentItemDirection)
                {
                    // SET DRAW TO THE MUCKED UP X AND Y POS THAT THE SWORD MUST BE DRAWN AT.
                    // HALFWAY THROUGH + ALL THE WAY TO THE EDGE OF THE SPRITE DEPENDING ON ORIENT.
                    case Direction.LEFT:
                        currentSprite.Draw(spritebatch, xPos - linkWidth, yPos - (linkHeight / 2));
                        break;
                    case Direction.RIGHT:
                        currentSprite.Draw(spritebatch, xPos + linkWidth, yPos - (linkHeight / 2));
                        break;
                    case Direction.DOWN:
                        currentSprite.Draw(spritebatch, xPos + (linkWidth / 2), yPos + linkHeight);
                        break;
                    case Direction.UP:
                        currentSprite.Draw(spritebatch, xPos + (linkWidth / 2), yPos - linkHeight);
                        break;
                }
            }
        }

        public int height()
        {
            return this.currentSprite.getHeight();
        }

        public bool isDynamic()
        {
           return false;
        }

        public void SwingSword(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
          
            this.xPos = linkXPos;
            this.yPos = linkYPos;
            this.linkHeight = linkHeight;
            this.linkWidth = linkWidth;
            this.currentItemDirection = (Direction)linkDirection;
            switch (currentItemDirection)
            {
                case Direction.LEFT:
                    currentSprite = new SwordSprite(leftSword, 1, 1);
                    break;
                case Direction.RIGHT:
                    currentSprite = new SwordSprite(rightSword, 1, 1);
                    break;
                case Direction.UP:
                    currentSprite = new SwordSprite(upSword, 1, 1);
                    break;
                case Direction.DOWN:
                    currentSprite = new SwordSprite(downSword, 1, 1);
                    break;
            }
            isDrawn = true;
        }

        public void Update()
        {
          /* if the amount of time thats passed is equal to or exceeds the max amount of time for a sword to be drawn, 
           * set isDrawn to false.
           */
        }

        public int width()
        {
            return this.currentSprite.getWidth();
        }

        public int xPosition()
        {
            switch (currentItemDirection)
            {
                // SET DRAW TO THE MUCKED UP X AND Y POS THAT THE SWORD MUST BE DRAWN AT.
                // HALFWAY THROUGH + ALL THE WAY TO THE EDGE OF THE SPRITE DEPENDING ON ORIENT.
                case Direction.LEFT:
                    return xPos - linkWidth;
                case Direction.RIGHT:
                    return xPos + linkWidth;
                case Direction.DOWN:
                    return xPos + (linkWidth / 2);
                case Direction.UP:
                    return xPos + (linkWidth / 2);
                default:
                    return xPos;
            }
        }

        public int yPosition()
        {
            switch (currentItemDirection)
            {
                // SET DRAW TO THE MUCKED UP X AND Y POS THAT THE SWORD MUST BE DRAWN AT.
                // HALFWAY THROUGH + ALL THE WAY TO THE EDGE OF THE SPRITE DEPENDING ON ORIENT.
                case Direction.LEFT:
                    return yPos - (linkHeight / 2);
                case Direction.RIGHT:
                    return yPos - (linkHeight / 2);
                case Direction.DOWN:
                    return yPos + linkHeight;
                case Direction.UP:
                    return yPos - linkHeight;
                default:
                    return yPos;
            }
        }

        public bool isInPlay()
        {
            return isDrawn;
        }

    }
}

