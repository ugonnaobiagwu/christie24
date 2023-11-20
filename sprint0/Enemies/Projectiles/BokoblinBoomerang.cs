using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Enemies;

namespace sprint0.Items
{
    public class BokoblinBoomerang : IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        private int itemXOrigin;
        private int itemYOrigin;
        private int spriteVelocity = 1;
        private int itemRoomID;
        //private Bokoblin Owner;
        // needs these positions for sprite swapping.

        //direction stuff
        private enum Direction { LEFT, RIGHT, UP, DOWN };
        private SpriteFactory itemSpriteFactory;
        private ISprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool spriteChanged;

        public BokoblinBoomerang(SpriteFactory factory)
        {
            itemSpriteFactory = factory;
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
            Debug.WriteLine(this.thisStateMachine.isItemInUse());
            if (thisStateMachine.isItemInUse())
            {
                // has the sprite reached it's final location?
                if ((itemXPos >= itemMaxX || itemYPos >= itemMaxY || itemXPos <= itemMinX || itemYPos <= itemMinY) && (!this.spriteChanged)) // sprite just reached its max
                {
                    ChangeSprite();
                }
                else if (this.spriteChanged) // sprite has reached its max and is on its way home
                {
                    switch (this.currentItemDirection)
                    {
                        case Direction.RIGHT:
                            itemXPos -= spriteVelocity;
                            break;
                        case Direction.UP:
                            itemYPos += spriteVelocity;
                            break;
                        case Direction.DOWN:
                            itemYPos -= spriteVelocity;
                            break;
                        case Direction.LEFT:
                            itemXPos += spriteVelocity;
                            break;
                    }
                    if (SpriteAtOrigin())
                    {  // if sprite makes it home
                        thisStateMachine.CeaseUse();
                        this.spriteChanged = false; //reset
                        this.currentItemSprite = null;
                    }
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
         * Changes the Sprite to display the backwards sprite.
         */
        public void ChangeSprite()
        {
            if (!this.spriteChanged)
            {
                this.currentItemSprite = itemSpriteFactory.getAnimatedSprite("Coming");
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

        public void Use(Bokoblin Owner)
        {
            if (!thisStateMachine.isItemInUse())
            {
                this.spriteChanged = false; //reset
                thisStateMachine.Use(); // sets usage in play
                this.itemXPos = Owner.xPosition();
                this.itemXOrigin = Owner.xPosition();
                this.itemYPos = Owner.yPosition();
                this.itemYOrigin = Owner.yPosition();
                this.itemMaxX = Owner.xPosition() + 50;
                this.itemMaxY = Owner.yPosition() + 50;
                this.itemMinX = Owner.xPosition() - 50;
                this.itemMinY = Owner.yPosition() - 50;
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("Going");
                // since the bow may go up or down.
                // all items start at the same position as link.
                // Set the the current item sprite based on link orientation (if needed).
                switch (Owner.getDirection())
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
                    case (int)Direction.LEFT:
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

        public IItemStateMachine ThisStateMachine()
        {
            return thisStateMachine;
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
            return itemRoomID;
        }
        public String type() { return "Enemy"; }
    }
}

