using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Items;
using sprint0.LinkSword;

namespace sprint0
{
	public class ItemSystem : IItemSystem
	{
        private static ItemSystem instance;
        private IItem currentItem;
        private IItem currentItemA;
        private IItem currentItemB;
        private IItem sword;
        private SpriteFactory bowFactory;
        private SpriteFactory bowDespawnFactory;
        private SpriteFactory betterBowFactory;
        private SpriteFactory boomerangFactory;
        private SpriteFactory betterBoomerangFactory;
        private SpriteFactory bombFactory;
        private SpriteFactory bombExplodeFactory;
        private SpriteFactory blazeFactory;
        private SpriteFactory swordFactory;
        private SpriteBatch spriteBatch;
        private IList<String> theseItems;       
        /*
         * [code: theseItems] will be used to limit whether or not link can equip an 
         * item depending on how the inventory system works
         */

        public ItemSystem() {
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
        public void LoadBow(SpriteFactory factory, SpriteFactory despawnFactory)
        {
            if (this.bowFactory == null)
            {
                this.bowFactory = factory;
                this.bowDespawnFactory = despawnFactory;
            }
        }

        public void LoadBetterBow(SpriteFactory factory, SpriteFactory despawnFactory)
        {
            if (this.betterBowFactory == null)
            {
                this.betterBowFactory = factory;
                this.bowDespawnFactory = despawnFactory;
            }
        }

        public void LoadBoomerang(SpriteFactory factory)
        {
            if (this.boomerangFactory == null)
            {
                this.boomerangFactory = factory;
            }
        }

        public void LoadBetterBoomerang(SpriteFactory factory)
        {
            if (this.betterBoomerangFactory == null)
            {
                this.betterBoomerangFactory = factory;
            }
        }

        public void LoadBomb(SpriteFactory factory, SpriteFactory explosiveFactory)
        {
            if (this.bombFactory == null)
            {
                this.bombFactory = factory;
                this.bombExplodeFactory = explosiveFactory;
            }
        }

        public void LoadBlaze(SpriteFactory factory)
        {
            if (this.blazeFactory == null)
            {
                this.blazeFactory = factory;
            }
        }

        public void LoadSword(SpriteFactory factory)
        {
            if (this.swordFactory == null)
            {
                this.swordFactory = factory;
                
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
          
            this.currentItem = new Bow(bowFactory, bowDespawnFactory);
        }

        public void EquipBetterBow()
        {
            this.currentItem = new BetterBow(betterBowFactory, bowDespawnFactory);
        }

        public void EquipBoomerang()
        {
            this.currentItem = new Boomerang(boomerangFactory);
        }

        public void EquipBetterBoomerang()
        {
            this.currentItem = new BetterBoomerang(betterBoomerangFactory);
        }

        public void EquipBlaze()
        {
            this.currentItem = new Blaze(blazeFactory);
        }
        public void EquipBomb()
        {
            this.currentItem = new Bomb(bombFactory, bombExplodeFactory);
        }

        public void UseCurrentItem(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            
            if (this.currentItem != null)
            {
                this.currentItem.Use(linkDirection, linkXPos, linkYPos, linkHeight, linkWidth);
                Console.WriteLine("DEBUG: ITEM HAS BEEN USED.");
            }
        }

        //public void SwingSword(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        //{
        //    this.sword.SwingSword(linkDirection, linkXPos, linkYPos, linkHeight, linkWidth);
        //    Console.WriteLine("DEBUG: SWORD HAS BEEN SWUNG.");
        //}

        /*
         * Draw and Update takes care of all items plus sword.
         */
        public void Draw()
        {
            if (this.currentItem != null)
            {
                this.currentItem.Draw(this.spriteBatch);
                this.sword.Draw(this.spriteBatch);
            }

           
        }

        public void Update()
        {
            if (this.currentItem != null)
            {
                this.currentItem.Update();
            }
            this.sword.Update();

            
        }
    }
}

