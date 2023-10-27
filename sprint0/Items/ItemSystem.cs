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
        private IList<Texture2D> bowTexture;
        private IList<Texture2D> betterBowTexture;
        private IList<Texture2D> boomerangTexture;
        private IList<Texture2D> betterBoomerangTexture;
        private IList<Texture2D> bombTexture;
        private IList<Texture2D> blazeTexture;
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
            if (this.bowTexture == null)
            {
                this.bowTexture = itemSpriteSheet;
            }
        }

        public void LoadBetterBow(IList<Texture2D> itemSpriteSheet)
        {
            if (this.betterBowTexture == null)
            {
                this.betterBowTexture = itemSpriteSheet;
            }
        }

        public void LoadBoomerang(IList<Texture2D> itemSpriteSheet)
        {
            if (this.boomerangTexture == null)
            {
                this.boomerangTexture = itemSpriteSheet;
            }
        }

        public void LoadBetterBoomerang(IList<Texture2D> itemSpriteSheet)
        {
            if (this.betterBoomerangTexture == null)
            {
                this.betterBoomerangTexture = itemSpriteSheet;
            }
        }

        public void LoadBomb(IList<Texture2D> itemSpriteSheet)
        {
            if (this.bombTexture == null)
            {
                this.bombTexture = itemSpriteSheet;
            }
        }

        public void LoadBlaze(IList<Texture2D> itemSpriteSheet)
        {
            if (this.blazeTexture == null)
            {
                this.blazeTexture = itemSpriteSheet;
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
         * 
         * THESE EQUIPMENTS WILL BE MOVED TO THE INVENTORY SYSTEM 
         * TO AVOID NEW ITEMS BEING EQUIPPED IN THE MIDDLE OF THE CURRENT ONE
         */
        public void EquipBow()
        {
          
            this.currentItem = new Bow(bowTexture);
        }

        public void EquipBetterBow()
        {
            this.currentItem = new BetterBow(betterBowTexture);
        }

        public void EquipBoomerang()
        {
            this.currentItem = new Boomerang(boomerangTexture);
        }

        public void EquipBetterBoomerang()
        {
            this.currentItem = new BetterBoomerang(betterBoomerangTexture);
        }

        public void EquipBlaze()
        {
            this.currentItem = new Blaze(blazeTexture);
        }
        public void EquipBomb()
        {
            this.currentItem = new Bomb(bombTexture);
        }

        public void UseCurrentItem(int linkDirection, int linkXPos, int linkYPos)
        {
            
            if (this.currentItem != null)
            {
                this.currentItem.Use(linkDirection, linkXPos, linkYPos);
                Console.WriteLine("DEBUG: ITEM HAS BEEN USED.");
            }
        }

        public void SwingSword(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            this.sword.SwingSword(linkDirection, linkXPos, linkYPos, linkHeight, linkWidth);
        }

        public void Draw()
        {
            if (this.currentItem != null)
            {
                this.currentItem.Draw(this.spriteBatch);
            }
        }

        public void Update()
        {
            if (this.currentItem != null)
            {
                this.currentItem.Update();
            }
        }
    }
}

