using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.LinkObj;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.HUDs
{
    public static class Inventory


    {

        public enum LinkLevel
        {
            LOW, MEDIUM, HIGH
        }

        /* ELEMENTAL ENEMIES AND SCALING TESTING. REMOVE THIS LINE AND INIT
         * THIS VALUE PROPERLY WHEN YOU GET TO IT.
         */

       
        //Checking on global for pause (!pause) or a boolean method to check if this is paused??
        //ENUM
        public enum ItemTypes
        {
            HEART,
            RUPEE,
            KEY,
            BOMB,
            LEVEL,
            MINIMAP

        }

        public enum slotTypes
        {
            SLOTA,
            SLOTB
        }

        public enum GroundItemsInSlot
        {
            BOW,
            BETTER_BOW,
            BOOMERANG,
            BETTER_BOOMERANG,
            BLAZE,
            BOMB,
            SWORD,
            EMPTY
        }
        public static bool hasPage { get; set; }
        public static bool hasCompass { get; set; }
        public static bool hasTriforce { get; set; }

        static private ContentManager contentManager;
        static ItemSystem itemSystem;
        static IGameObject igameObject;
        static int fullLife = 10; //5 hearts
        static int defaultLife = 6; //3 hearts
        static int noLife = 0;
        static int initialState = 0;
        
        
       

        public static LinkLevel currentLinkLevel = LinkLevel.HIGH;
        public static Globals.ItemsInSlots slotA = Globals.ItemsInSlots.EMPTY;
        public static Globals.ItemsInSlots slotB = Globals.ItemsInSlots.EMPTY;
           
        public static  Dictionary<ItemTypes, int> items;
        //public static Dictionary<slotTypes, string> slotItems;
        public static Dictionary<GroundItemsInSlot, Texture2D> itemSheets;
        public static Dictionary<Globals.ItemSlots, Globals.ItemsInSlots> currentSlot;


        static Inventory()
        {
            items = new Dictionary<ItemTypes, int>
            {

                {ItemTypes.HEART, defaultLife}, //Begins with 3 Hearts
                {ItemTypes.RUPEE, initialState},
                {ItemTypes.KEY,initialState},
                {ItemTypes.BOMB,initialState},
                {ItemTypes.LEVEL,1}, //starts at level 1
                {ItemTypes.MINIMAP,initialState}
            };

            currentSlot = new Dictionary<Globals.ItemSlots, Globals.ItemsInSlots> {


               { Globals.ItemSlots.SLOT_A,Globals.ItemsInSlots.EMPTY},
               { Globals.ItemSlots.SLOT_B,Globals.ItemsInSlots.EMPTY}
            };
        }

        public static void SetContentManager(ContentManager content)
        {
            contentManager = content;
            if (contentManager != null)
            {
                itemSheets = new Dictionary<GroundItemsInSlot, Texture2D> {
                { GroundItemsInSlot.BOW, contentManager.Load<Texture2D>("groundItemSprites/groundBow") } ,
                { GroundItemsInSlot.BETTER_BOW, contentManager.Load<Texture2D>("equippedItemSprites/equippedBetterBow") } ,
                { GroundItemsInSlot.BOOMERANG, contentManager.Load<Texture2D>("groundItemSprites/groundBoomerang") } ,
                { GroundItemsInSlot.BETTER_BOOMERANG, contentManager.Load<Texture2D>("hud/hudBetterBoomerang") } ,
                { GroundItemsInSlot.BLAZE, contentManager.Load<Texture2D>("hud/hudBlaze") },
                { GroundItemsInSlot.BOMB, contentManager.Load<Texture2D>("groundItemSprites/groundBomb") },
                { GroundItemsInSlot.SWORD, contentManager.Load<Texture2D>("hud/hudSword") }



            };
            }

        }
        public static Texture2D LocateCurrentAItemSheet()
        {
            //Globals.ItemSlots currentKey;

            
            Texture2D tempSheetItem = null;
            // string temp = currentSlot[Globals.ItemSlots.SLOT_A].ToString()



            foreach (var item in itemSheets.Keys)
            {
                string itemString = item.ToString();
               


                if (!string.IsNullOrEmpty(itemString) && itemString.Equals(slotA.ToString()))
                {

                    tempSheetItem = itemSheets[item];
                    
                    break;
                }


            }

            if (tempSheetItem == null)
            {
                Console.WriteLine("ERROR tempSheetItem Null \n");
            }
           
            return tempSheetItem;

        }

        public static Texture2D LocateCurrentBItemSheet()
        {
            //Globals.ItemsInSlots currentKey = default;


            Texture2D tempSheetItem = null;
            string temp = currentSlot[Globals.ItemSlots.SLOT_B].ToString();




            foreach (var item in itemSheets.Keys)
            {
                string itemString = item.ToString();



                if (!string.IsNullOrEmpty(itemString) && itemString.Equals(slotB.ToString()))
                {

                    tempSheetItem = itemSheets[item];

                    break;
                }


            }

            if (tempSheetItem == null)
            {
                Console.WriteLine("ERROR tempSheetItem Null \n");
            }

            return tempSheetItem;

        }

        //METHOD STARTS FROM HERE
        //DELETE ALL int PARAMETERS (except for ROOMID in roomLevel method)LATER in INVENTORY!! IT WILL CALLED WHEN WE NEED IT!

        public static void RoomLevel(int roomID)
        {

            //compare the first roomID number. The first number of the roomID indicates the level number
            items[ItemTypes.LEVEL] = igameObject.GetRoomId();

        }
        public static void GainHeart()
        {

            //gain up to five hearts in total
            if (items[ItemTypes.HEART] < fullLife)
            {
                items[ItemTypes.HEART]++; //increase Heart

            }

        }

        public static void LoseHeart()
        {

            if (items[ItemTypes.HEART] > noLife)
            {
                items[ItemTypes.HEART]--; //decrease Heart

            }

        }

        public static void CountRupee()
        {
            int addRupee = 5; // adding 5 rupees per grab

            items[ItemTypes.RUPEE] += addRupee; //increase count rupee by 5 per count



        }

        public static void CountKey()
        {

            items[ItemTypes.KEY]++; //increase count key



        }

        public static void GainBomb()
        {
            int addBomb = 4; //adding 4 bombs per pick up

            items[ItemTypes.BOMB] += addBomb; 


        }

        public static void LoseBomb()
        {

            items[ItemTypes.BOMB]--; //lose bomb when used



        }


        //the slots might just be in one whole method
        //checks for slot A before B
        //if A is empty, put the item in A, else B
        // if A and B is full, then add it to B(?)
        public static void Slots(Globals.ItemSlots currentSlotPlacement, Globals.ItemsInSlots currentSlotA, Globals.ItemsInSlots currentSlotB)
        {
            string stringCurrentSlot = currentSlotPlacement.ToString();
            slotA = currentSlotA;
            slotB = currentSlotB;


            if (currentSlotPlacement.ToString() == "SLOT_A")
            {

                LocateCurrentAItemSheet();


            }
            else if (currentSlotPlacement.ToString() == "SLOT_B")
            {

                LocateCurrentBItemSheet();

            }

            // string vals = currentSlot[Globals.ItemSlots.SLOT_A].ToString();
            //before adding in slotB check for slot As



        }

        //METHOD MIGHT NOT BE USED (method slots used instead)
        public static void SlotAItem(Globals.ItemsInSlots currentSlotA)
        {
            slotA = currentSlotA;

            currentSlot[Globals.ItemSlots.SLOT_A] = currentSlotA;
            //displayslot A item if picked up
            LocateCurrentAItemSheet();
            

        }

        public static void SlotBItem(Globals.ItemsInSlots currentSlotB)
        {
            slotB = currentSlotB;

            currentSlot[Globals.ItemSlots.SLOT_B] = currentSlotB;
            //display slot B item if picked up
            LocateCurrentBItemSheet();


        }

        public static bool PageResult()
        {

            return hasPage;
        }
        public static bool CompassResult()
        {

            return hasCompass;
        }
        public static bool TriforceResult()
        {

            return hasTriforce;
        }




    }
}
