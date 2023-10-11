//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using sprint0.Commands;
//using sprint0;

// havent studied into how to do it exactly, but the code below is mainly from the KeyboardController
//namespace sprint0.Controllers
//{
    //public class GamePadController : IController
    //{
    //    //Instantiaze commands
    //    private ICommand linkWalkingUp;
    //    private ICommand linkWalkingDown;
    //    private ICommand linkWalkingLeft;
    //    private ICommand linkWalkingRight;

    //    // makes a dictionary for the keys and commands
    //    private Dictionary<Keys, ICommand> KeyMap;

    //    public GamePadController(sprint0.Sprint0 Game)
    //    {
    //        KeyMap = new Dictionary<Keys, ICommand>();
    //        previousKeys = new List<Keys>();

    //        // not sure if I should put this in here or registerkeys
    //        linkWalkingUp = new WalkUpCommand(Game);
    //        linkWalkingLeft = new WalkLeftCommand(Game);
    //        linkWalkingDown = new WalkDownCommand(Game);
    //        linkWalkingRight = new WalkRightCommand(Game);

    //    }

    //    // used to register keys with their respective commands
    //    public void registerKeys()
    //    {
    //        // KeyMap[key] = command;
    //        // Names of Commands are not permanent

    //        // Movement Controls
    //        // link moves up for up arrow key, and w key
    //        KeyMap.Add(Keys.W, linkWalkingUp);
    //        KeyMap.Add(Keys.Up, linkWalkingUp);
    //        // link moves left for left arrow key, and a key
    //        KeyMap.Add(Keys.A, linkWalkingLeft);
    //        KeyMap.Add(Keys.Left, linkWalkingLeft);
    //        // link moves down for down arrow key, and s key
    //        KeyMap.Add(Keys.S, linkWalkingDown);
    //        KeyMap.Add(Keys.Down, linkWalkingDown);
    //        // link moves right for right arrow key, and d key
    //        KeyMap.Add(Keys.D, linkWalkingRight);
    //        KeyMap.Add(Keys.Right, linkWalkingRight);

    //    }

    //    // executes commands for each key pressed
    //    public void Update()
    //    {
    //        Keys[] Pressed = Keyboard.GetState().GetPressedKeys();
    //        foreach (Keys key in Pressed)
    //        {
    //            KeyMap[key].execute();
    //        }

    //    }
    //}
//}
