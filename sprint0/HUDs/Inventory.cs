using sprint0.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.HUDs
{
   internal static class Inventory
    {

        //Checking on global for pause (!pause) or a boolean method to check if this is paused?
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

        //ILink link;
        //ISprite currentSprite;
        static IGameObject igameObject;
        static int fullLife = 10; //5 hearts
        static int defaultLife = 6; //3 hearts
        static int noLife = 0;
        static int initialState = 0;
        
        
        

        static HUD hud;
        public static  Dictionary<ItemTypes, int> items;
        public static Dictionary<slotTypes, string> slotItems;

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

            slotItems = new Dictionary<slotTypes, string> {

                { slotTypes.SLOTA,"EMPTY"},
               { slotTypes.SLOTB,"EMPTY"}
            };
        }

        //use delegates
        public static void AddItem() { }

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
        public static void Slots(string currentItem)
        {

            //before adding in slotB check for slot As
            if (slotItems[slotTypes.SLOTA] == "EMPTY")
            { hud.SlotADisplay(currentItem); }

            else { hud.SlotBDisplay(currentItem); }


        }

        //METHOD MIGHT NOT BE USED (method slots used instead)
        public static void SlotAItem(string currentItemA)
        {

            //displayslot A item if picked up


        }

        public static void SlotBItem(string currentItemB)
        {

            //display slot B item if picked up

            //before adding in slotB check for slot As
            if (slotItems[slotTypes.SLOTA] == "EMPTY")
            {

                SlotAItem(currentItemB);
            }
            else
            {

                //display in slot B HUD

            }

        }

    }
}
