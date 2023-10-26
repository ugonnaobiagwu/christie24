using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0.Items
{
    public class Bomb : IItem, IGameObject
    {
        private int itemXPos;
        private int itemYPos;
        private int maxBombTicks;
        private int bombTicks;
        // needs these positions for sprite swapping.

        //direction stuff
        private enum Direction { LEFT, RIGHT, UP, DOWN };
        private Texture2D bombTexture;
        private Texture2D explosionTexture;
        private IItemSprite currentItemSprite;
        public IItemStateMachine thisStateMachine;
        private bool spriteChanged;

        public Bomb(IList<Texture2D> itemSpriteSheet)
        {
            bombTexture = itemSpriteSheet[0];
            explosionTexture = itemSpriteSheet[1];
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
                this.currentItemSprite = new ExplosionSprite(explosionTexture, 1, 3);
                this.spriteChanged = true;
            }
            else if (this.currentItemSprite.finishedAnimationCycle() && this.spriteChanged)
            {
                thisStateMachine.CeaseUse();
                this.spriteChanged = false; //reset
                this.currentItemSprite = null;
                bombTicks = 0;
                
            }
        }

        public void Use(int linkDirection, int linkXPos, int linkYPos)
        {
            if (!thisStateMachine.isItemInUse())
            {
                this.spriteChanged = false; //reset
                thisStateMachine.Use(); // sets usage in play
                
                currentItemSprite = new BombSprite(bombTexture, 1, 1);
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

    }
}

