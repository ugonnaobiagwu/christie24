using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;
using sprint0.AnimatedSpriteFactory;

namespace sprint0.Items
{
    public class BetterBow : IItem, IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        private float rotation;
        private int spriteVelocity = 3;
        // needs these positions for sprite swapping.

        //direction stuff
        private enum Direction { LEFT, RIGHT, UP, DOWN };
        private int itemRoomID;
        private SpriteFactory itemSpriteFactory;
        private SpriteFactory despawnSpriteFactory;
        private ISprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool spriteChanged;

        public BetterBow(SpriteFactory factory, SpriteFactory despawnFactory)
        {
            itemSpriteFactory = factory;
            despawnSpriteFactory = despawnFactory;
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.DOWN;
            spriteChanged = false;
            rotation = 0;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (thisStateMachine.isItemInUse() && this.currentItemSprite != null)
            {
                currentItemSprite.Draw(spriteBatch, itemXPos, itemYPos, rotation);
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
                            itemXPos += spriteVelocity;
                            break;
                        case Direction.UP:
                            itemYPos -= spriteVelocity;
                            break;
                        case Direction.DOWN:
                            itemYPos += spriteVelocity;
                            break;
                        case Direction.LEFT:
                            itemXPos -= spriteVelocity;
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
                this.currentItemSprite = despawnSpriteFactory.getAnimatedSprite("BowDespawn");
                this.spriteChanged = true;
            }
            else if (finishedAnimationCycle() && this.spriteChanged)
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
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("BetterBow");
                switch (linkDirection)
                {
                    case (int)Direction.RIGHT:
                        rotation = -90;
                        currentItemDirection = Direction.RIGHT;
                        break;
                    case (int)Direction.UP:
                        rotation = 180;
                        currentItemDirection = Direction.UP;
                        break;
                    case (int)Direction.DOWN:
                        rotation = 0;
                        currentItemDirection = Direction.DOWN;
                        break;
                    case (int)Direction.LEFT:
                        rotation = 90;
                        currentItemDirection = Direction.LEFT;
                        break;
                }
            }
        }

        private bool finishedAnimationCycle()
        {
            if (currentItemSprite.GetCurrentFrame() >= currentItemSprite.GetTotalFrames())
            {
                return true;
            }
            else
            {
                return false;
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
            return this.currentItemSprite.GetWidth();
        }

        public int height()
        {
            return this.currentItemSprite.GetHeight();
        }

        public bool isDynamic()
        {
            return true;
        }

        public bool isUpdateable()
        {
            return true;
        }

        public bool isInPlay()
        {
            return thisStateMachine.isItemInUse();
        }

        public bool isDrawable()
        {
            return true;
        }

        public void SetRoomId(int roomId)
        {
            this.itemRoomID = roomId;
        }

        public int GetRoomId()
        {
            return this.itemRoomID;
        }
    }
}


