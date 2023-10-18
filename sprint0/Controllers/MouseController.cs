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
        // make the changing of rooms in GameObject Manager
        // go through a list of rooms

        // this is what I would imagine them to be named as, not permanent
        private ICommand previousRoom;
        private ICommand nextRoom;

        public void registerKey(Keys key, ICommand command)
        {
            throw new NotImplementedException();
        }

        // used to register mouse states with their respective commands 
        public void registerKeys()
        {
            // for Sprint3, i will need to implement the room/level changes
            //previousLevel = new PreviousLevel();
            //nextLevel = new NextLevel();

        }

        public void Update()
        {
            // in future updates, using the mouse to click the room/level on a map might be an option
            // i just need to study it more to see how it would work
            MouseState mouseState = Mouse.GetState();


            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                previousRoom.execute();
                // if you left-click, changes to previous level
            }
            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                // if you right-click, changes to next level
                nextRoom.execute();
            }

        }
    }
}