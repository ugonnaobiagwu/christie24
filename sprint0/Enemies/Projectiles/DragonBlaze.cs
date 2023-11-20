using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Enemies;

namespace sprint0.Items
{
    public class DragonBlaze : IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        private int spriteVelocity = 1;
        private int ProjectileID;
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

        public DragonBlaze(SpriteFactory factory, int projectileID)
        {
            itemSpriteFactory = factory;
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.DOWN;
            ProjectileID = projectileID;
            //maxFireTicks = 120;
            //fireTicks = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (thisStateMachine.isItemInUse() && this.currentItemSprite != null)
            {
                currentItemSprite.Draw(spriteBatch, itemXPos, itemYPos, 0.0f);
            }
        }

        public void Update()
        {
            if (thisStateMachine.isItemInUse())
            {

                // has the sprite reached it's final location?
                if ((itemXPos >= itemMaxX || itemYPos >= itemMaxY || itemXPos <= itemMinX || itemYPos <= itemMinY)) // sprite just reached its max
                {
                    thisStateMachine.CeaseUse();
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
                    // Fireballs can move in all 3 directions
                    switch (ProjectileID) 
                    {
                        case 0:
                            itemYPos += spriteVelocity;
                            itemXPos -= spriteVelocity;
                            break;
                        case 1:
                            itemXPos -= spriteVelocity;
                            break;
                        case 2:
                            itemXPos -= spriteVelocity;
                            itemYPos -= spriteVelocity;
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

        public void Use(Dragon Owner)
        {
            if (!thisStateMachine.isItemInUse())
            {
                thisStateMachine.Use(); // sets usage in play
                this.itemXPos = Owner.xPosition();
                this.itemYPos = Owner.yPosition();
                this.itemMaxX = Owner.xPosition() + 200;
                this.itemMaxY = Owner.yPosition() + 200;
                this.itemMinX = Owner.xPosition() - 200;
                this.itemMinY = Owner.yPosition() - 200;
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("Blaze");
                // since the bow may go up or down.
                // all items start at the same position as link.
                // Set the the current item sprite based on link orientation (if needed).
                currentItemDirection = Direction.LEFT;
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

