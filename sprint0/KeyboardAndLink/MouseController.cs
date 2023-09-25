using Microsoft.Xna.Framework.Input;
using Sprint_2;
using System;
using System.Collections.Generic;

public class MouseController : IController
{
    public void Update()
    {
        int scrollWheel, horizontalScrollWheel;

        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            // if left mouse button is pressed, it activates attack
            LinkAttack.execute();
        }
        else if (mouseState.RightButton == ButtonState.Pressed)
        {
            // if right mouse button is pressed, i have no idea what to implement
            // perhaps defend for now?
            LinkDefend.execute();
        }
        else if (mouseState.ScrollWheelValue == mouseState.HorizontalScrollWheelValue)
        {
            // if it scrolls up, the weapon changes to next weapon
            LinkChangeNextWeapon.execute();
        }
        else if (mouseState.ScrollWheelValue > mouseState.HorizontalScrollWheelValue)
        { 
            // if it scrolls down, the weapon changes to previous weapon
            LinkChangePreviousWeapon.execute();
        }

        // I have no idea how the scroll wheel value thing works but i hope this is how you do it
    }
}
