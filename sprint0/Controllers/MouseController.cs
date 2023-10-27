using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using sprint0.Commands;
using sprint0;
using sprint0.Rooms;

namespace sprint0.Controllers
{
    public class MouseController : IController
    {
        // need to know current room and list of objects... but how?
        ICommand previousRoom;
        ICommand nextRoom;
        Room room;
        // make the changing of rooms in GameObject Manager
        // go through a list of rooms

        public MouseController()
        {
            room = new Room();
            previousRoom = new PreviousRoomCommand(room);
            nextRoom = new NextRoomCommand(room);
        }

        public void registerKeys()
        {
            // nothing to really register
        }

        public void Update()
        {
            // in future updates, using the mouse to click the room on a map might be an option
            // i just need to study it more to see how it would work

            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                previousRoom.execute();
            }
            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                nextRoom.execute();
            }

        }
    }
}