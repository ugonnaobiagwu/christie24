using System;
using System.Collections.Generic;
using sprint0;
using sprint0.Commands;

namespace sprint0.Rooms
{
    public class Room : IRoom, IGameObject
    {
        private List<int> rooms;
        private int currentRoomIndex;
        private int currentRoomID;
        private Dictionary<int, List<IGameObject>> gameObjects;
        int xPosition { get; set; }
        int yPosition { get; set; }
        int width { get; set; }
        int height { get; set; }
        bool isDynamic { get; set; }

        // Constructor, initialization, and other methods...
        // need to draw rooms

        public Room(sprint0.Sprint0 Game)
        {
            GameObjectManager obj = new GameObjectManager();
            gameObjects = obj.getDictionary();
            rooms = obj.getRoomIDs();
            currentRoomIndex = 0;
            currentRoomID = rooms[currentRoomIndex];
        }

        public void PreviousRoom()
        {
            currentRoomIndex--;
            if (currentRoomIndex < 0)
            {
                currentRoomIndex = rooms.Count - 1; // Wrap around to the last room's index
                currentRoomID = rooms[currentRoomIndex];
            }
            //You can directly access the current room using rooms[currentRoomIndex]
        }

        public void NextRoom()
        {
            currentRoomIndex++;
            if (currentRoomIndex >= rooms.Count)
            {
                currentRoomIndex = 0; // Wrap around to the first room's index
                currentRoomID = rooms[currentRoomIndex];
            }
            //You can directly access the current room using rooms[currentRoomIndex]
        }

        //returns current room ID
        public int getCurrentRoomID()
        {
            return currentRoomID;
        }
    }
}