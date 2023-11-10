using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Sound.Ocarina;
using static sprint0.Globals;

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
        private int itemRoomID;
        // needs these positions for sprite swapping.

        //direction stuff
        private SpriteFactory itemSpriteFactory;
        private ISprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool spriteChanged;

        public BetterBoomerang(SpriteFactory factory)
        {
            itemSpriteFactory = factory;
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.Down;
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
                if ((itemXPos >= itemMaxX || itemYPos >= itemMaxY || itemXPos <= itemMinX || itemYPos <= itemMinY) && (!this.spriteChanged)) // sprite just reached its max
                {
                    ChangeSprite();
                }
                else if (this.spriteChanged) // sprite has reached its max and is on its way home
                {
                    switch (this.currentItemDirection)
                    {
                        case Direction.Right:
                            itemXPos -= spriteVelocity;
                            break;
                        case Direction.Up:
                            itemYPos += spriteVelocity;
                            break;
                        case Direction.Down:
                            itemYPos -= spriteVelocity;
                            break;
                        case Direction.Left:
                            itemXPos += spriteVelocity;
                            break;
                    }
                    if (SpriteAtOrigin())
                    {  // if sprite makes it home
                        thisStateMachine.CeaseUse();
                        this.spriteChanged = false; //reset
                        this.currentItemSprite = null;
                        Ocarina.StopSoundEffect(Ocarina.SoundEffects.BOOMERANG_LAUNCH);
                    }
                }
                else
                {
                    // update the x and y position of the item positions based on
                    // the adventures the sprite has taken.
                    // switch case bad i know, i know.
                    switch (this.currentItemDirection)
                    {
                        case Direction.Right:
                            itemXPos += spriteVelocity;
                            break;
                        case Direction.Up:
                            itemYPos -= spriteVelocity;
                            break;
                        case Direction.Down:
                            itemYPos += spriteVelocity;
                            break;
                        case Direction.Left:
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

        public void Use(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            if (!thisStateMachine.isItemInUse())
            {
                Ocarina.PlaySoundEffect(Ocarina.SoundEffects.BOOMERANG_LAUNCH);
                this.spriteChanged = false; //reset
                thisStateMachine.Use(); // sets usage in play
                this.itemXPos = linkXPos;
                this.itemXOrigin = linkXPos;
                this.itemYPos = linkYPos;
                this.itemYOrigin = linkYPos;
                this.itemMaxX = linkXPos + 200;
                this.itemMaxY = linkYPos + 200;
                this.itemMinX = linkXPos - 200;
                this.itemMinY = linkYPos - 200;
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("Going");
                // since the bow may go up or down.
                // all items start at the same position as link.
                // Set the the current item sprite based on link orientation (if needed).
                switch (linkDirection)
                {
                    case Direction.Right:
                        currentItemDirection = Direction.Right;
                        break;
                    case Direction.Up:
                        currentItemDirection = Direction.Up;
                        break;
                    case Direction.Down:
                        currentItemDirection = Direction.Down;
                        break;
                    case Direction.Left:
                        currentItemDirection = Direction.Left;
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
    }
}

