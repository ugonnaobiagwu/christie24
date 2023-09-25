using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items.groundItems

    // this code REEKS. i know.
{
	public class GroundItemSystem : IGroundItemSystem
	{
        private IList<ISprite> theseGroundItems;
        private int currentGroundItemIndex;
        private ISprite blaze;
        private ISprite heart;
        private ISprite rupee;
        private ISprite shimmeringRupee;
        private ISprite triforcePiece;
        private ISprite page;
        private ISprite key;
        private ISprite bigHeart;
        private ISprite fairy;
        private ISprite compass;
        private ISprite clock;
        private ISprite bow;
        private ISprite boomerang;
        private ISprite bomb;
        private ISprite displayedSprite;
        private int xPos;
        private int yPos;

		public GroundItemSystem(int xPos, int yPos)
		{
            theseGroundItems = new List<ISprite>();
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void LoadBlaze(Texture2D itemSpriteSheet)
        {
            this.blaze = new GroundAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.blaze;
        }
        public void LoadHeart(Texture2D itemSpriteSheet)
        {
            this.heart = new GroundAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.heart;
        }
        public void LoadShimmeringRupee(Texture2D itemSpriteSheet)
        {
            this.shimmeringRupee = new GroundAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.shimmeringRupee;
        }
        public void LoadTriforcePiece(Texture2D itemSpriteSheet)
        {
            this.triforcePiece = new GroundAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.triforcePiece;
        }
        public void LoadRupee(Texture2D itemSpriteSheet)
        {
            this.rupee = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.rupee;

        }
        public void LoadPage(Texture2D itemSpriteSheet)
        {
            this.page = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.page;
        }
        public void LoadKey(Texture2D itemSpriteSheet)
        {
            this.key = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.key;
        }
        public void LoadBigHeart(Texture2D itemSpriteSheet)
        {
            this.bigHeart = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.bigHeart;
        }
        public void LoadFairy(Texture2D itemSpriteSheet)
        {
            this.fairy = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.fairy;
        }
        public void LoadCompass(Texture2D itemSpriteSheet)
        {
            this.compass = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.compass;
        }
        public void LoadClock(Texture2D itemSpriteSheet)
        {
            this.clock = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.clock;
        }
        public void LoadBow(Texture2D itemSpriteSheet)
        {
            this.bow = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.bow;
        }
        public void LoadBoomerang(Texture2D itemSpriteSheet)
        {
            this.boomerang = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.boomerang;
        }
        public void LoadBomb(Texture2D itemSpriteSheet)
        {
            this.bomb = new GroundNonAnimatedSprite(itemSpriteSheet, this.xPos, this.yPos);
            this.displayedSprite = this.bomb;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        /*
         *  Requires that theseItems is not empty 
         *  (load your items into the system!)
         */
        public void NextItem()
        {
            if (this.theseGroundItems.Count > 0)
            {
                currentGroundItemIndex++;
                if (this.currentGroundItemIndex < this.theseGroundItems.Count)
                {
                    this.displayedSprite = this.theseGroundItems[this.currentGroundItemIndex];
                }
                else // equal to or greater than count of items.
                {
                    this.currentGroundItemIndex = 0; // from the top!
                    this.displayedSprite = this.theseGroundItems[this.currentGroundItemIndex];
                }
            }
        }

        /*
         *  Requires that theseItems is not empty 
         *  (load your items into the system!)
         */
        public void PreviousItem()
        {
            if (this.theseGroundItems.Count > 0)
            {
                currentGroundItemIndex--;
                if (this.currentGroundItemIndex > 0)
                {
                    this.displayedSprite = this.theseGroundItems[this.currentGroundItemIndex];
                }
                else // index is less than the start of the list.
                {
                    this.currentGroundItemIndex = this.theseGroundItems.Count - 1; // from the top!
                    this.displayedSprite = this.theseGroundItems[this.currentGroundItemIndex];
                }
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

