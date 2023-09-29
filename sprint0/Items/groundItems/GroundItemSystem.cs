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
        private SpriteBatch spriteBatch;
        private int xPos;
        private int yPos;

		public GroundItemSystem(SpriteBatch spritebatch, int xPos, int yPos)
		{
            theseGroundItems = new List<ISprite>();
            this.spriteBatch = spritebatch;
            this.xPos = xPos;
            this.yPos = yPos;
        }
        public void LoadFairy(Texture2D itemSpriteSheet)
        {
            this.fairy = new GroundAnimatedSprite(itemSpriteSheet, 1, 2);
            this.displayedSprite = this.fairy;
            this.theseGroundItems.Add(this.fairy);
        }
        public void LoadBlaze(Texture2D itemSpriteSheet)
        {
            this.blaze = new GroundAnimatedSprite(itemSpriteSheet, 1, 2);
            this.theseGroundItems.Add(this.blaze);
            this.displayedSprite = this.blaze;
        }
        public void LoadHeart(Texture2D itemSpriteSheet)
        {
            this.heart = new GroundAnimatedSprite(itemSpriteSheet, 1, 2);
            this.theseGroundItems.Add(this.heart);
            this.displayedSprite = this.heart;
        }
        public void LoadShimmeringRupee(Texture2D itemSpriteSheet)
        {
            this.shimmeringRupee = new GroundAnimatedSprite(itemSpriteSheet, 1, 2);
            this.displayedSprite = this.shimmeringRupee;
            this.theseGroundItems.Add(this.shimmeringRupee);
        }
        public void LoadTriforcePiece(Texture2D itemSpriteSheet)
        {
            this.triforcePiece = new GroundAnimatedSprite(itemSpriteSheet, 1, 2);
            this.displayedSprite = this.triforcePiece;
            this.theseGroundItems.Add(this.triforcePiece);
        }
        public void LoadRupee(Texture2D itemSpriteSheet)
        {
            this.rupee = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.rupee;
            this.theseGroundItems.Add(this.rupee);

        }
        public void LoadPage(Texture2D itemSpriteSheet)
        {
            this.page = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.page;
            this.theseGroundItems.Add(this.page);
        }
        public void LoadKey(Texture2D itemSpriteSheet)
        {
            this.key = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.key;
            this.theseGroundItems.Add(this.key);
        }
        public void LoadBigHeart(Texture2D itemSpriteSheet)
        {
            this.bigHeart = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.bigHeart;
            this.theseGroundItems.Add(this.bigHeart);
        }
        
        public void LoadCompass(Texture2D itemSpriteSheet)
        {
            this.compass = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.compass;
            this.theseGroundItems.Add(this.compass);
        }
        public void LoadClock(Texture2D itemSpriteSheet)
        {
            this.clock = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.clock;
            this.theseGroundItems.Add(this.clock);
        }
        public void LoadBow(Texture2D itemSpriteSheet)
        {
            this.bow = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.bow;
            this.theseGroundItems.Add(this.bow);
        }
        public void LoadBoomerang(Texture2D itemSpriteSheet)
        {
            this.boomerang = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.boomerang;
            this.theseGroundItems.Add(this.boomerang);
        }
        public void LoadBomb(Texture2D itemSpriteSheet)
        {
            this.bomb = new GroundNonAnimatedSprite(itemSpriteSheet, 1, 1);
            this.displayedSprite = this.bomb;
            this.theseGroundItems.Add(this.bomb);
        }

        public void Draw()
        {
            this.displayedSprite.Draw(this.spriteBatch, this.xPos, this.yPos);
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
            this.displayedSprite.Update();
        }
    }
}

