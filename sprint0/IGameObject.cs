using System;
using System.Collections.Generic;

namespace sprint0
{
	public interface IGameObject
	{
        public void addObject(int room, GameObject obj); //adds object to list
        public void removeObject(int room, GameObject obj); //removes object from list
        public List<GameObject> getList(string listName); // gets lists
        public List<int> getRoomIDs(); // gets room IDs
        public List<GameObject> getRoomList(int roomID); // gets list from room ID
        public Dictionary<int, List<GameObject>> getDictionary(); // gets list of objects in a room
    }
}

