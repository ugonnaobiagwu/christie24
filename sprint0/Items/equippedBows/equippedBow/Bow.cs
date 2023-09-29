using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0.Items
{
	public class Bow : IItem
	{
        private int itemXPos;
        private int itemYPos;
        private int itemMaxX;
        private int itemMaxY;
        private int itemMinX;
        private int itemMinY;
        // needs these positions for sprite swapping.
        private int linkYPos;
        private int linkXPos;
        // needs these positions for where to start the item.
        private Texture2D upBowTexture;
        private Texture2D downBowTexture;
        private Texture2D leftBowTexture;
        private Texture2D rightBowTexture;
        private Texture2D bowDespawnTextures;
        private IItemSprite currentItemSprite;
        private IItemStateMachine thisBowStateMachine;

        public Bow(IList<Texture2D> itemSpriteSheet)
		{
            upBowTexture = itemSpriteSheet[0];
            downBowTexture = itemSpriteSheet[1];
            leftBowTexture = itemSpriteSheet[2];
            rightBowTexture = itemSpriteSheet[3];
            bowDespawnTextures = itemSpriteSheet[4];
            thisBowStateMachine = new BowStateMachine();

		}

        public void Draw(SpriteBatch spriteBatch)
        {
            if (thisBowStateMachine.isItemInUse())
            {
                currentItemSprite.Draw(spriteBatch, linkXPos, linkYPos);
            }
        }

        public void Update()
        {
            if (thisBowStateMachine.isItemInUse())
            {
                // update the x and y position of the item positions based on
                // the adventures the sprite has taken.
                this.itemXPos = this.currentItemSprite.currentItemXPos();
                this.itemYPos = this.currentItemSprite.currentItemYPos();

                // has the sprite reached it's final location?
                if (itemXPos >= itemMaxX || itemYPos >= itemMaxY || itemXPos <= itemMinX || itemYPos <= itemMinY)  
                {
                    ChangeSprite();
                }

                if (this.currentItemSprite.finishedAnimationCycle())
                {
                    thisBowStateMachine.CeaseUse();
                }

            }

        }

        /*
         * Changes the Sprite to display the impact animation.
         */
        public void ChangeSprite()
        {
            this.currentItemSprite = new BowDespawnSprite(bowDespawnTextures, 1, 1);
        }

        public void Use(/* incoming link's orientation */)
        {
            if (!thisBowStateMachine.isItemInUse())
            {
                thisBowStateMachine.Use(); // sets usage in play
                // this.linkYPos = Link's X Position
                // this.linkXPos = Link's Y Position
                this.itemXPos = this.linkXPos;
                this.itemYPos = this.linkXPos;
                this.itemMaxX = this.linkXPos + 100;
                this.itemMaxY = this.linkYPos + 100;
                this.itemMinX = this.linkXPos - 100;
                this.itemMinY = this.linkYPos - 100;
                // since the bow may go up or down.
                // all items start at the same position as link.
                // Set the the current item sprite based on link orientation (if needed).
            }
        }
    }
}

