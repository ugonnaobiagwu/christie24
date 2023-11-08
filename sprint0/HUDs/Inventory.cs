﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.HUDs
{
    internal class Inventory
    {
        //ENUM
        public enum ItemTypes
        {
            HEART,
            GEM,
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

        int fullLife = 5;
        int defaultLife = 3;
        int noLife = 0;
        int initialState = 0;

        HUD hud;
        public Dictionary<ItemTypes, int> items;
        public Dictionary<slotTypes, string> slotItems;

        public Inventory()
        {
            items = new Dictionary<ItemTypes, int>
            {

                {ItemTypes.HEART, defaultLife}, //Begin with 3 Hearts
                {ItemTypes.GEM, initialState},
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

        //METHOD STARTS FROM HERE
        //DELETE ALL int PARAMETERS (except for ROOMID in roomLevel method)LATER in INVENTORY!! IT WILL CALLED WHEN WE NEED IT!

        public void roomLevel(int roomID)
        {

            //compare the first roomID number. The first number of the roomID indicates the level number

        }
        public void gainHeart()
        {

            //gain up to five hearts in total
            if (items[ItemTypes.HEART] <= fullLife)
            {
                items[ItemTypes.HEART]++; //increase Heart

            }

        }

        public void loseHeart()
        {

            if (items[ItemTypes.HEART] > noLife)
            {
                items[ItemTypes.HEART]--; //decrease Heart

            }

        }

        public void countGem(int gemCount)
        {

            items[ItemTypes.GEM] += 5 * gemCount; //increase count gem by 5 per count



        }

        public void countKey(int keyCount)
        {

            items[ItemTypes.KEY] += keyCount; //increase count key

            //code to display Ruby            

        }

        public void countBomb(int bombCount)
        {

            items[ItemTypes.BOMB] += 4 * bombCount; //increase count bomb

            //code to display Ruby            

        }


        //the slots might just be in one whole method
        //checks for slot A before B
        //if A is empty, put the item in A, else B
        // if A and B is full, then add it to B(?)
        public void Slots(string currentItem)
        {

            //before adding in slotB check for slot As
            if (slotItems[slotTypes.SLOTA] == "EMPTY")
            { hud.slotADisplay(currentItem); }

            else { hud.slotBDisplay(currentItem); }


        }

        //METHOD MIGHT NOT BE USED (method slots used instead)
        public void slotAItem(string currentItemA)
        {

            //displayslot A item if picked up


        }

        public void slotBItem(string currentItemB)
        {

            //display slot B item if picked up

            //before adding in slotB check for slot As
            if (slotItems[slotTypes.SLOTA] == "EMPTY")
            {

                slotAItem(currentItemB);
            }
            else
            {

                //display in slot B HUD

            }

        }

    }
}
