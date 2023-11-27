using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Sound.Ocarina;
using static sprint0.Globals;

namespace sprint0.Items
{
    public class NullItem : IItem, IGameObject
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

        public NullItem()
        {
            itemXPos = 0;
            itemYPos = 0;
            itemRoomID = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update()
        {
            

        }

        public void Use(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {

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
            return 0;
        }

        public int height()
        {
            return 0;
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

