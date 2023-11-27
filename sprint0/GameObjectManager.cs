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

namespace sprint0
{
    public class GameObjectManager : IManager<IGameObject>
    {
        // UNFINISHED!!!
        // lists for drawable objects updateable objects, dynamic objects and all objects that need to be removed
        private List<IGameObject> drawables; // list of drawable objects
        private List<IGameObject> updateables; // list of updateable objects
        private List<IGameObject> dynamics; // list of dynamic objects
        private List<IGameObject> inPlay; // list of objects in Play
        private List<IGameObject> deleteList; // list of objects to remove
        private List<IGameObject> roomList; // list of room objects - so they can be always drawn and drawn first

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

            // map to hold all the objects in each room
            ObjectMap = new Dictionary<int, List<IGameObject>>();

            currentRoomID = 0;
        }

        // adds object into their respective lists
        public void addObject(IGameObject obj)
        {
            
            // if it is a new room, it makes a new room and add the object in 
            if (!ObjectMap.ContainsKey(obj.GetRoomId()))
            {
                ObjectMap[obj.GetRoomId()] = new List<IGameObject>();
                roomIDs.Add(obj.GetRoomId());
            }
            // adds object in the stated room 
            ObjectMap[obj.GetRoomId()].Add(obj);

            // check the type of the object and add it to the corresponding list
            if (obj.isDynamic()) // dynamic objects
            {
                dynamics.Add(obj);
            }
            if (obj.isDrawable()) // drawable objects
            {
                drawables.Add(obj);
            }
            if (obj.isUpdateable()) // updateable objects
            {
                updateables.Add(obj);
            }
            if (obj.isInPlay()) // objects that are in play
            {
                inPlay.Add(obj);
            }

            drawables = orderDrawableList(drawables);
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

        // objects are added into the delete queue
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
                if (dynamics.Contains(obj)) // dynamic objects
                {
                    dynamics.Remove(obj);
                }
                if (drawables.Contains(obj)) // drawable objects
                {
                    drawables.Remove(obj);
                }
                if (roomList.Contains(obj))
                {
                    roomList.Remove(obj);
                }
                if (updateables.Contains(obj)) // updateable objects
                {
                    updateables.Remove(obj);
                }
                if (inPlay.Contains(obj)) // objects that are in play
                {
                    inPlay.Remove(obj);
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
        public List<IGameObject> getObjectsInRoom(int roomID)
        {
            // returns list, otherwise if it is an unknown roomID, returns empty List
            return ObjectMap.ContainsKey(roomID) ? ObjectMap[roomID] : new List<IGameObject>();
        }

        // returns the objects in the current room
        public List<IGameObject> getOjectsInCurrentRoom()
        {
            List<IGameObject> objectsInCurrentRoom = new List<IGameObject>();
            objectsInCurrentRoom = ObjectMap[currentRoomID];
            return objectsInCurrentRoom;
        }

        // mreturns list of all the objects in the current room that are drawable
        public List<IGameObject> drawablesInRoom()
        {
            List<IGameObject> roomDrawables = new List<IGameObject>();

            foreach (IGameObject obj in drawables)
            {
                if (ObjectMap[currentRoomID].Contains(obj))
                {
                    roomDrawables.Add(obj);
                }
            }
            return orderDrawableList(roomDrawables);
        }

        // returns list of updateables in current room
        public List<IGameObject> updateablesInRoom()
        {
            List<IGameObject> roomUpdateables = new List<IGameObject>();

            foreach (IGameObject obj in updateables)
            {
                if (ObjectMap[currentRoomID].Contains(obj))
                {
                    roomUpdateables.Add(obj);
                }
            }
            return roomUpdateables;
        }

        public List<IGameObject> drawablesInRoom()
        {
            List<IGameObject> roomDrawables = new List<IGameObject>();

            foreach (IGameObject obj in drawables)
            {
                if (obj.GetRoomId() == currentRoomID)
                {
                    roomDrawables.Add(obj);
                }
            }
            return orderDrawableList(roomDrawables);
        }

        public List<IGameObject> updateablesInRoom()
        {
            List<IGameObject> roomUpdateables = new List<IGameObject>();

            foreach (IGameObject obj in updateables)
            {
                if (obj.GetRoomId() == currentRoomID)
                {
                    roomUpdateables.Add(obj);
                }
            }
            return roomUpdateables;
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