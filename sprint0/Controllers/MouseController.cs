using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using sprint0.Commands;
using sprint0;

namespace sprint0.Controllers
{
    public class MouseController : IController
    {
        private List<int> roomList;
        private int currentRoomIndex;
        private int currentRoomID;
        private Dictionary<int, List<IGameObject>> gameObjects;
        private MouseState previousMouseState;
        private MouseState currentMouseState;
        private GameObjectManager gameObjectManager;

        public MouseController(sprint0.Sprint0 Game)
        {
            // or something like that to get the global
            gameObjectManager = Globals.GameObjectManager;

            gameObjects = gameObjectManager.getDictionary();
            roomList = gameObjectManager.getRoomIDs();
            currentRoomIndex = 0;
            currentRoomID = roomList[currentRoomIndex];

            previousMouseState = Mouse.GetState();
            currentMouseState = Mouse.GetState();
        }

        public void registerKeys()
        {
            // nothing to really register
        }

        public void Update()
        {
            // this is for edge? transitions
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            // Essentially only executes when you press (so if you never release the mouse, it doesnt change)
            if (previousMouseState.LeftButton != ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                // if you press the left button, it goes to the previous room (in the list)
                currentRoomIndex--;
                if (currentRoomIndex < 0)
                {
                    currentRoomIndex = roomList.Count - 1; // Wrap around to the last room's index
                    currentRoomID = roomList[currentRoomIndex];
                    gameObjectManager.setCurrentRoomID(currentRoomID);
                }
            }
            else if (previousMouseState.RightButton != ButtonState.Pressed && currentMouseState.RightButton == ButtonState.Pressed)
            {
                // if you press the right button, it goes to the next room (in the list)
                currentRoomIndex++;
                if (currentRoomIndex >= roomList.Count)
                {
                    currentRoomIndex = 0; // Wrap around to the first room's index
                    currentRoomID = roomList[currentRoomIndex];
                    gameObjectManager.setCurrentRoomID(currentRoomID);
                }
            }
        }
    }
}