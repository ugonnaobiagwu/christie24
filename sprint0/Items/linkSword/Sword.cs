using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Items;
using sprint0.Sound.Ocarina;
using static sprint0.Globals;

namespace sprint0.LinkSword
{
	public class Sword : IItem, IGameObject
	{
		private ISprite currentItemSprite;
        private int itemRoomID;
        private int xPos;
        private int yPos;
        private int linkHeight;
        private int linkWidth;
        private float rotation;
        SpriteFactory currentSpriteFactory;
        SpriteFactory regularSwordFactory;
        SpriteFactory iceSwordFactory;
        SpriteFactory fireSwordFactory;
        private IItemStateMachine thisStateMachine;
        private Direction currentItemDirection;
        private bool isDrawn;
        public int totalSwordTicks = 25;
        public int currentSwordTicks;

        /*
         * Constant lifetime, will not get instantiated upon equipment like other items do.
         */
        public Sword(SpriteFactory regularSwordFactory, SpriteFactory iceSwordFactory, SpriteFactory fireSwordFactory)
		{
            currentItemDirection = Direction.Down;
            thisStateMachine = new ItemStateMachine();
            rotation = 0;
            currentSpriteFactory = regularSwordFactory;
            this.regularSwordFactory = regularSwordFactory;
            this.iceSwordFactory = iceSwordFactory;
            this.fireSwordFactory = fireSwordFactory;
            currentItemSprite = currentSpriteFactory.getAnimatedSprite("ItemDown");
            currentSwordTicks = 0;
            itemRoomID = 0;
            nullifyPosition();

        }

        private void nullifyPosition()
        {
            this.xPos = -10000;
            this.yPos = -10000;
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
                        currentItemSprite.Draw(spritebatch, xPos - linkWidth + 5, yPos - (linkHeight / 2) + 15, rotation);
                        break;
                    case Direction.Right:
                        currentItemSprite.Draw(spritebatch, xPos + linkWidth - 5, yPos - (linkHeight / 2) + 15, rotation);
                        break;
                    case Direction.Down:
                        currentItemSprite.Draw(spritebatch, xPos + (linkWidth / 6), yPos + linkHeight - 10, rotation);
                        break;
                    case Direction.Up:
                        currentItemSprite.Draw(spritebatch, xPos + (linkWidth / 10), yPos - linkHeight + 10, rotation);
                        break;
                }
            }
        }

        public int height()
        {
            return this.currentItemSprite.GetHeight() + 20;
        }

        public bool isDynamic()
        {
           return false;
        }

        public void Use(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            switch (Globals.LinkItemSystem.CurrentTunic)
            {
                case LinkTunic.ICE:
                    currentSpriteFactory = iceSwordFactory;
                    break;
                case LinkTunic.FIRE:
                    currentSpriteFactory = fireSwordFactory;
                    break;
                default:
                    currentSpriteFactory = regularSwordFactory;
                    break;
            }
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
                    currentItemSprite = currentSpriteFactory.getAnimatedSprite("ItemLeft");
                    rotation = 0;
                    break;
                case Direction.Right:
                    currentItemSprite = currentSpriteFactory.getAnimatedSprite("ItemRight");
                    rotation = 0;
                    break;
                case Direction.Up:
                    currentItemSprite = currentSpriteFactory.getAnimatedSprite("ItemUp");
                    rotation = (float)-67.5;
                    break;
                case Direction.Down:
                    currentItemSprite = currentSpriteFactory.getAnimatedSprite("ItemDown");
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
                //Globals.GameObjectManager.removeObject(this);
                nullifyPosition();

            }
            currentItemSprite.Update();
            currentSwordTicks++;

        }

        public int width()
        {
            return this.currentItemSprite.GetWidth() + 20;
        }

        public int xPosition()
        {
            switch (currentItemDirection)
            {
                // SET DRAW TO THE MUCKED UP X AND Y POS THAT THE SWORD MUST BE DRAWN AT.
                // HALFWAY THROUGH + ALL THE WAY TO THE EDGE OF THE SPRITE DEPENDING ON ORIENT.
                case Direction.Left:
                    return xPos - linkWidth + 5;
                case Direction.Right:
                    return xPos + linkWidth - 5;
                case Direction.Down:
                    return xPos + (linkWidth / 6);
                case Direction.Up:
                    return xPos + (linkWidth / 10);
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
                    return yPos - (linkHeight / 2) + 15;
                case Direction.Right:
                    return yPos - (linkHeight / 2) + 15;
                case Direction.Down:
                    return yPos + linkHeight - 10;
                case Direction.Up:
                    return yPos - linkHeight + 10;
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
        public String type() { return "Item"; }
    }
}

