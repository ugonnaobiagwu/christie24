using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0.Items
{
    public class BetterBoomerang : IItem, IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        private int itemXOrigin;
        private int itemYOrigin;
        private int spriteVelocity = 3;
        // needs these positions for sprite swapping.

        //direction stuff
        private enum Direction { LEFT, RIGHT, UP, DOWN };
        private Texture2D goingTexture;
        private Texture2D comingTexture;
        private IItemSprite currentItemSprite;
        private IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool spriteChanged;

        public BetterBoomerang(IList<Texture2D> itemSpriteSheet)
        {
            goingTexture = itemSpriteSheet[0];
            comingTexture = itemSpriteSheet[1];
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.LEFT;
            spriteChanged = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (thisStateMachine.isItemInUse())
            {
                currentItemSprite.Draw(spriteBatch, itemXPos, itemYPos);
            }
        }

        public void Update()
        {
            if (thisStateMachine.isItemInUse())
            {
                // has the sprite reached it's final location?
                if ((itemXPos >= itemMaxX || itemYPos >= itemMaxY || itemXPos <= itemMinX || itemYPos <= itemMinY) && (!this.spriteChanged)) // sprite just reached its max
                {
                    ChangeSprite();
                }
                else if (this.spriteChanged) // sprite has reached its max and is on its way home
                {
                    if (SpriteAtOrigin())
                    { // if sprite makes it home
                        thisStateMachine.CeaseUse();
                    }
                    switch (this.currentItemDirection)
                    {
                        case Direction.RIGHT:
                            itemXPos -= spriteVelocity;
                            break;
                        case Direction.UP:
                            itemYPos -= spriteVelocity;
                            break;
                        case Direction.DOWN:
                            itemYPos += spriteVelocity;
                            break;
                        default:
                            itemXPos += spriteVelocity;
                            break;
                    }
                    if (SpriteAtOrigin()) // if sprite makes it home
                        thisStateMachine.CeaseUse();
                }
                else
                {
                    // update the x and y position of the item positions based on
                    // the adventures the sprite has taken.
                    // switch case bad i know, i know.
                    switch (this.currentItemDirection)
                    {
                        case Direction.RIGHT:
                            itemXPos += spriteVelocity;
                            break;
                        case Direction.UP:
                            itemYPos += spriteVelocity;
                            break;
                        case Direction.DOWN:
                            itemYPos -= spriteVelocity;
                            break;
                        default:
                            itemXPos -= spriteVelocity;
                            break;
                    }

                }
                this.currentItemSprite.Update();

            }

        }

        /*
         * Changes the Sprite to display the backwards sprite.
         */
        public void ChangeSprite()
        {
            if (!this.spriteChanged)
            {
                this.currentItemSprite = new BoomerangSprite(comingTexture, 1, 3);
                this.spriteChanged = true;
            }
        }

        /*
         * Tests to see if sprite has returned home
         */
        public bool SpriteAtOrigin()
        {
            return (itemXPos == itemXOrigin) && (itemYPos == itemYOrigin);
        }

        public void Use(int linkDirection, int linkXPos, int linkYPos)
        {
            if (!thisStateMachine.isItemInUse())
            {
                thisStateMachine.Use(); // sets usage in play
                this.itemXPos = linkXPos;
                this.itemXOrigin = linkXPos;
                this.itemYPos = linkYPos;
                this.itemYOrigin = linkYPos;
                this.itemMaxX = linkXPos + 200;
                this.itemMaxY = linkYPos + 200;
                this.itemMinX = linkXPos - 200;
                this.itemMinY = linkYPos - 200;
                currentItemSprite = new BoomerangSprite(goingTexture, 1, 3);
                // since the bow may go up or down.
                // all items start at the same position as link.
                // Set the the current item sprite based on link orientation (if needed).
                switch (linkDirection)
                {
                    case (int)Direction.RIGHT:
                        currentItemDirection = Direction.RIGHT;
                        break;
                    case (int)Direction.UP:
                        currentItemDirection = Direction.UP;
                        break;
                    case (int)Direction.DOWN:
                        currentItemDirection = Direction.DOWN;
                        break;
                    default:
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

