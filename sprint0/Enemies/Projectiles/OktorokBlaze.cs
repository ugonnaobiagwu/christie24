using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Enemies;

namespace sprint0.Items
{
    public class OktorokBlaze : IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        private int spriteVelocity = 1;
        //private int maxFireTicks; // should use game time tbh.
        //private int fireTicks;
        // needs these positions for sprite swapping.

        //direction stuff
        private int itemRoomID;
        private enum Direction { LEFT, RIGHT, UP, DOWN };
        SpriteFactory itemSpriteFactory;
        private ISprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;

        public OktorokBlaze(SpriteFactory factory)
        {
            itemSpriteFactory = factory;
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.DOWN;
            //maxFireTicks = 120;
            //fireTicks = 0;
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
                if ((itemXPos >= itemMaxX || itemYPos >= itemMaxY || itemXPos <= itemMinX || itemYPos <= itemMinY)) // sprite just reached its max
                {
                    /*
                    if (fireTicks == maxFireTicks)
                    {
                        thisStateMachine.CeaseUse();
                        fireTicks = 0;
                    }
                    */
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
                //fireTicks++;
                if (this.currentItemSprite != null)
                {
                    this.currentItemSprite.Update();
                }

            }

        }

        public void Use(IOktorok Owner)
        {
            if (!thisStateMachine.isItemInUse())
            {
                thisStateMachine.Use(); // sets usage in play
                this.itemXPos = Owner.xPosition();
                this.itemYPos = Owner.yPosition();
                this.itemMaxX = Owner.xPosition() + 50;
                this.itemMaxY = Owner.yPosition() + 50;
                this.itemMinX = Owner.xPosition() - 50;
                this.itemMinY = Owner.yPosition() - 50;
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("Blaze");
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
            return false;
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

