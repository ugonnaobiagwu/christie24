using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
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
        private int RoomId;
        private int spriteVelocity = 1;
        private int maxFireTicks; // should use game time tbh.
        private int fireTicks;
        // needs these positions for sprite swapping.

        //direction stuff
        private enum Direction { LEFT, RIGHT, UP, DOWN };
        private Texture2D texture;
        private IItemSprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;

        public Blaze(IList<Texture2D> itemSpriteSheet)
        {
            texture = itemSpriteSheet[0];
            thisStateMachine = new ItemStateMachine();
            currentItemDirection = Direction.DOWN;
            maxFireTicks = 120;
            fireTicks = 0;
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
                    if (fireTicks == maxFireTicks)
                    {
                        thisStateMachine.CeaseUse();
                        fireTicks = 0;
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
                fireTicks++;
                if (this.currentItemSprite != null)
                {
                    this.currentItemSprite.Update();
                }

            }

        }

        public void Use(int linkDirection, int linkXPos, int linkYPos)
        {
            if (!thisStateMachine.isItemInUse())
            {
                thisStateMachine.Use(); // sets usage in play
                this.itemXPos = linkXPos;
                this.itemYPos = linkYPos;
                this.itemMaxX = linkXPos + 50;
                this.itemMaxY = linkYPos + 50;
                this.itemMinX = linkXPos - 50;
                this.itemMinY = linkYPos - 50;
                currentItemSprite = new BlazeSprite(texture, 1, 2);
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
            return this.currentItemSprite.itemWidth();
        }

        public int height()
        {
            return this.currentItemSprite.itemHeight();
        }

        public bool isDynamic()
        {
            return false;
        }

        public bool isUpdateable(){ return true; }
        public bool isInPlay() { return true; }
        public bool isDrawable() { return true;}
        public void SetRoomId(int roomId) { RoomId = roomId; }
        public int GetRoomId() { return RoomId; }
    }
}

