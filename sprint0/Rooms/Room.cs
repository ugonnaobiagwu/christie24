using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.AnimatedSpriteFactory;
using sprint0.Commands;
using sprint0.Factory;

namespace sprint0.Rooms
{
    public class Room : IRoom, IGameObject
    {
        private List<int> roomList;
        private SpriteFactory spriteFactory;
        private int currentRoomIndex;
        private int currentRoomID;
        private Dictionary<int, List<IGameObject>> gameObjects;
        private int xPos, yPos, width1, height1;
        bool inPlay, dynamic;

        // Constructor, initialization, and other methods...
        // need to draw rooms

        public int xPosition() { return xPos;  }
        public int yPosition() { return yPos; }
        public int width() { return width1; }
        public int height() { return height1; }
        public bool isDynamic()
        { // for smooth scrolling??? i have no idea
            return dynamic;
        }
        public bool isUpdateable() { return false; }
        public bool isInPlay() { return inPlay; }
        public bool isDrawable() { return true; }

        public void SetRoomId(int roomId) 
        { 
            currentRoomID = roomId; 
            // finds index of room id
            for (int i = 0; i < roomList.Count; i++)
            {
                if (roomList[i] == currentRoomID) { 
                    currentRoomIndex = i;
                }
            }
        
        }
        public int GetRoomId() { return currentRoomID; }

        public Room(sprint0.Sprint0 Game)
        {
            GameObjectManager obj = new GameObjectManager();
            gameObjects = obj.getDictionary();
            roomList = obj.getRoomIDs();
            currentRoomIndex = 0;
            currentRoomID = roomList[currentRoomIndex];

            // need to implement this
            inPlay = true;
            dynamic = true;
            xPos = 0; yPos = 0; width1 = 0; height1 = 0;
        }

        public void PreviousRoom()
        {
            currentRoomIndex--;
            if (currentRoomIndex < 0)
            {
                currentRoomIndex = roomList.Count - 1; // Wrap around to the last room's index
                currentRoomID = roomList[currentRoomIndex];
            }
            //You can directly access the current room using rooms[currentRoomIndex]
        }

        public void NextRoom()
        {
            currentRoomIndex++;
            if (currentRoomIndex >= roomList.Count)
            {
                currentRoomIndex = 0; // Wrap around to the first room's index
                currentRoomID = roomList[currentRoomIndex];
            }
            //You can directly access the current room using rooms[currentRoomIndex]
        }

        // draws each object in the room
        // tentative code
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteFactory.draw(spriteBatch);
        }
    }
}