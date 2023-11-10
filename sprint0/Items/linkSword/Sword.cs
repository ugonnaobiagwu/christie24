using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Items;
using sprint0.Sound.Ocarina;
using static sprint0.Globals;

namespace sprint0.LinkSword
{

    /* 
     * NOTE TO SELF: 
     * 
     * 1. NEED GLOBAL CLASS FOR TIMERS STILL.
     * 2. NEED TO LOAD THE ITEM SYSTEM WITH THE RIGHT SPRITES STILL.
     * 3. NEED TO UPDATE ITEM SYSTEM INTERFACE
     * 4. NEED TO ENSURE ITEM SYSTEM KEEPS THE LINK SWORD OBJECT ALIVE
     * 5. NEED TO ENSURE GAME1 UPDATES AND DRAWS THE SWORD THROUGH THE 
     * ITEM SYSTEM.
     * 
     * 
     */
	public class Sword : IItem, IGameObject
	{
		private ISprite currentItemSprite;
        private int itemRoomID;
        private int xPos;
        private int yPos;
        private int linkHeight;
        private int linkWidth;
        private float rotation;
        SpriteFactory itemSpriteFactory;
        private IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool isDrawn;
        private int totalSwordTicks = 25;
        private int currentSwordTicks;

        /*
         * Constant lifetime, will not get instantiated upon equipment like other items do.
         */
        public Sword(SpriteFactory factory)
		{
            currentItemDirection = Direction.Down;
            thisStateMachine = new ItemStateMachine();
            rotation = 0;
            itemSpriteFactory = factory;
            currentItemSprite = itemSpriteFactory.getAnimatedSprite("ItemDown");
            currentSwordTicks = 0;
        }

        public void Draw(SpriteBatch spritebatch)
        {
          if (isDrawn)
            {
                switch (currentItemDirection)
                {
                    // SET DRAW TO THE MUCKED UP X AND Y POS THAT THE SWORD MUST BE DRAWN AT.
                    // HALFWAY THROUGH + ALL THE WAY TO THE EDGE OF THE SPRITE DEPENDING ON ORIENT.
                    case Direction.Left:
                        currentItemSprite.Draw(spritebatch, xPos - linkWidth, yPos - (linkHeight / 2), rotation);
                        break;
                    case Direction.Right:
                        currentItemSprite.Draw(spritebatch, xPos + linkWidth, yPos - (linkHeight / 2), rotation);
                        break;
                    case Direction.Down:
                        currentItemSprite.Draw(spritebatch, xPos + (linkWidth / 6), yPos, rotation);
                        break;
                    case Direction.Up:
                        currentItemSprite.Draw(spritebatch, xPos + (linkWidth / 2), yPos - linkHeight, rotation);
                        break;
                }
            }
        }

        public int height()
        {
            return this.currentItemSprite.GetHeight();
        }

        public bool isDynamic()
        {
           return false;
        }

        public void Use(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            currentSwordTicks = 0;
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.SWORD_SLASH);
            thisStateMachine.Use();
            this.xPos = linkXPos;
            this.yPos = linkYPos;
            this.linkHeight = linkHeight;
            this.linkWidth = linkWidth;
            this.currentItemDirection = (Direction)linkDirection;
            switch (currentItemDirection)
            {
                case Direction.Left:
                    currentItemSprite = itemSpriteFactory.getAnimatedSprite("ItemLeft");
                    rotation = 0;
                    break;
                case Direction.Right:
                    currentItemSprite = itemSpriteFactory.getAnimatedSprite("ItemRight");
                    rotation = 0;
                    break;
                case Direction.Up:
                    currentItemSprite = itemSpriteFactory.getAnimatedSprite("ItemUp");
                    rotation = (float)-67.5;
                    break;
                case Direction.Down:
                    currentItemSprite = itemSpriteFactory.getAnimatedSprite("ItemDown");
                    rotation = (float)67.5;
                    break;
            }
            isDrawn = true;
        }

        public void Update()
        {
          /* if the amount of time thats passed is equal to or exceeds the max amount of time for a sword to be drawn, 
           * set isDrawn to false.
           */
          //if (currentItemSprite.GetCurrentFrame() > currentItemSprite.GetTotalFrames()) {
          if (currentSwordTicks >= totalSwordTicks) { 
                this.isDrawn = false;
                this.thisStateMachine.CeaseUse();
                
            }
            currentItemSprite.Update();
            currentSwordTicks++;

        }

        public int width()
        {
            return this.currentItemSprite.GetWidth();
        }

        public int xPosition()
        {
            switch (currentItemDirection)
            {
                // SET DRAW TO THE MUCKED UP X AND Y POS THAT THE SWORD MUST BE DRAWN AT.
                // HALFWAY THROUGH + ALL THE WAY TO THE EDGE OF THE SPRITE DEPENDING ON ORIENT.
                case Direction.Left:
                    return xPos - linkWidth;
                case Direction.Right:
                    return xPos + linkWidth;
                case Direction.Down:
                    return xPos + (linkWidth / 2);
                case Direction.Up:
                    return xPos + (linkWidth / 2);
                default:
                    return xPos;
            }
        }

        public int yPosition()
        {
            switch (currentItemDirection)
            {
                // SET DRAW TO THE MUCKED UP X AND Y POS THAT THE SWORD MUST BE DRAWN AT.
                // HALFWAY THROUGH + ALL THE WAY TO THE EDGE OF THE SPRITE DEPENDING ON ORIENT.
                case Direction.Left:
                    return yPos - (linkHeight / 2);
                case Direction.Right:
                    return yPos - (linkHeight / 2);
                case Direction.Down:
                    return yPos + linkHeight;
                case Direction.Up:
                    return yPos - linkHeight;
                default:
                    return yPos;
            }
        }

        public bool isInPlay()
        {
            return isDrawn;
        }

        public bool isUpdateable()
        {
            return true;
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

