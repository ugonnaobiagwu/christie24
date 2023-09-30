using Microsoft.Xna.Framework.Input;
using Sprint0;
using System;
using System.Collections.Generic;

public class MouseController : IController
{
    private ICommand linkAttack; 
    private ICommand linkGetDamage;

    // used to register mouse states with their respective commands 
    public void registerKeys()
    {
        // isn't really follwing the name of the method
        // there is probably an easier way to implement this
        // no idea how to implement the transition states at the moment
        linkAttack = new AttackCommand();
        linkGetDamage = new DamagedCommand();

    }

    public void Update()
    {
        // I have no idea how to put mouse states into an array like keyboard control
        // so I will just make it so
        // hopefully this only works while NOTHING is pressed


        MouseState mouseState = Mouse.GetState();

        while (mouseState != null)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                linkAttack.execute();
                // if you left-click, link attacks
            } 
            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                // if you right-click, link gets damage
                linkGetDamage.execute();
            }
        }
            

        /* this is the code i had previously but I decided to change the code
        * 
        * not sure how to implement this but here is the tentative code
        * 
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
            // just learned that Link always has a shield. Perhaps use it for something else?
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
       */

        // I have no idea how the scroll wheel value thing works but i hope this is how you do it
    }
}
