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
    public class GameObjectManager : IManager<IGameObject>
    {
        // UNFINISHED!!!
        // lists for drawable objects updateable objects, dynamic objects and all objects that need to be removed
        private List<IGameObject> drawables;
        private List<IGameObject> updateables;
        private List<IGameObject> removeables;
        private List<IGameObject> dynamics;
        private List<int> roomIDs;

        // makes a dictionary for the rooms and objects
        // need a constructor
        private Dictionary<int, List<IGameObject>> ObjectMap;

        public void IGameObjectManager()
        {
            drawables = new List<IGameObject>();
            updateables = new List<IGameObject>();
            removeables = new List<IGameObject>();
            dynamics = new List<IGameObject>();
            roomIDs = new List<int>();

            // map to hold all the objects in each room
            ObjectMap = new Dictionary<int, List<IGameObject>>();
        }

        // adds object into their respective lists
        public void AddObject(int room, IGameObject obj)
        {

            // if it is a new room, it makes a new room and add the object in 
            if (!ObjectMap.ContainsKey(room))
            {
                ObjectMap[room] = new List<IGameObject>();
                roomIDs.Add(room);
            }
            // adds object in the stated room 
            ObjectMap[room].Add(obj);

            // check the type of the object and add it to the corresponding list
            if (obj.isDynamic())
            {
                dynamics.Add(obj);
            }
            //if (obj.isDrawable())
            //{
            //    drawables.Add(obj);
            //}
            //if (obj.isRemovable())
            //{
            //    removeables.Add(obj);
            //}
            //if (obj.isUpdateable())
            //{
            //    updateables.Add(obj);
            //}
        }

        // removes object from room
        public void RemoveObject(int room, IGameObject obj)
        {
            // removes the object from the room
            if (ObjectMap[room].Contains(obj))
            {
                ObjectMap[room].Remove(obj);
            }

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
                    return removeables;
                case "dynamics":
                    return dynamics;
                default:
                    return new List<IGameObject>();
            }
        }

        // returns list of room IDs
        public List<int> getRoomIDs()
        {
            return roomIDs;
        }

        // returns list of room IDs
        public List<IGameObject> getRoomList(int roomID)
        {
            // returns list, otherwise if it is an unknown roomID, returns empty List
            return ObjectMap.ContainsKey(roomID) ? ObjectMap[roomID] : new List<IGameObject>();
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