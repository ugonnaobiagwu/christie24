using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;
using sprint0.AnimatedSpriteFactory;
using sprint0.Sound.Ocarina;
using static sprint0.Globals;

namespace sprint0.Items
{
    public class Bow : IItem, IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        private float rotation;
        private int spriteVelocity = 1;
        // needs these positions for sprite swapping.

        //direction stuff
        private int itemRoomID;
        private SpriteFactory itemSpriteFactory;
        private SpriteFactory despawnSpriteFactory;
        private ISprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool spriteChanged;

        public Bow(SpriteFactory factory, SpriteFactory despawnFactory)
        {
            itemSpriteFactory = factory;
            despawnSpriteFactory = despawnFactory;
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.Down;
            spriteChanged = false;
            rotation = 0;
            itemRoomID = 0;


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

        public void Use(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {

            if (!thisStateMachine.isItemInUse())
            {
                Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ARROW_LAUNCH);
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
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("Bow");
                switch (linkDirection)
                {
                    case Direction.Right:
                        rotation = (float)67.5;
                        currentItemDirection = Direction.Right;
                        break;
                    case Direction.Up:
                        rotation = (float)135;
                        currentItemDirection = Direction.Up;
                        break;
                    case Direction.Down:
                        rotation = 0;
                        currentItemDirection = Direction.Down;
                        break;
                    case Direction.Left:
                        rotation = (float)-67.5;
                        currentItemDirection = Direction.Left;
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
        public String type() { return "Item"; }
    }
}


