using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using sprint0.Commands;
using sprint0.Blocks;
using sprint0.Items;
using sprint0.Link;
using sprint0;
using System.ComponentModel.Design;

namespace sprint0
{
    public class GameObject : IGameObject
    {
        // UNFINISHED!!!
        // lists for drawable objects updateable objects, dynamic objects and all objects that need to be removed
        private List<GameObject> drawables;
        private List<GameObject> updateables;
        private List<GameObject> removeables;
        private List<GameObject> dynamics;
        private List<int> roomIDs;

        // makes a dictionary for the rooms and objects
        // need a constructor
        private Dictionary<int, List<GameObject>> ObjectMap;

        public GameObject() {
            drawables = new List<GameObject>();
            updateables = new List<GameObject>();
            removeables = new List<GameObject>();
            dynamics = new List<GameObject>();
            roomIDs = new List<int>();

            // map to hold all the objects in each room
            ObjectMap = new Dictionary<int, List<GameObject>>();
        }

        // adds object into their respective lists
        public void addObject(int room, GameObject obj) {
            
            // if it is a new room, it makes a new room and add the object in 
            if (!ObjectMap.ContainsKey(room))
            {
                ObjectMap[room] = new List<GameObject>();
                roomIDs.Add(room);
            }
            // adds object in the stated room 
            ObjectMap[room].Add(obj);

            // check the type of the object and add it to the corresponding list
            if (obj.isDynamic()) 
            {
                dynamics.Add(obj);
            }
            if (obj.isDrawable()) 
            {
                drawables.Add(obj); 
            }
            if (obj.isRemovable()) 
            {
                removeables.Add(obj);
            }
            if (obj.isUpdateable()) 
            {
                updateables.Add(obj); 
            }
        }

        // removes object from room
        public void removeObject(int room, GameObject obj)
        {
            // removes the object from the room
            if (ObjectMap[room].Contains(obj))
            {
                ObjectMap[room].Remove(obj);
            }

        }

        // returns list 
        public List<GameObject> getList(string listName) {
            List<GameObject> list = new List<GameObject>();
            // switch case instead of if-else if 
            switch (listName)
            {
                case "drawables":
                    return drawables;
                case "updateables":
                    return updateables;
                case "removeables":
                    return removeables;
                case "dynamics":
                    return dynamics;
                default:
                    return new List<GameObject>();
            }
        }

        // returns list of room IDs
        public List<int> getRoomIDs()
        {
            return roomIDs;
        }

        // returns list of room IDs
        public List<GameObject> getRoomList(int roomID)
        {
            // returns list, otherwise if it is an unknown roomID, returns empty List
            return ObjectMap.ContainsKey(roomID) ? ObjectMap[roomID] : new List<GameObject>();
        }

        // to get the list of objects in a room just by its ID
        // might not be necessary, but it might also simplify things alot
        public Dictionary<int, List<GameObject>> getDictionary()
        {
            // returns list, otherwise if it is an unknown roomID, returns empty List
            return ObjectMap;

        }
    }
}
