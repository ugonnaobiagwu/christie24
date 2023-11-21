using System;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.HUDs;

namespace sprint0.Items.groundItems
{
    public class GroundKey : IGroundItem
    {
        private ISprite currentItemSprite;
        public int xPos;
        public int yPos;
        public bool isPickedUp;
        private int roomID;

        // Does Level Loader like this signature?
        public GroundKey(SpriteFactory factory, int xPos, int yPos)
        {
            this.currentItemSprite = factory.getAnimatedSprite("GroundKey");
            this.xPos = xPos;
            this.yPos = yPos;
            isPickedUp = false;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (!isPickedUp)
            {
                this.currentItemSprite.Draw(spritebatch, this.xPos, this.yPos);
            }
        }

        public bool isDynamic()
        {
            return false;
        }

        public void Update()
        {
        }

        public int xPosition()
        {
            return this.xPos;
        }

        public int yPosition()
        {
            return this.yPos;
        }

        public void PickUp()
        {
            Inventory.CountKey();
            isPickedUp = true;
            Globals.GameObjectManager.removeObject(this);

        }

        public bool isUpdateable()
        {
            return false;
        }

        public bool isInPlay()
        {
            return !isPickedUp;
        }

        public bool isDrawable()
        {
            return true;
        }

        public void SetRoomId(int roomId)
        {
            this.roomID = roomId;
        }

        public int GetRoomId()
        {
            return this.roomID;
        }

        public int width()
        {
            return this.currentItemSprite.GetWidth();
        }

        public int height()
        {
            return this.currentItemSprite.GetHeight();
        }
        public String type() { return "Item"; }
    }
}

