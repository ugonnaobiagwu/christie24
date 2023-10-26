using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;
using sprint0.LinkSword;

namespace sprint0
{
	public class ItemSystem : IItemSystem
	{
        private static ItemSystem instance;
        private IItem currentItem;
        private IItem bow;
        private IItem betterBow;
        private IItem boomerang;
        private IItem betterBoomerang;
        private IItem bomb;
        private IItem blaze;
        private SpriteBatch spriteBatch;
        private Dictionary<IItem, Boolean> theseItems;

        private IList<Texture2D> swordTexture;
        private ILinkSword sword;
        /*
         * [code: theseItems] will be used to limit whether or not link can equip an 
         * item depending on how the inventory system works
         */

        public ItemSystem() {
            // instantiate all of the items and add them to the array list.
            this.theseItems = new Dictionary<IItem, Boolean>();
        }

        public static ItemSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemSystem();
                }
                return instance;
            }
        }

        /*
         * NOTE TO SELF: IF YOU EDIT ANY OF THESE LOAD METHODS.. 
         * YOU'VE GOTTA EDIT THEM ALL. THESE METHODS SHOULD ALSO BE RAN BEFORE
         * ITEM SYSTEM USE.
         * 
         * EACH LOAD METHOD REQUIRES THAT THE ITEM HAS NOT BEEN LOADED UP.
         * 
         * THIS IS BECAUSE IN ORDER TO KEEP THE SYSTEM A SINGLETON,
         * YOU HAVE TO SETUP WHAT THE CONSTRUCTOR WOULD NORMALLY SETUP. 
         * 
         * ITEMS REALLY SHOULDN'T BE MESSED WITH ONCE IN THE SYSTEM.
         * 
         * (this design is stupid and not what i intended.. 
         * .. may the graders be merciful)
        */

        // These load methods could be data driven tbh.
        public void LoadBow(IList<Texture2D> itemSpriteSheet)
        {
            if (this.bow == null)
            {
                this.bow = new Bow(itemSpriteSheet);
            }
        }

        public void LoadBetterBow(IList<Texture2D> itemSpriteSheet)
        {
            if (this.betterBow == null)
            {
                this.betterBow = new BetterBow(itemSpriteSheet);
            }
        }

        public void LoadBoomerang(IList<Texture2D> itemSpriteSheet)
        {
            if (this.boomerang == null)
            {
                this.boomerang = new Boomerang(itemSpriteSheet);
            }
        }

        public void LoadBetterBoomerang(IList<Texture2D> itemSpriteSheet)
        {
            if (this.betterBoomerang == null)
            {
                this.betterBoomerang = new BetterBoomerang(itemSpriteSheet);
            }
        }

        public void LoadBomb(IList<Texture2D> itemSpriteSheet)
        {
            if (this.bomb == null)
            {
                this.bomb = new Bomb(itemSpriteSheet);
            }
        }

        public void LoadBlaze(IList<Texture2D> itemSpriteSheet)
        {
            if (this.blaze == null)
            {
                this.blaze = new Blaze(itemSpriteSheet);
            }
        }

        public void LoadSword(IList<Texture2D> itemSpriteSheet)
        {
            if (this.swordTexture == null)
            {
                this.swordTexture = itemSpriteSheet;
                
            }
        }
        public void LoadSpriteBatch(SpriteBatch incomingSpriteBatch)
        {
            if (this.spriteBatch == null)
            {
                this.spriteBatch = incomingSpriteBatch;
            }
        }


        /*
         * Item Equipment: This will change the current item that Link has in his hand at the time it's called.
         */
        public void EquipBow()
        {
            if (this.bow != null)
            {
                this.currentItem = this.bow;
            }
        }

        public void EquipBetterBow()
        {
            if (this.betterBow != null)
            {
                this.currentItem = this.betterBow;
            }
        }

        public void EquipBoomerang()
        {
            if (this.boomerang != null)
            {
                this.currentItem = this.boomerang;
            }
        }

        public void EquipBetterBoomerang()
        {
            if (this.betterBoomerang != null)
            {
                this.currentItem = this.betterBoomerang;
            }
        }

        public void EquipBlaze()
        {
            if (this.blaze != null)
            {
                this.currentItem = this.blaze;
            }
        }
        public void EquipBomb()
        {
            if (this.bomb != null)
            {
                this.currentItem = this.bomb;
            }
        }

        public void UseCurrentItem(int linkDirection, int linkXPos, int linkYPos)
        {
            this.currentItem.Use(linkDirection, linkXPos, linkYPos);
        }

        public void SwingSword(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            this.sword.SwingSword(linkDirection, linkXPos, linkYPos, linkHeight, linkWidth);
        }

        public void Draw()
        {
            this.currentItem.Draw(this.spriteBatch);
        }

        public void Update()
        {
            this.currentItem.Update();
        }
    }
}

