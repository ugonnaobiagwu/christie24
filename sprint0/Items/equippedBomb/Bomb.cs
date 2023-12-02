using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.HUDs;
using sprint0.Sound.Ocarina;
using static sprint0.Globals;

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
            itemRoomID = 0;
            currentItemSprite = itemSpriteFactory.getAnimatedSprite("Bomb");
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
                // IF YOU CHANGE ME, TAKE A LOOK AT THE BLAZE CLASS, WILL YA?
                if (bombTicks == maxBombTicks)
                {
                    ChangeSprite();

                }
                else
                {
                    bombTicks++;
                }
                
                    this.currentItemSprite.Update();
                

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
                Ocarina.PlaySoundEffect(Ocarina.SoundEffects.BOMB_EXPLODE);
            }
            else if (this.finishedAnimationCycle() && this.spriteChanged)
            {
                thisStateMachine.CeaseUse();
                this.spriteChanged = false; //reset
                bombTicks = 0;
                //Globals.GameObjectManager.removeObject(this);
                nullifyPosition();


            }
        }

        public void Use(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            if (!thisStateMachine.isItemInUse() && Inventory.items[Inventory.ItemTypes.BOMB] > 0)
            {
                Inventory.LoseBomb();
                Ocarina.PlaySoundEffect(Ocarina.SoundEffects.BOMB_DROP);
                this.spriteChanged = false; //reset
                thisStateMachine.Use(); // sets usage in play
                
                currentItemSprite = itemSpriteFactory.getAnimatedSprite("Bomb");
                // since the bow may go up or down.
                // all items start at the same position as link.
                // Set the the current item sprite based on link orientation (if needed).
                switch (linkDirection)
                {
                    case Direction.Right:
                        this.itemXPos = linkXPos + 35;
                        this.itemYPos = linkYPos;
                        break;
                    case Direction.Up:
                        this.itemYPos = linkYPos - 35;
                        this.itemXPos = linkXPos;
                        break;
                    case Direction.Down:
                        this.itemYPos = linkYPos + 35;
                        this.itemXPos = linkXPos;
                        break;
                    case Direction.Left:
                        this.itemXPos = linkXPos - 35;
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
                return this.currentItemSprite.GetWidth() + 20;
            } else
            {
                return this.currentItemSprite.GetWidth();
            }
        }

        public int height()
        {
            if (spriteChanged) // change hitbox if in explosion state 
            {
                return this.currentItemSprite.GetHeight() + 20;
            }
            else
            {
                return this.currentItemSprite.GetHeight();
            }
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
        private bool finishedAnimationCycle()
        {
            if (currentItemSprite.GetCurrentFrame() == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public GameObjectType type { get { return GameObjectType.ITEM; } }
    }
}

