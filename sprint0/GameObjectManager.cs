using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using sprint0.Commands;
using sprint0.Blocks;
using sprint0.Items;
using sprint0.LinkObj;
using sprint0;
using System.ComponentModel.Design;
using sprint0.Items.groundItems;
using sprint0.LinkSword;
using sprint0.Enemies;

namespace sprint0
{
    public class GameObjectManager : IManager<IGameObject>
    {
        // UNFINISHED!!!
        // lists for drawable objects updateable objects, dynamic objects and all objects that need to be removed
        private List<IGameObject> drawables;
        private List<IGameObject> updateables;
        private List<IGameObject> dynamics;
        private List<IGameObject> inPlay;
        private List<IGameObject> deleteList;

        private List<IGameObject> blockList;
        private List<IGameObject> itemList;
        private List<IGameObject> enemyList;
        private List<IGameObject> linkList;

        private List<int> roomIDs;

        private int currentRoomID;

        // makes a dictionary for the rooms and objects
        // need a constructor
        private Dictionary<int, List<IGameObject>> ObjectMap;

        public GameObjectManager()
        {
            drawables = new List<IGameObject>();
            updateables = new List<IGameObject>();
            dynamics = new List<IGameObject>();
            inPlay = new List<IGameObject>();
            deleteList = new List<IGameObject>();
            roomIDs = new List<int>();

            // initialize all the types lists
            //blockList = new List<Type> { BlackBlock, BlueDragonBlock, BlueFishBlock, DungeonBlueBlock, DungeonDragonBlock, DungeonFishBlock, DungeonPyramidBlock, GrassBlock, RedPyramidBlock, StairBlock, WaterBlock };
            //itemList = new List<Type> { Blaze, Bomb, BetterBoomerang, Boomerang, BetterBow, Bow, GroundBigHeart, GroundBlaze, GroundBoomerang, GroundCompass, GroundKey, GroundPage, GroundTriforce, Sword };
            //enemyList = new List<Type> { BokoblinBoomerang, DragonBlaze, OktorokBlaze, Bokoblin, Dragon, Oktorok, Skeleton };
            //linkList = new List<Type> { Link, DamagedLink };
            blockList = new List<IGameObject>();
            enemyList = new List<IGameObject>();
            itemList = new List<IGameObject>();
            linkList = new List<IGameObject>();

            // map to hold all the objects in each room
            ObjectMap = new Dictionary<int, List<IGameObject>>();

            currentRoomID = 0;
        }

        // adds object into their respective lists
        public void addObject(IGameObject obj)
        {
            currentRoomID = obj.GetRoomId();

            // if it is a new room, it makes a new room and add the object in 
            if (!ObjectMap.ContainsKey(currentRoomID))
            {
                ObjectMap[currentRoomID] = new List<IGameObject>();
                roomIDs.Add(currentRoomID);
            }
            // adds object in the stated room 
            ObjectMap[currentRoomID].Add(obj);

            // check the type of the object and add it to the corresponding list
            if (obj.isDynamic()) // dynamic objects
            {
                dynamics.Add(obj);
            }
            if (obj.isDrawable()) // drawable objects
            {
                addToTypeList(obj);
            }
            if (obj.isUpdateable()) // updateable objects
            {
                updateables.Add(obj);
            }
            if (obj.isInPlay()) // objects that are in play
            {
                inPlay.Add(obj);
            }
        }

        private void addToTypeList(IGameObject obj)
        {
            if (obj.type() == "Block")
            {
                blockList.Add(obj);
            }
            else if (obj.type() == "Item") {
                itemList.Add(obj);
            }
            else if (obj.type() == "Enemy")
            {
                enemyList.Add(obj);
            }
            else if (obj.type() == "Link") 
            {
                linkList.Add(obj);
            }
        }

        private void orderDrawables()
        {
            drawables.Clear();
            drawables.AddRange(blockList);
            drawables.AddRange(itemList);
            drawables.AddRange(enemyList);
            drawables.AddRange(linkList);
        }

        // if objects are not in play and are removable are added into the delete queue
        public void removeObject(IGameObject obj)
        {
            currentRoomID = obj.GetRoomId();
            // removes the object from the room
            if (!inPlay.Contains(obj))
            {
                deleteList.Add(obj);
            }

        }

        // removes object from room
        public void deleteObjects()
        {
            foreach (IGameObject obj in deleteList)
            {
                // removes the objects from the room
                if (ObjectMap[currentRoomID].Contains(obj))
                {
                    ObjectMap[currentRoomID].Remove(obj);
                }

            }
            // clears list
            deleteList = new List<IGameObject>();
        }

        // returns the current room ID
        public int getCurrentRoomID()
        {
            return currentRoomID;
        }

        // to set the Room ID
        public void setCurrentRoomID(int ID)
        {
            currentRoomID = ID;
        }

        // returns list 
        public List<IGameObject> getList(string listName)
        {
            List<IGameObject> list = new List<IGameObject>();
            // switch case instead of if-else if 
            switch (listName)
            {
                case "drawables":
                    orderDrawables();
                    return drawables;
                case "updateables":
                    return updateables;
                case "removeables":
                    return deleteList;
                case "dynamics":
                    return dynamics;
                case "isInPlay":
                    return inPlay;
                default:
                    return list;
            }
        }

        // returns list of room IDs
        public List<int> getRoomIDs()
        {
            return roomIDs;
        }

        // returns list of room objects
        public List<IGameObject> getObjectsInRoom()
        {
            // returns list, otherwise if it is an unknown roomID, returns empty List
            return ObjectMap.ContainsKey(currentRoomID) ? ObjectMap[currentRoomID] : new List<IGameObject>();
        }

        // to get the list of objects in a room just by its ID
        // might not be necessary, but it might also simplify things alot
        public Dictionary<int, List<IGameObject>> getDictionary()
        {
            // returns list, otherwise if it is an unknown roomID, returns empty List
            return ObjectMap;

        }
    }
}