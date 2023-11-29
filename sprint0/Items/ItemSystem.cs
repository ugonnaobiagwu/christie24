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
        private SpriteFactory iceSwordFactory;
        private SpriteFactory fireSwordFactory;
        private SpriteBatch spriteBatch;
        public LinkTunic CurrentTunic { get; set; }    
        /*
         * [code: theseItems] will be used to limit whether or not link can equip an 
         * item depending on how the inventory system works
         */

        public ItemSystem() {
            //currentItem = new NullItem();
            currentItemA = new NullItem();
            currentItemB = new NullItem();
            ItemInSlotA = ItemsInSlots.EMPTY;
            ItemInSlotB = ItemsInSlots.EMPTY;

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

        public void LoadSword(SpriteFactory factory, SpriteFactory iceFactory, SpriteFactory fireFactory)
        {
            if (this.swordFactory == null)
            {
                this.swordFactory = factory;
                this.iceSwordFactory = iceFactory;
                this.fireSwordFactory = fireFactory;
                
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
         * 
         * WHEN ITEM EQUIPMENT IS IN... DELETE THE OBJECT 
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
                            Globals.GameObjectManager.removeObject(currentItemB);
                            Console.WriteLine("Nullified Item in Item Slot B.");
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Bow(bowFactory, bowDespawnFactory);
                        ItemInSlotA = ItemsInSlots.BOW;
                        Globals.GameObjectManager.addObject(currentItemA);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BOW)
                    {
                        if (ItemInSlotA == ItemsInSlots.BOW)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            Globals.GameObjectManager.removeObject(currentItemA);
                            Console.WriteLine("Nullified Item in Item Slot A.");
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Bow(bowFactory, bowDespawnFactory);
                        ItemInSlotB = ItemsInSlots.BOW;
                        Globals.GameObjectManager.addObject(currentItemB);
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
                            Globals.GameObjectManager.removeObject(currentItemB);
                            Console.WriteLine("Nullified Item in Item Slot B.");
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new BetterBow(bowFactory, bowDespawnFactory);
                        ItemInSlotA = ItemsInSlots.BETTER_BOW;
                        Globals.GameObjectManager.addObject(currentItemA);

                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BETTER_BOW)
                    {
                        if (ItemInSlotA == ItemsInSlots.BETTER_BOW)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            Globals.GameObjectManager.removeObject(currentItemA);
                            Console.WriteLine("Nullified Item in Item Slot A.");
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new BetterBow(bowFactory, bowDespawnFactory);
                        ItemInSlotB = ItemsInSlots.BETTER_BOW;
                        Globals.GameObjectManager.addObject(currentItemB);
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
                            Globals.GameObjectManager.removeObject(currentItemB);
                            this.currentItemB = new NullItem();
                            Console.WriteLine("Nullified Item in Item Slot B.");
                        }
                        Console.WriteLine("Equipped Item in Item Slot A.");
                        this.currentItemA = new Boomerang(boomerangFactory);
                        ItemInSlotA = ItemsInSlots.BOOMERANG;
                        Globals.GameObjectManager.addObject(currentItemA);

                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BOOMERANG)
                    {
                        if (ItemInSlotA.Equals( ItemsInSlots.BOOMERANG))
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            this.currentItemA = new NullItem();
                            Console.WriteLine("Nullified Item in Item Slot A.");
                        }
                        Console.WriteLine("Equipped Item in Item Slot B.");
                        this.currentItemB = new Boomerang(boomerangFactory);
                        ItemInSlotB = ItemsInSlots.BOOMERANG;
                        Globals.GameObjectManager.addObject(currentItemB);
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
                            Globals.GameObjectManager.removeObject(currentItemB);
                            Console.WriteLine("Nullified Item in Item Slot B.");
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new BetterBoomerang(betterBoomerangFactory);
                        ItemInSlotA = ItemsInSlots.BETTER_BOOMERANG;
                        Globals.GameObjectManager.addObject(currentItemA);

                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BETTER_BOOMERANG)
                    {
                        if (ItemInSlotA == ItemsInSlots.BETTER_BOOMERANG)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            Globals.GameObjectManager.removeObject(currentItemA);
                            Console.WriteLine("Nullified Item in Item Slot A.");
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new BetterBoomerang(betterBoomerangFactory);
                        ItemInSlotB = ItemsInSlots.BETTER_BOOMERANG;
                        Globals.GameObjectManager.addObject(currentItemB);
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
                            Globals.GameObjectManager.removeObject(currentItemB);
                            Console.WriteLine("Nullified Item in Item Slot B.");
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Blaze(blazeFactory);
                        ItemInSlotA = ItemsInSlots.BLAZE;

                        Globals.GameObjectManager.addObject(currentItemA);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BLAZE)
                    {
                        if (ItemInSlotA == ItemsInSlots.BLAZE)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            Globals.GameObjectManager.removeObject(currentItemA);
                            Console.WriteLine("Nullified Item in Item Slot A.");
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Blaze(blazeFactory);
                        ItemInSlotB = ItemsInSlots.BLAZE;

                        Globals.GameObjectManager.addObject(currentItemB);
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
                            Globals.GameObjectManager.removeObject(currentItemB);
                            Console.WriteLine("Nullified Item in Item Slot B.");
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Bomb(bombFactory, bombExplodeFactory);
                        ItemInSlotA = ItemsInSlots.BOMB;

                        Globals.GameObjectManager.addObject(currentItemA);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.BOMB)
                    {
                        if (ItemInSlotA == ItemsInSlots.BOMB)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            Globals.GameObjectManager.removeObject(currentItemA);
                            Console.WriteLine("Nullified Item in Item Slot A.");
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Bomb(bombFactory, bombExplodeFactory);
                        ItemInSlotB = ItemsInSlots.BOMB;

                        Globals.GameObjectManager.addObject(currentItemB);
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
                            Globals.GameObjectManager.removeObject(currentItemB);
                            Console.WriteLine("Nullified Item in Item Slot B.");
                            this.currentItemB = new NullItem();
                        }
                        this.currentItemA = new Sword(swordFactory, iceSwordFactory, fireSwordFactory);
                        ItemInSlotA = ItemsInSlots.SWORD;

                        Globals.GameObjectManager.addObject(currentItemA);
                    }
                    break;
                case ItemSlots.SLOT_B:
                    if (ItemInSlotB != ItemsInSlots.SWORD)
                    {
                        if (ItemInSlotA == ItemsInSlots.SWORD)
                        {
                            ItemInSlotA = ItemsInSlots.EMPTY;
                            Globals.GameObjectManager.removeObject(currentItemA);
                            Console.WriteLine("Nullified Item in Item Slot A.");
                            this.currentItemA = new NullItem();
                        }
                        this.currentItemB = new Sword(swordFactory, iceSwordFactory, fireSwordFactory);
                        ItemInSlotB = ItemsInSlots.SWORD;

                        Globals.GameObjectManager.addObject(currentItemB);
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
                Console.WriteLine("Using Item A of ITEM SLOT TYPE:" + ItemInSlotA.ToString() + " AND GAME OBJECT TYPE:" + currentItemA.GetType().ToString());
            }
        }

        public void UseCurrentItemB(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth)
        {
            if (this.currentItemB != null)
            {
                this.currentItemB.Use(linkDirection, linkXPos, linkYPos, linkHeight, linkWidth);
                Console.WriteLine("Using Item B of ITEM SLOT TYPE:" + ItemInSlotB.ToString() + " AND GAME OBJECT TYPE:" + currentItemB.GetType().ToString());
            }
        }
    }
}

