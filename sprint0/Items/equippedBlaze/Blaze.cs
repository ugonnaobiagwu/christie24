using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Sound.Ocarina;
using static sprint0.Globals;

namespace sprint0.Items
{
    public class Blaze : IItem, IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        private int spriteVelocity = 1;
        private int maxFireTicks; // should use game time tbh.
        private int fireTicks;
        // needs these positions for sprite swapping.

        //direction stuff
        private int itemRoomID;
        SpriteFactory itemSpriteFactory;
        private ISprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;

        public Blaze(SpriteFactory factory)
        {
            itemSpriteFactory = factory;
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.Down;
            maxFireTicks = 120;
            fireTicks = 0;
            itemRoomID = 0;
            currentItemSprite = itemSpriteFactory.getAnimatedSprite("Blaze");
            nullifyPosition();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (thisStateMachine.isItemInUse() && this.currentItemSprite != null)
            {
                currentItemSprite.Draw(spriteBatch, itemXPos, itemYPos, 0);
            }
        }

        private void nullifyPosition()
        {
            this.itemXPos = -10000;
            this.itemYPos = -10000;
        }

        public void Update()
        {
            if (thisStateMachine.isItemInUse())
            {
                currentItemSprite.Update();

                // has the sprite reached it's final location?
                if ((itemXPos >= itemMaxX || itemYPos >= itemMaxY || itemXPos <= itemMinX || itemYPos <= itemMinY)) // sprite just reached its max
                {
                    if (fireTicks == maxFireTicks)
                    {
                        thisStateMachine.CeaseUse();
                        fireTicks = 0;
                        //Globals.GameObjectManager.removeObject(this);
                        nullifyPosition();

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
                fireTicks++;
                

            }

        }

        public void Use(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            if (!thisStateMachine.isItemInUse())
            {
                Ocarina.PlaySoundEffect(Ocarina.SoundEffects.BLAZE);
                thisStateMachine.Use(); // sets usage in play
                this.itemXPos = linkXPos;
                this.itemYPos = linkYPos;
                this.itemMaxX = linkXPos + 50;
                this.itemMaxY = linkYPos + 50;
                this.itemMinX = linkXPos - 50;
                this.itemMinY = linkYPos - 50;
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("Blaze");
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
            return this.itemRoomID;
        }
        public String type() { return "Item"; }

    }
}

