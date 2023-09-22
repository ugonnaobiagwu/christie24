using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.Items;

namespace sprint0
{
	public class ItemSystem : IItemSystem
	{
        private static ItemSystem instance;
        private IItem currentItem;
        private int currentItemIndex;
        private IItem bow;
        private IItem betterBow;
        private IItem boomerang;
        private IItem betterBoomerang;
        private IItem bomb;
        private IItem blaze;
        private IList<IItem> theseItems;

        private ItemSystem() {
            // instantiate all of the items and add them to the array list.
            this.currentItemIndex = 0;
            this.theseItems = new List<IItem>();
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
         * YOU HAVE TO SETUP THE ITEMS GOING INTO IT.
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
                this.theseItems.Add(this.bow);
                this.currentItem = this.theseItems[this.currentItemIndex];
            }
        }

        public void LoadBetterBow(IList<Texture2D> itemSpriteSheet)
        {
            if (this.betterBow == null)
            {
                this.betterBow = new BetterBow(itemSpriteSheet);
                this.theseItems.Add(this.betterBow);
                this.currentItem = this.theseItems[this.currentItemIndex];
            }
        }

        public void LoadBoomerang(IList<Texture2D> itemSpriteSheet)
        {
            if (this.boomerang == null)
            {
                this.boomerang = new Boomerang(itemSpriteSheet);
                this.theseItems.Add(this.boomerang);
                this.currentItem = this.theseItems[this.currentItemIndex];
            }
        }

        public void LoadBetterBoomerang(IList<Texture2D> itemSpriteSheet)
        {
            if (this.betterBoomerang == null)
            {
                this.betterBoomerang = new BetterBoomerang(itemSpriteSheet);
                this.theseItems.Add(this.betterBoomerang);
                this.currentItem = this.theseItems[this.currentItemIndex];
            }
        }

        public void LoadBomb(IList<Texture2D> itemSpriteSheet)
        {
            if (this.bomb == null)
            {
                this.bomb = new Bomb(itemSpriteSheet);
                this.theseItems.Add(this.bomb);
                this.currentItem = this.theseItems[this.currentItemIndex];
            }
        }

        public void LoadBlaze(IList<Texture2D> itemSpriteSheet)
        {
            if (this.blaze == null)
            {
                this.blaze = new Blaze(itemSpriteSheet);
                this.theseItems.Add(this.blaze);
                this.currentItem = this.theseItems[this.currentItemIndex];
            }
        }


        /*
         *  Requires that theseItems is not empty 
         *  (load your items into the system!)
         */
        public void EquipNextItem()
        {
            if (this.theseItems.Count > 0)
            {
                currentItemIndex++;
                if (this.currentItemIndex < this.theseItems.Count)
                {
                    this.currentItem = this.theseItems[this.currentItemIndex];
                }
                else // equal to or greater than count of items.
                {
                    this.currentItemIndex = 0; // from the top!
                    this.currentItem = this.theseItems[this.currentItemIndex];
                }
            }
        }

        /*
         *  Requires that theseItems is not empty 
         *  (load your items into the system!)
         */
        public void EquipPreviousItem()
        {
            if (this.theseItems.Count > 0)
            {
                currentItemIndex--;
                if (this.currentItemIndex > 0)
                {
                    this.currentItem = this.theseItems[this.currentItemIndex];
                }
                else // index is less than the start of the list.
                {
                    this.currentItemIndex = this.theseItems.Count - 1; // from the top!
                    this.currentItem = this.theseItems[this.currentItemIndex];
                }
            }
        }

        public void UseCurrentItem()
        {
            this.currentItem.Use();
        }

        public void Draw()
        {
            this.currentItem.Draw();
        }

        public void Update()
        {
            this.currentItem.Update();
        }
    }
}

