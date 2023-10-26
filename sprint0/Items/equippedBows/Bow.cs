using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0.Items
{
    public class Bow : IItem , IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        private int spriteVelocity = 1;
        // needs these positions for sprite swapping.

        //direction stuff
        private enum Direction { LEFT, RIGHT, UP, DOWN };
        private Texture2D upBowTexture;
        private Texture2D downBowTexture;
        private Texture2D leftBowTexture;
        private Texture2D rightBowTexture;
        private Texture2D bowDespawnTextures;
        private IItemSprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool spriteChanged;

        public Bow(IList<Texture2D> itemSpriteSheet)
		{
            upBowTexture = itemSpriteSheet[3];
            downBowTexture = itemSpriteSheet[2];
            leftBowTexture = itemSpriteSheet[0];
            rightBowTexture = itemSpriteSheet[1];
            bowDespawnTextures = itemSpriteSheet[4];
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.DOWN;
            spriteChanged = false;

		}

        public void Draw(SpriteBatch spriteBatch)
        {
            if (thisStateMachine.isItemInUse() && this.currentItemSprite != null)
            {
                currentItemSprite.Draw(spriteBatch, itemXPos, itemYPos);
            }
        }

        public void Update()
        {
            if (thisStateMachine.isItemInUse())
            {
                // has the sprite reached it's final location?
                if (itemXPos >= itemMaxX || itemYPos >= itemMaxY || itemXPos <= itemMinX || itemYPos <= itemMinY)
                {
                    ChangeSprite();
                }
                else
                {
                    // update the x and y position of the item positions based on
                    // the adventures the sprite has taken.
                    // switch case bad i know, i know.
                    switch (this.currentItemDirection)
                    {
                        case Direction.RIGHT:
                            itemXPos+= spriteVelocity;
                            break;
                        case Direction.UP:
                            itemYPos-= spriteVelocity;
                            break;
                        case Direction.DOWN:
                            itemYPos+= spriteVelocity;
                            break;
                        case Direction.LEFT:
                            itemXPos-= spriteVelocity;
                            break;
                    }
                    
                }
                if (this.currentItemSprite != null)
                {
                    this.currentItemSprite.Update();
                }
            }

        }

        /*
         * Changes the Sprite to display the impact animation.
         */
        public void ChangeSprite()
        {
            if (!this.spriteChanged)
            {
                this.currentItemSprite = new BowDespawnSprite(bowDespawnTextures, 1, 1);
                this.spriteChanged = true;
            } else if (this.currentItemSprite.finishedAnimationCycle() && this.spriteChanged)
            {
                thisStateMachine.CeaseUse();
                this.spriteChanged = false; //reset
                this.currentItemSprite = null;
            }
        }

        public void Use(int linkDirection, int linkXPos, int linkYPos)
        {
            
            if (!thisStateMachine.isItemInUse())
            {
                this.spriteChanged = false; //reset
                thisStateMachine.Use(); // sets usage in play
                this.itemXPos = linkXPos;
                this.itemYPos = linkYPos;
                this.itemMaxX = linkXPos + 100;
                this.itemMaxY = linkYPos + 100;
                this.itemMinX = linkXPos - 100;
                this.itemMinY = linkYPos - 100;
                // since the bow may go up or down.
                // all items start at the same position as link.
                // Set the the current item sprite based on link orientation (if needed).
                switch (linkDirection)
                {
                    case (int)Direction.RIGHT:
                        currentItemSprite = new BowSprite(rightBowTexture, 1, 1);
                        currentItemDirection = Direction.RIGHT;
                        break;
                    case (int)Direction.UP:
                        currentItemSprite = new BowSprite(upBowTexture, 1, 1);
                        currentItemDirection = Direction.UP;
                        break;
                    case (int)Direction.DOWN:
                        currentItemSprite = new BowSprite(downBowTexture, 1, 1);
                        currentItemDirection = Direction.DOWN;
                        break;
                    case(int)Direction.LEFT:
                        currentItemSprite = new BowSprite(leftBowTexture, 1, 1);
                        currentItemDirection = Direction.LEFT;
                        break;

                }
            }

           
        }

        public int xPosition()
        {
            return itemXPos;
        }

        public int yPosition()
        {
            return itemYPos;
        }

        public int width()
        {
            return this.currentItemSprite.itemWidth();
        }

        public int height()
        {
            return this.currentItemSprite.itemHeight();
        }

        public bool isDynamic()
        {
            return true;
        }
    }
}

