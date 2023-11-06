using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
namespace sprint0.Items
{
    public class Bomb : IItem, IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        public int maxBombTicks;
        public int bombTicks;
        // needs these positions for sprite swapping.

        //direction stuff
        private int itemRoomID;
        private SpriteFactory explosionSpriteFactory;
        private enum Direction { LEFT, RIGHT, UP, DOWN };
        private ISprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private SpriteFactory itemSpriteFactory; 
        private bool spriteChanged;

        public Bomb(SpriteFactory factory, SpriteFactory explosionFactory)
        {
            itemSpriteFactory = factory;
            explosionSpriteFactory = explosionFactory;
            thisStateMachine = new ItemStateMachine();
            maxBombTicks = 60;
            bombTicks = 0;
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
                // IF YOU CHANGE ME, TAKE A LOOK AT THE BLAZE CLASS, WILL YA?
                if (bombTicks == maxBombTicks)
                {
                    ChangeSprite();

                }
                else
                {
                    bombTicks++;
                }
                if (this.currentItemSprite != null)
                {
                    this.currentItemSprite.Update();
                }

            }

        }

        /*
         * Changes the Sprite to display the explosion animation.
         */
        public void ChangeSprite()
        {
            if (!this.spriteChanged)
            {
                this.currentItemSprite = explosionSpriteFactory.getAnimatedSprite("BombExplosion");
                this.spriteChanged = true;
            }
            else if (this.finishedAnimationCycle() && this.spriteChanged)
            {
                thisStateMachine.CeaseUse();
                this.spriteChanged = false; //reset
                this.currentItemSprite = null;
                bombTicks = 0;
                
            }
        }

        public void Use(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            if (!thisStateMachine.isItemInUse())
            {
                this.spriteChanged = false; //reset
                thisStateMachine.Use(); // sets usage in play
                
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("Bomb");
                // since the bow may go up or down.
                // all items start at the same position as link.
                // Set the the current item sprite based on link orientation (if needed).
                switch (linkDirection)
                {
                    case (int)Direction.RIGHT:
                        this.itemXPos = linkXPos + 15;
                        this.itemYPos = linkYPos;
                        break;
                    case (int)Direction.UP:
                        this.itemYPos = linkYPos - 15;
                        this.itemXPos = linkXPos;
                        break;
                    case (int)Direction.DOWN:
                        this.itemYPos = linkYPos + 15;
                        this.itemXPos = linkXPos;
                        break;
                    case (int)Direction.LEFT:
                        this.itemXPos = linkXPos + 15;
                        this.itemYPos = linkYPos;
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
            if (spriteChanged) // change hitbox if in explosion state 
            {
                return this.currentItemSprite.GetWidth() + 15;
            } else
            {
                return this.currentItemSprite.GetWidth();
            }
        }

        public int height()
        {
            if (spriteChanged) // change hitbox if in explosion state 
            {
                return this.currentItemSprite.GetHeight() + 15;
            }
            else
            {
                return this.currentItemSprite.GetHeight();
            }
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
    }
}

