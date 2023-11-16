using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.Items;
using sprint0.LinkSword;
using static sprint0.Globals;

namespace sprint0
{
	public class ItemSystem : IItemSystem
	{
        private static ItemSystem instance;
        //public IItem currentItem;
        public IItem currentItemA;
        public IItem currentItemB;
        public ItemsInSlots ItemInSlotA;
        public ItemsInSlots ItemInSlotB;
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

        public ItemSystem() {
            //currentItem = new NullItem();
            currentItemA = new NullItem();
            currentItemB = new NullItem();
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
         * If an item is already in one slot, it will swap the item to the requested one.
         */
        public void EquipBow(Globals.ItemSlots itemSlot)
        {
            switch (itemSlot)
            {
                case ItemSlots.SLOT_A:
                    if (ItemInSlotA != ItemsInSlots.BOW)
                    {
                        if (ItemInSlotB == ItemsInSlots.BOW)
                        {
                            ItemInSlotB = ItemsInSlots.EMPTY;
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Bow(bowFactory, bowDespawnFactory);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BOW)
                    {
                        if (ItemInSlotA == ItemsInSlots.BOW)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Bow(bowFactory, bowDespawnFactory);
                    }
                    break;
            }
            //this.currentItem = new Bow(bowFactory, bowDespawnFactory);
        }

        public void EquipBetterBow(Globals.ItemSlots itemSlot)
        {
            switch (itemSlot)
            {
                case ItemSlots.SLOT_A:
                    if (ItemInSlotA != ItemsInSlots.BETTER_BOW)
                    {
                        if (ItemInSlotB == ItemsInSlots.BETTER_BOW)
                        {
                            ItemInSlotB = ItemsInSlots.EMPTY;
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new BetterBow(bowFactory, bowDespawnFactory);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BETTER_BOW)
                    {
                        if (ItemInSlotA == ItemsInSlots.BETTER_BOW)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new BetterBow(bowFactory, bowDespawnFactory);
                    }
                    break;
            }
        }

        public void EquipBoomerang(Globals.ItemSlots itemSlot)
        {
            switch (itemSlot)
            {
                case ItemSlots.SLOT_A:
                    if (ItemInSlotA != ItemsInSlots.BOOMERANG)
                    {
                        if (ItemInSlotB == ItemsInSlots.BOOMERANG)
                        {
                            ItemInSlotB = ItemsInSlots.EMPTY;
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Boomerang(boomerangFactory);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BOOMERANG)
                    {
                        if (ItemInSlotA == ItemsInSlots.BOOMERANG)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Boomerang(boomerangFactory);
                    }
                    break;
            }
        }

        public void EquipBetterBoomerang(Globals.ItemSlots itemSlot)
        {
            switch (itemSlot)
            {
                case ItemSlots.SLOT_A:
                    if (ItemInSlotA != ItemsInSlots.BETTER_BOOMERANG)
                    {
                        if (ItemInSlotB == ItemsInSlots.BETTER_BOOMERANG)
                        {
                            ItemInSlotB = ItemsInSlots.EMPTY;
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new BetterBoomerang(betterBoomerangFactory);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BETTER_BOOMERANG)
                    {
                        if (ItemInSlotA == ItemsInSlots.BETTER_BOOMERANG)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new BetterBoomerang(betterBoomerangFactory);
                    }
                    break;
            }
        }

        public void EquipBlaze(Globals.ItemSlots itemSlot)
        {
            switch (itemSlot)
            {
                case ItemSlots.SLOT_A:
                    if (ItemInSlotA != ItemsInSlots.BLAZE)
                    {
                        if (ItemInSlotB == ItemsInSlots.BLAZE)
                        {
                            ItemInSlotB = ItemsInSlots.EMPTY;
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Blaze(blazeFactory);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BLAZE)
                    {
                        if (ItemInSlotA == ItemsInSlots.BLAZE)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Blaze(blazeFactory);
                    }
                    break;
            }
        }
        public void EquipBomb(Globals.ItemSlots itemSlot)
        {
            switch (itemSlot)
            {
                case ItemSlots.SLOT_A:
                    if (ItemInSlotA != ItemsInSlots.BOMB)
                    {
                        if (ItemInSlotB == ItemsInSlots.BOMB)
                        {
                            ItemInSlotB = ItemsInSlots.EMPTY;
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Bomb(bombFactory, bombExplodeFactory);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BOMB)
                    {
                        if (ItemInSlotA == ItemsInSlots.BOMB)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Bomb(bombFactory, bombExplodeFactory);
                    }
                    break;
            }
        }
        public void EquipSword(Globals.ItemSlots itemSlot)
        {
            switch (itemSlot)
            {
                case ItemSlots.SLOT_A:
                    if (ItemInSlotA != ItemsInSlots.SWORD)
                    {
                        if (ItemInSlotB == ItemsInSlots.SWORD)
                        {
                            ItemInSlotB = ItemsInSlots.EMPTY;
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Sword(swordFactory);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.SWORD)
                    {
                        if (ItemInSlotA == ItemsInSlots.SWORD)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Sword(swordFactory);
                    }
                    break;
            }
        }

        //public void UseCurrentItem(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        //{
            
        //    if (this.currentItem != null)
        //    {
        //        this.currentItem.Use(linkDirection, linkXPos, linkYPos, linkHeight, linkWidth);
        //        Console.WriteLine("DEBUG: ITEM HAS BEEN USED.");
        //    }
        //}

        /*
         * Draw and Update takes care of all items plus sword.
         */
        public void Draw()
        {
            if (this.currentItemA != null)
            {
                this.currentItemA.Draw(this.spriteBatch);
            }
            if (this.currentItemB != null)
            {
                this.currentItemB.Draw(this.spriteBatch);
            }

        }

        public void Update()
        {
            if (this.currentItemA != null)
            {
                this.currentItemA.Update();
            }
            if (this.currentItemB != null)
            {
                this.currentItemB.Update();
            }

        }

        public void UseCurrentItemA(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            if (this.currentItemA != null)
            {
                this.currentItemA.Use(linkDirection, linkXPos, linkYPos, linkHeight, linkWidth);
                Console.WriteLine("DEBUG: ITEM HAS BEEN USED.");
            }
        }

        public void UseCurrentItemB(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            if (this.currentItemB != null)
            {
                this.currentItemB.Use(linkDirection, linkXPos, linkYPos, linkHeight, linkWidth);
                Console.WriteLine("DEBUG: ITEM HAS BEEN USED.");
            }
        }
    }
}

